using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentVehiclePool.Data;
using RentVehiclePool.Models;

namespace RentVehiclePool.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AccountContext _accountContext;
        private readonly UserManager<User> _userManager;

        public TransactionsController(AppDbContext context, AccountContext accountContext, UserManager<User> userManager)
        {
            _context = context;
            _accountContext = accountContext;
            _userManager = userManager;
        }

        // GET: Transactions
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Transactions.Include(t => t.Vehicle);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            //User user = _accountContext.Users.FirstOrDefault(x => x.UserName == "mike@abc.com");
            //var currentUser = await _userManager.GetUserAsync(User);

            //ViewData["CurrentUser"] = currentUser.FullName;
            ViewData["VehicleId"] = new SelectList(_context.Vehicles.Select(x => new
            {
                x.VehicleId,
                Name = x.Brand + " " + x.Model + " " + x.Year.ToString(),
            }), "VehicleId", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,VehicleId,TransactionNo,TransactionType,Description,DriverName,Status,UsedDate,ReturnedDate,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Transaction transaction)
        {
            

            if (ModelState.IsValid)
            {
                // Getting first record of Approver level 1
                User approver = _accountContext.Users.FirstOrDefault(x => x.Role.RoleName == "Approval 1");
                var currentUser = await _userManager.GetUserAsync(User);

                // Update timestamps and user login
                transaction.CreatedDate = DateTime.Now;
                transaction.UpdatedDate = DateTime.Now;
                transaction.CreatedBy = currentUser.FullName;
                transaction.UpdatedBy = currentUser.FullName;
                //transaction.UsedDate = DateTime.Now;

                Approval approval = new Approval()
                {
                    ApprovalLevels = 2,
                    Remarks = "",
                    Status = "New Request",
                    ApprovalNo = "APV-0123-MIKE",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = currentUser.FullName,
                    UpdatedBy = currentUser.FullName
                };
                transaction.Approval = approval;

                ApprovalDetail approvalDetail = new ApprovalDetail()
                {
                    ApvUserId = approver.UserId,
                    Level = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = currentUser.FullName,
                    UpdatedBy = currentUser.FullName
                };
                ICollection<ApprovalDetail> approvalDetails = new ApprovalDetail[] { approvalDetail };
                approval.ApprovalDetails = approvalDetails;

                _context.Add(transaction);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles.Select(x => new
            {
                x.VehicleId,
                Name = x.Brand + " " + x.Model + " " + x.Year.ToString(),
            }), "VehicleId", "Name", transaction.VehicleId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles.Select(x => new
            {
                x.VehicleId,
                Name = x.Brand + " " + x.Model + " " + x.Year.ToString(),
            }), "VehicleId", "Name", transaction.VehicleId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,VehicleId,TransactionNo,TransactionType,Description,DriverName,Status,UsedDate,ReturnedDate,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //User user = _accountContext.Users.FirstOrDefault(x => x.UserName == "mike@abc.com");
                    var currentUser = await _userManager.GetUserAsync(User);
                    var vehicle = await _context.Vehicles.FindAsync(transaction.VehicleId);

                    // Update timestamps and user login
                    transaction.UpdatedDate = DateTime.Now;
                    transaction.UpdatedBy = currentUser.FullName;
                    vehicle.IsUsed = false;
                    vehicle.UpdatedDate = DateTime.Now;
                    vehicle.UpdatedBy = currentUser.FullName;
                    //transaction.UsedDate = DateTime.Now;

                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles.Select(x => new
            {
                x.VehicleId,
                Name = x.Brand + " " + x.Model + " " + x.Year.ToString(),
            }), "VehicleId", "Name", transaction.VehicleId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.Transactions
        //        .Include(t => t.Vehicle)
        //        .FirstOrDefaultAsync(m => m.TransactionId == id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transaction);
        //}

        //// POST: Transactions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Transactions == null)
        //    {
        //        return Problem("Entity set 'AppDbContent.Transactions'  is null.");
        //    }
        //    var transaction = await _context.Transactions.FindAsync(id);
        //    if (transaction != null)
        //    {
        //        _context.Transactions.Remove(transaction);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public FileResult ExportToExcel(string htmlTable)
        {
            return File(Encoding.ASCII.GetBytes(htmlTable), "application/vnd.ms-excel", "Transactions.xls");
        }

        private bool TransactionExists(int id)
        {
          return (_context.Transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}

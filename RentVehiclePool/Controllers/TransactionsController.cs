using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentVehiclePool.Data;
using RentVehiclePool.Models;

namespace RentVehiclePool.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly RentVehiclePoolContext _context;
        private readonly AccountContext _accountContext;

        public TransactionsController(RentVehiclePoolContext context, AccountContext accountContext)
        {
            _context = context;
            _accountContext = accountContext;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var rentVehiclePoolContext = _context.Transactions.Include(t => t.Vehicle);
            return View(await rentVehiclePoolContext.ToListAsync());
        }

        // GET: Transactions/Details/5
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
        public IActionResult Create()
        {
            User user = _accountContext.Users.FirstOrDefault(x => x.UserName == "mike@abc.com");

            ViewData["CurrentUser"] = user.FullName;
            ViewData["VehicleId"] = new SelectList(_context.Vehicles.Select(x => new
            {
                VehicleId = x.VehicleId,
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
                User user = _accountContext.Users.FirstOrDefault(x => x.UserName == "mike@abc.com");

                // Update timestamps and user login
                transaction.CreatedDate = DateTime.Now;
                transaction.UpdatedDate = DateTime.Now;
                transaction.CreatedBy = user.FullName;
                transaction.UpdatedBy = user.FullName;
                //transaction.UsedDate = DateTime.Now;

                Approval approval = new Approval()
                {
                    ApprovalLevels = 2,
                    Remarks = "",
                    Status = "New Request",
                    ApprovalNo = "X-TESTING",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = user.FullName,
                    UpdatedBy = user.FullName
                };
                transaction.Approval = approval;

                ApprovalDetail approvalDetail = new ApprovalDetail()
                {
                    ApvUserId = user.UserId,
                    Level = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = user.FullName,
                    UpdatedBy = user.FullName
                };
                ICollection<ApprovalDetail> approvalDetails = new ApprovalDetail[] { approvalDetail };
                approval.ApprovalDetails = approvalDetails;

                _context.Add(transaction);
                await _context.SaveChangesAsync();
                //InsertApprovalData(transaction.TransactionId, transaction.CreatedBy, user.UserId);

                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles.Select(x => new
            {
                VehicleId = x.VehicleId,
                Name = x.Brand + " " + x.Model + " " + x.Year.ToString(),
            }), "VehicleId", "Name", transaction.VehicleId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
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
                VehicleId = x.VehicleId,
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
            DateTime now = DateTime.Now;
            transaction.UpdatedDate = now;
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                VehicleId = x.VehicleId,
                Name = x.Brand + " " + x.Model + " " + x.Year.ToString(),
            }), "VehicleId", "Name", transaction.VehicleId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'RentVehiclePoolContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
          return (_context.Transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }

        private async Task UpdateVehicleUsageStatus(int vehicleId, User user, bool isUsed)
        {
            // Update vehicle being used
            Vehicle vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == vehicleId);
            vehicle.IsUsed = true;
            vehicle.UpdatedDate = DateTime.Now;
            vehicle.UpdatedBy = user.FullName;

            _context.Update(vehicle);
            await _context.SaveChangesAsync();
        }

        private void InsertApprovalData(int transactionId, string currentUser, Guid currentUserId)
        {
            // Add approval data
            Approval approval = new Approval()
            {
                ApprovalLevels = 2,
                Remarks = "",
                Status = "New Request",
                ApprovalNo = "X-TESTING",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = currentUser,
                UpdatedBy = currentUser,
                TransactionId = transactionId,
            };

            ApprovalDetail approvalDetail = new ApprovalDetail()
            {
                ApvUserId = currentUserId,
                Level = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = currentUser,
                UpdatedBy = currentUser
            };

            approval.ApprovalDetails.Add(approvalDetail);
            _context.Add(approval);
            _context.SaveChanges();
        }
    }
}

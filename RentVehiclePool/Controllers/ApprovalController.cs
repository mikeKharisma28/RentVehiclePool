using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentVehiclePool.Data;
using RentVehiclePool.Models;

namespace RentVehiclePool.Controllers
{
    public class ApprovalController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AccountContext _accountContext;
        private readonly UserManager<User> _userManager;

        public ApprovalController(AppDbContext context, AccountContext accountContext, UserManager<User> userManager)
        {
            _context = context;
            _accountContext = accountContext;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var approvalDetail = _context.ApprovalDetails
                .Where(ad => ad.ApvUserId == currentUser.UserId && ad.IsApproved == null)
                .Include(ad => ad.Approval)
                .ThenInclude(a => a.Transaction)
                .ThenInclude(t => t.Vehicle);
            return View(await approvalDetail.ToListAsync());
        }

        //[Authorize]
        //public async Task<IActionResult> Detail(int? id, Guid userId)
        //{
        //    if (id == null || _context.Approvals == null)
        //    {
        //        return NotFound();
        //    }
        //    var approval = await _context.Approvals
        //        .Include(a => a.ApprovalDetails)
        //        .Include(a => a.Transaction).ThenInclude(t => t.Vehicle)
        //        .FirstOrDefaultAsync(a => a.ApprovalId == id);

        //    if (approval == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(approval);
        //}

        [Authorize]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null || _context.Approvals == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var current = _userManager.GetUserId(User);
            var approvalDetail = await _context.ApprovalDetails.FindAsync(id);
            var approval = await _context.Approvals.FindAsync(approvalDetail.ApprovalId);
            var transaction = await _context.Transactions.FindAsync(approval.TransactionId);

            approvalDetail.IsApproved = true;
            approvalDetail.UpdatedDate = DateTime.Now;
            approvalDetail.UpdatedBy = currentUser.FullName;

            approval.UpdatedBy = currentUser.FullName;
            approval.UpdatedDate = DateTime.Now;

            if (approvalDetail.Level < approval.ApprovalLevels)
            {
                User nextApprover = _accountContext.Users.FirstOrDefault(x => x.Role.RoleName == "Approval 2");
                approval.Status = "Progress";
                approval.Remarks = "Approval 1 done";

                transaction.Status = "Progress";
                transaction.UpdatedBy = currentUser.FullName;
                transaction.UpdatedDate = DateTime.Now;

                // Create new approval detail for approval level 2
                ApprovalDetail newApproval = new ApprovalDetail()
                {
                    ApprovalId = approval.ApprovalId,
                    ApvUserId = nextApprover.UserId,
                    Level = 2,
                    CreatedBy = currentUser.FullName,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = currentUser.FullName,
                    UpdatedDate = DateTime.Now,
                };

                approval.ApprovalDetails.Add(newApproval);
            }
            else
            {
                
                var vehicle = await _context.Vehicles.FindAsync(transaction.VehicleId);

                approval.Status = "Done";
                approval.Remarks = "Approval 2 done";

                transaction.Status = "Approved";
                transaction.UpdatedBy = currentUser.FullName;
                transaction.UpdatedDate = DateTime.Now;

                vehicle.IsUsed = true;
                vehicle.UpdatedBy = currentUser.FullName;
                vehicle.UpdatedDate = DateTime.Now;

            }

            //_context.Update(approval);
            _context.Update(approvalDetail);
            _context.SaveChanges();

            if (approvalDetail == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Reject(int? id, Guid userId)
        {
            if (id == null || _context.Approvals == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var approvalDetail = await _context.ApprovalDetails.FindAsync(id);
            var approval = await _context.Approvals.FindAsync(approvalDetail.ApprovalId);
            var transaction = await _context.Transactions.FindAsync(approval.TransactionId);

            approvalDetail.IsApproved = false;
            approvalDetail.UpdatedDate = DateTime.Now;
            approvalDetail.UpdatedBy = currentUser.FullName;

            approval.UpdatedBy = currentUser.FullName;
            approval.UpdatedDate = DateTime.Now;
            approval.Status = "Rejected";
            approval.Remarks = "User rejected the request";

            transaction.Status = "Rejected";
            transaction.UpdatedBy = currentUser.FullName;
            transaction.UpdatedDate = DateTime.Now;

            _context.Update(approvalDetail);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals
{
    public class LeaveApprovalService
    {
        private readonly AppDbContext _context;

        public LeaveApprovalService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE APPROVAL + update LeaveRequest status
        public async Task<LeaveApprovalCreateResponseModel> ApproveAsync(LeaveApprovalCreateRequestModel request)
        {
            var leaveRequest = await _context.LeaveRequests
                .FirstOrDefaultAsync(x => x.LeaveRequestId == request.LeaveRequestId && !x.IsDeleted);

            if (leaveRequest == null)
            {
                return new LeaveApprovalCreateResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave request not found"
                };
            }

            // Insert approval
            var approval = new LeaveApproval
            {
                LeaveRequestId = request.LeaveRequestId,
                ApprovedBy = request.ApprovedBy,
                ApprovalStatus = request.ApprovalStatus,
                Comments = request.Comments ?? string.Empty,
                ApprovalDate = DateTime.Now
            };

            await _context.LeaveApprovals.AddAsync(approval);

            // Update leave request status
            leaveRequest.Status = request.ApprovalStatus;

            await _context.SaveChangesAsync();

            return new LeaveApprovalCreateResponseModel
            {
                IsSuccess = true,
                Message = "Leave request approved/rejected successfully",
                ApprovalId = approval.ApprovalId
            };
        }

        // LIST (pagination)
        public async Task<LeaveApprovalListResponseModel> GetAllAsync(LeaveApprovalListRequestModel request)
        {
            var query = _context.LeaveApprovals
                .Include(x => x.LeaveRequest).ThenInclude(l => l.Employee)
                .Include(x => x.LeaveRequest).ThenInclude(l => l.LeaveType)
                .Include(x => x.ApprovedByNavigation) // approver
                .Where(x => !x.IsDeleted);

            var totalCount = await query.CountAsync();

            var list = await query
                .OrderByDescending(x => x.ApprovalDate)
                .Skip((request.PageNo - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LeaveApprovalDto
                {
                    ApprovalId = x.ApprovalId,
                    LeaveRequestId = x.LeaveRequestId,
                    ApprovedBy = x.ApprovedBy,
                    ApproverName = x.ApprovedByNavigation.EmployeeName,
                    ApprovalStatus = x.ApprovalStatus,
                    Comments = x.Comments,
                    ApprovalDate = x.ApprovalDate,
                    EmployeeName = x.LeaveRequest.Employee.EmployeeName,
                    LeaveTypeName = x.LeaveRequest.LeaveType.LeaveTypeName
                })
                .ToListAsync();

            return new LeaveApprovalListResponseModel
            {
                IsSuccess = true,
                Message = "Leave approvals retrieved successfully",
                TotalCount = totalCount,
                Approvals = list
            };
        }

        // DELETE (soft)
        public async Task<LeaveApprovalDeleteResponseModel> DeleteAsync(LeaveApprovalDeleteRequestModel request)
        {
            var entity = await _context.LeaveApprovals
                .FirstOrDefaultAsync(x => x.ApprovalId == request.ApprovalId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveApprovalDeleteResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave approval not found"
                };
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new LeaveApprovalDeleteResponseModel
            {
                IsSuccess = true,
                Message = "Leave approval deleted successfully"
            };
        }
    }
}

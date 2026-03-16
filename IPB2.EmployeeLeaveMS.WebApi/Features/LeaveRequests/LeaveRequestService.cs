using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2.EmployeeLeaveMS.WebApi.Features.LeaveRequests
{
    public class LeaveRequestService
    {
        private readonly AppDbContext _context;

        public LeaveRequestService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<LeaveRequestCreateResponseModel> CreateAsync(LeaveRequestCreateRequestModel request)
        {
            // Calculate total days using DateOnly.DayNumber
            var totalDays = (request.EndDate.DayNumber - request.StartDate.DayNumber) + 1;

            var entity = new LeaveRequest
            {
                EmployeeId = request.EmployeeId,
                LeaveTypeId = request.LeaveTypeId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalDays = totalDays,
                Reason = request.Reason,
                Status = "Pending"
            };

            await _context.LeaveRequests.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new LeaveRequestCreateResponseModel
            {
                IsSuccess = true,
                Message = "Leave request created successfully",
                LeaveRequestId = entity.LeaveRequestId
            };
        }

        // LIST (pagination)
        public async Task<LeaveRequestListResponseModel> GetAllAsync(LeaveRequestListRequestModel request)
        {
            var query = _context.LeaveRequests
                .Include(x => x.Employee)
                .Include(x => x.LeaveType)
                .Where(x => !x.IsDeleted);

            var totalCount = await query.CountAsync();

            var list = await query
                .OrderByDescending(x => x.AppliedDate)
                .Skip((request.PageNo - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LeaveRequestDto
                {
                    LeaveRequestId = x.LeaveRequestId,
                    EmployeeId = x.EmployeeId,
                    EmployeeName = x.Employee.EmployeeName,
                    LeaveTypeId = x.LeaveTypeId,
                    LeaveTypeName = x.LeaveType.LeaveTypeName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    TotalDays = x.TotalDays,
                    Reason = x.Reason,
                    Status = x.Status,
                    AppliedDate = x.AppliedDate
                })
                .ToListAsync();

            return new LeaveRequestListResponseModel
            {
                IsSuccess = true,
                Message = "Leave requests retrieved successfully",
                TotalCount = totalCount,
                LeaveRequests = list
            };
        }

        // DETAIL
        public async Task<LeaveRequestDetailResponseModel> GetByIdAsync(LeaveRequestDetailRequestModel request)
        {
            var entity = await _context.LeaveRequests
                .Include(x => x.Employee)
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.LeaveRequestId == request.LeaveRequestId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveRequestDetailResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave request not found"
                };
            }

            return new LeaveRequestDetailResponseModel
            {
                IsSuccess = true,
                Message = "Leave request retrieved successfully",
                LeaveRequestId = entity.LeaveRequestId,
                EmployeeId = entity.EmployeeId,
                EmployeeName = entity.Employee.EmployeeName,
                LeaveTypeId = entity.LeaveTypeId,
                LeaveTypeName = entity.LeaveType.LeaveTypeName,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                TotalDays = entity.TotalDays,
                Reason = entity.Reason,
                Status = entity.Status,
                AppliedDate = entity.AppliedDate
            };
        }

        // UPDATE STATUS
        public async Task<LeaveRequestUpdateStatusResponseModel> UpdateStatusAsync(LeaveRequestUpdateStatusRequestModel request)
        {
            var entity = await _context.LeaveRequests
                .FirstOrDefaultAsync(x => x.LeaveRequestId == request.LeaveRequestId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveRequestUpdateStatusResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave request not found"
                };
            }

            entity.Status = request.Status;
            await _context.SaveChangesAsync();

            return new LeaveRequestUpdateStatusResponseModel
            {
                IsSuccess = true,
                Message = "Leave request status updated successfully"
            };
        }

        // DELETE (soft delete)
        public async Task<LeaveRequestDeleteResponseModel> DeleteAsync(LeaveRequestDeleteRequestModel request)
        {
            var entity = await _context.LeaveRequests
                .FirstOrDefaultAsync(x => x.LeaveRequestId == request.LeaveRequestId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveRequestDeleteResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave request not found"
                };
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new LeaveRequestDeleteResponseModel
            {
                IsSuccess = true,
                Message = "Leave request deleted successfully"
            };
        }
    }
}
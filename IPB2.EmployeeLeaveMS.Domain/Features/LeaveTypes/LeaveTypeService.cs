using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes
{
    public class LeaveTypeService
    {
        private readonly AppDbContext _context;

        public LeaveTypeService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<LeaveTypeCreateResponseModel> CreateAsync(LeaveTypeCreateRequestModel request)
        {
            var entity = new LeaveType
            {
                LeaveTypeName = request.LeaveTypeName,
                Description = request.Description,
                MaxDaysPerYear = request.MaxDaysPerYear
            };

            await _context.LeaveTypes.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new LeaveTypeCreateResponseModel
            {
                IsSuccess = true,
                Message = "Leave type created successfully",
                LeaveTypeId = entity.LeaveTypeId
            };
        }

        // LIST (Pagination)
        public async Task<LeaveTypeListResponseModel> GetAllAsync(LeaveTypeListRequestModel request)
        {
            var query = _context.LeaveTypes.Where(x => !x.IsDeleted);

            var totalCount = await query.CountAsync();

            var list = await query
                .OrderBy(x => x.LeaveTypeId)
                .Skip((request.PageNo - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LeaveTypeDto
                {
                    LeaveTypeId = x.LeaveTypeId,
                    LeaveTypeName = x.LeaveTypeName,
                    Description = x.Description,
                    MaxDaysPerYear = x.MaxDaysPerYear
                })
                .ToListAsync();

            return new LeaveTypeListResponseModel
            {
                IsSuccess = true,
                Message = "Leave types retrieved successfully",
                TotalCount = totalCount,
                LeaveTypes = list
            };
        }

        // DETAIL
        public async Task<LeaveTypeDetailResponseModel> GetByIdAsync(LeaveTypeDetailRequestModel request)
        {
            var entity = await _context.LeaveTypes
                .FirstOrDefaultAsync(x => x.LeaveTypeId == request.LeaveTypeId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveTypeDetailResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave type not found"
                };
            }

            return new LeaveTypeDetailResponseModel
            {
                IsSuccess = true,
                Message = "Leave type retrieved",
                LeaveTypeId = entity.LeaveTypeId,
                LeaveTypeName = entity.LeaveTypeName,
                Description = entity.Description,
                MaxDaysPerYear = entity.MaxDaysPerYear
            };
        }

        // UPDATE
        public async Task<LeaveTypeUpdateResponseModel> UpdateAsync(LeaveTypeUpdateRequestModel request)
        {
            var entity = await _context.LeaveTypes
                .FirstOrDefaultAsync(x => x.LeaveTypeId == request.LeaveTypeId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveTypeUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave type not found"
                };
            }

            entity.LeaveTypeName = request.LeaveTypeName;
            entity.Description = request.Description;
            entity.MaxDaysPerYear = request.MaxDaysPerYear;

            await _context.SaveChangesAsync();

            return new LeaveTypeUpdateResponseModel
            {
                IsSuccess = true,
                Message = "Leave type updated successfully"
            };
        }

        // DELETE (Soft Delete)
        public async Task<LeaveTypeDeleteResponseModel> DeleteAsync(LeaveTypeDeleteRequestModel request)
        {
            var entity = await _context.LeaveTypes
                .FirstOrDefaultAsync(x => x.LeaveTypeId == request.LeaveTypeId && !x.IsDeleted);

            if (entity == null)
            {
                return new LeaveTypeDeleteResponseModel
                {
                    IsSuccess = false,
                    Message = "Leave type not found"
                };
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new LeaveTypeDeleteResponseModel
            {
                IsSuccess = true,
                Message = "Leave type deleted successfully"
            };
        }
    }
}

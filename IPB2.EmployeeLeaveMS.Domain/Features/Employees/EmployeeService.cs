using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2.EmployeeLeaveMS.Domain.Features.Employees
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        // REGISTER EMPLOYEE
        public async Task<EmployeeCreateResponseModel> CreateAsync(EmployeeCreateRequestModel request)
        {
            var employee = new Employee
            {
                EmployeeCode = request.EmployeeCode,
                EmployeeName = request.EmployeeName,
                Email = request.Email,
                Phone = request.Phone,
                Department = request.Department,
                Position = request.Position,
                JoinDate = request.JoinDate
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return new EmployeeCreateResponseModel
            {
                IsSuccess = true,
                Message = "Employee created successfully",
                EmployeeId = employee.EmployeeId
            };
        }

        // EMPLOYEE LIST
        public async Task<EmployeeListResponseModel> GetAllAsync(EmployeeListRequestModel request)
        {
            var query = _context.Employees
                .Where(x => !x.IsDeleted);

            var totalCount = await query.CountAsync();

            var employees = await query
                .OrderBy(x => x.EmployeeId)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new EmployeeDto
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeCode = x.EmployeeCode,
                    EmployeeName = x.EmployeeName,
                    Department = x.Department,
                    Position = x.Position
                })
                .ToListAsync();

            return new EmployeeListResponseModel
            {
                IsSuccess = true,
                Message = "Employee list retrieved",
                TotalCount = totalCount,
                Employees = employees
            };
        }

        // EMPLOYEE DETAIL
        public async Task<EmployeeDetailResponseModel> GetByIdAsync(EmployeeDetailRequestModel request)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId && !x.IsDeleted);

            if (employee == null)
            {
                return new EmployeeDetailResponseModel
                {
                    IsSuccess = false,
                    Message = "Employee not found"
                };
            }

            return new EmployeeDetailResponseModel
            {
                IsSuccess = true,
                Message = "Employee retrieved",
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                Phone = employee.Phone,
                Department = employee.Department,
                Position = employee.Position,
                JoinDate = employee.JoinDate
            };
        }

        // UPDATE EMPLOYEE
        public async Task<EmployeeEditResponseModel> UpdateAsync(EmployeeEditRequestModel request)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId && !x.IsDeleted);

            if (employee == null)
            {
                return new EmployeeEditResponseModel
                {
                    IsSuccess = false,
                    Message = "Employee not found"
                };
            }

            employee.EmployeeName = request.EmployeeName;
            employee.Email = request.Email;
            employee.Phone = request.Phone;
            employee.Department = request.Department;
            employee.Position = request.Position;

            await _context.SaveChangesAsync();

            return new EmployeeEditResponseModel
            {
                IsSuccess = true,
                Message = "Employee updated successfully"
            };
        }

        // DELETE (SOFT DELETE)
        public async Task<EmployeeDeleteResponseModel> DeleteAsync(EmployeeDeleteRequestModel request)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId && !x.IsDeleted);

            if (employee == null)
            {
                return new EmployeeDeleteResponseModel
                {
                    IsSuccess = false,
                    Message = "Employee not found"
                };
            }

            employee.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new EmployeeDeleteResponseModel
            {
                IsSuccess = true,
                Message = "Employee deleted successfully"
            };
        }
    }
}

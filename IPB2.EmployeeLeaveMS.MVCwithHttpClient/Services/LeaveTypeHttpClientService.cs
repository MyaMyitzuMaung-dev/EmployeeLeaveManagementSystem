using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services
{
    public class LeaveTypeHttpClientService : BaseHttpClientService
    {
        public LeaveTypeHttpClientService(HttpClient httpClient, IConfiguration configuration) 
            : base(httpClient, configuration)
        {
        }

        public async Task<LeaveTypeCreateResponseModel?> CreateAsync(LeaveTypeCreateRequestModel request)
        {
            return await PostAsync<LeaveTypeCreateRequestModel, LeaveTypeCreateResponseModel>("LeaveType/create", request);
        }

        public async Task<LeaveTypeListResponseModel?> GetAllAsync(int pageNo, int pageSize)
        {
            return await GetAsync<LeaveTypeListResponseModel>($"LeaveType/list?pageNo={pageNo}&pageSize={pageSize}");
        }

        public async Task<LeaveTypeDetailResponseModel?> GetByIdAsync(int id)
        {
            return await GetAsync<LeaveTypeDetailResponseModel>($"LeaveType/detail?leaveTypeId={id}");
        }

        public async Task<LeaveTypeUpdateResponseModel?> UpdateAsync(LeaveTypeUpdateRequestModel request)
        {
            return await PutAsync<LeaveTypeUpdateRequestModel, LeaveTypeUpdateResponseModel>("LeaveType/update", request);
        }

        public async Task<LeaveTypeDeleteResponseModel?> DeleteAsync(int id)
        {
            return await DeleteAsync<LeaveTypeDeleteResponseModel>($"LeaveType/delete?leaveTypeId={id}");
        }
    }
}

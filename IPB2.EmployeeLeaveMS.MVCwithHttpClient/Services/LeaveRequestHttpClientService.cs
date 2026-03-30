using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services
{
    public class LeaveRequestHttpClientService : BaseHttpClientService
    {
        public LeaveRequestHttpClientService(HttpClient httpClient, IConfiguration configuration) 
            : base(httpClient, configuration)
        {
        }

        public async Task<LeaveRequestCreateResponseModel?> CreateAsync(LeaveRequestCreateRequestModel request)
        {
            return await PostAsync<LeaveRequestCreateRequestModel, LeaveRequestCreateResponseModel>("LeaveRequest/create", request);
        }

        public async Task<LeaveRequestListResponseModel?> GetAllAsync(int pageNo, int pageSize)
        {
            return await GetAsync<LeaveRequestListResponseModel>($"LeaveRequest/list?pageNo={pageNo}&pageSize={pageSize}");
        }

        public async Task<LeaveRequestDetailResponseModel?> GetByIdAsync(int id)
        {
            return await GetAsync<LeaveRequestDetailResponseModel>($"LeaveRequest/detail?leaveRequestId={id}");
        }

        public async Task<LeaveRequestUpdateStatusResponseModel?> UpdateStatusAsync(LeaveRequestUpdateStatusRequestModel request)
        {
            return await PutAsync<LeaveRequestUpdateStatusRequestModel, LeaveRequestUpdateStatusResponseModel>("LeaveRequest/update-status", request);
        }

        public async Task<LeaveRequestDeleteResponseModel?> DeleteAsync(int id)
        {
            return await DeleteAsync<LeaveRequestDeleteResponseModel>($"LeaveRequest/delete?leaveRequestId={id}");
        }
    }
}

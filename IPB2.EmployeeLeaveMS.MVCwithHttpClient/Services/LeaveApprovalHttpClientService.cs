using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services
{
    public class LeaveApprovalHttpClientService : BaseHttpClientService
    {
        public LeaveApprovalHttpClientService(HttpClient httpClient, IConfiguration configuration) 
            : base(httpClient, configuration)
        {
        }

        public async Task<LeaveApprovalCreateResponseModel?> ApproveAsync(LeaveApprovalCreateRequestModel request)
        {
            return await PostAsync<LeaveApprovalCreateRequestModel, LeaveApprovalCreateResponseModel>("LeaveApproval/approve", request);
        }

        public async Task<LeaveApprovalListResponseModel?> GetAllAsync(int pageNo, int pageSize)
        {
            return await GetAsync<LeaveApprovalListResponseModel>($"LeaveApproval/list?pageNo={pageNo}&pageSize={pageSize}");
        }

        public async Task<LeaveApprovalDeleteResponseModel?> DeleteAsync(int id)
        {
            return await DeleteAsync<LeaveApprovalDeleteResponseModel>($"LeaveApproval/delete?approvalId={id}");
        }
    }
}

using IPB2.EmployeeLeaveMS.Domain.Features.Employees;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services
{
    public class EmployeeHttpClientService : BaseHttpClientService
    {
        public EmployeeHttpClientService(HttpClient httpClient, IConfiguration configuration) 
            : base(httpClient, configuration)
        {
        }

        public async Task<EmployeeCreateResponseModel?> CreateAsync(EmployeeCreateRequestModel request)
        {
            return await PostAsync<EmployeeCreateRequestModel, EmployeeCreateResponseModel>("Employee/create", request);
        }

        public async Task<EmployeeListResponseModel?> GetAllAsync(int pageNo, int pageSize)
        {
            return await GetAsync<EmployeeListResponseModel>($"Employee/list?pageNo={pageNo}&pageSize={pageSize}");
        }

        public async Task<EmployeeDetailResponseModel?> GetByIdAsync(int id)
        {
            return await GetAsync<EmployeeDetailResponseModel>($"Employee/detail?EmployeeId={id}");
        }

        public async Task<EmployeeEditResponseModel?> UpdateAsync(EmployeeEditRequestModel request)
        {
            return await PutAsync<EmployeeEditRequestModel, EmployeeEditResponseModel>("Employee/update", request);
        }

        public async Task<EmployeeDeleteResponseModel?> DeleteAsync(EmployeeDeleteRequestModel request)
        {
            return await DeleteWithBodyAsync<EmployeeDeleteRequestModel, EmployeeDeleteResponseModel>("Employee/delete", request);
        }
    }
}

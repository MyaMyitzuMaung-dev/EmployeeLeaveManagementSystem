using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.WebApi.Features.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeCreateRequestModel request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(int pageNo = 1, int pageSize = 10)
        {
            var request = new EmployeeListRequestModel
            {
                PageNumber = pageNo,
                PageSize = pageSize
            };

            var result = await _service.GetAllAsync(request);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EmployeeEditRequestModel request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(EmployeeDeleteRequestModel request)
        {
            var result = await _service.DeleteAsync(request);
            return Ok(result);
        }
    }
}

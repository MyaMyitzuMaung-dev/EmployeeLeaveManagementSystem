using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.WebApi.Features.LeaveTypes
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly LeaveTypeService _service;

        public LeaveTypeController(LeaveTypeService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(LeaveTypeCreateRequestModel request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(int pageNo = 1, int pageSize = 10)
        {
            var request = new LeaveTypeListRequestModel
            {
                PageNo = pageNo,
                PageSize = pageSize
            };

            var result = await _service.GetAllAsync(request);

            return Ok(result);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> Detail(int leaveTypeId)
        {
            var request = new LeaveTypeDetailRequestModel
            {
                LeaveTypeId = leaveTypeId
            };

            var result = await _service.GetByIdAsync(request);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(LeaveTypeUpdateRequestModel request)
        {
            var result = await _service.UpdateAsync(request);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int leaveTypeId)
        {
            var request = new LeaveTypeDeleteRequestModel
            {
                LeaveTypeId = leaveTypeId
            };

            var result = await _service.DeleteAsync(request);

            return Ok(result);
        }
    }
}
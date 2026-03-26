using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveRequests;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.WebApi.Features.LeaveRequests
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly LeaveRequestService _service;

        public LeaveRequestController(LeaveRequestService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(LeaveRequestCreateRequestModel request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(int pageNo = 1, int pageSize = 10)
        {
            var request = new LeaveRequestListRequestModel
            {
                PageNo = pageNo,
                PageSize = pageSize
            };
            var result = await _service.GetAllAsync(request);
            return Ok(result);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> Detail(int leaveRequestId)
        {
            var request = new LeaveRequestDetailRequestModel { LeaveRequestId = leaveRequestId };
            var result = await _service.GetByIdAsync(request);
            return Ok(result);
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(LeaveRequestUpdateStatusRequestModel request)
        {
            var result = await _service.UpdateStatusAsync(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int leaveRequestId)
        {
            var request = new LeaveRequestDeleteRequestModel { LeaveRequestId = leaveRequestId };
            var result = await _service.DeleteAsync(request);
            return Ok(result);
        }
    }
}

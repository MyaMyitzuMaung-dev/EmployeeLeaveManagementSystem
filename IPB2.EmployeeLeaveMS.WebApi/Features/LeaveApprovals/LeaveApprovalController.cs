using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveApprovals;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.WebApi.Features.LeaveApprovals
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveApprovalController : ControllerBase
    {
        private readonly LeaveApprovalService _service;

        public LeaveApprovalController(LeaveApprovalService service)
        {
            _service = service;
        }

        [HttpPost("approve")]
        public async Task<IActionResult> Approve(LeaveApprovalCreateRequestModel request)
        {
            var result = await _service.ApproveAsync(request);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(int pageNo = 1, int pageSize = 10)
        {
            var request = new LeaveApprovalListRequestModel
            {
                PageNo = pageNo,
                PageSize = pageSize
            };
            var result = await _service.GetAllAsync(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int approvalId)
        {
            var request = new LeaveApprovalDeleteRequestModel { ApprovalId = approvalId };
            var result = await _service.DeleteAsync(request);
            return Ok(result);
        }
    }
}

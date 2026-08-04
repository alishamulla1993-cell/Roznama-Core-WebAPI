using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roznama.Common.Constants;
using Roznama.Common.Responses;
using Roznama.Models.Notice;
using Roznama.Models.Notice.Models;

namespace Roznama.Modules.Notice
{
    [ApiController]

    public class NoticeController : ControllerBase
    {
        private readonly NoticeService _service;

        public NoticeController(NoticeService service)
        {
            _service = service;
        }

        // GET: api/v1/notice/detail/2
        [HttpGet(ApiRoutes.Notice.Detail)]
        [Authorize]   // JWT Protected
        public async Task<IActionResult> GetDetail([FromRoute] int NoticeOID)
        {
            var result = await _service.GetNoticeDetailAsync(NoticeOID);

            if (result == null)
                return NotFound(Messages.NoticeNotFound);

            return Ok(result);
        }

        // POST: api/v1/notice/summary
        /*[HttpPost(ApiRoutes.Notice.Summary)]
        public async Task<IActionResult> GetSummary([FromBody] NoticeFilterDto filter)
        {
            if (filter == null)
                return BadRequest("Invalid input");

            try
            {
                var result = await _service.GetSummaryAsync(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace,
                    receivedParams = filter
                });
            }
        }*/
        [HttpPost(ApiRoutes.Notice.Summary)]
        public async Task<IActionResult> GetSummary([FromBody] NoticeFilterDto filter)
        {
            if (filter == null)
                return BadRequest(Messages.InvalidInput);

            var result = await _service.GetSummaryAsync(filter);

            return Ok(ApiResponse<object>.Ok(result));
        }

        //[HttpPost(ApiRoutes.Notice.SummaryTotalCount)]
        //public async Task<IActionResult> GetNoticeSummaryTotalCount([FromBody] NoticeFilterDto filter)
        //{
        //    if (filter == null)
        //        return BadRequest("Invalid input");

        //    try
        //    {
        //        var result = await _service.GetNoticeSummaryTotalCount(filter);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new
        //        {
        //            message = ex.Message,
        //            inner = ex.InnerException?.Message,
        //            stack = ex.StackTrace,
        //            receivedParams = filter
        //        });
        //    }
        //}
        [HttpPost(ApiRoutes.Notice.SummaryTotalCount)]
        public async Task<IActionResult> GetNoticeSummaryTotalCount([FromBody] NoticeFilterDto filter)
        {
            if (filter == null)
                return BadRequest(Messages.InvalidInput);

            var result = await _service.GetNoticeSummaryTotalCount(filter);

            return Ok(ApiResponse<object>.Ok(result));
        }

        [HttpPost(ApiRoutes.Notice.SummaryInit)]
        public async Task<IActionResult> GetSummaryInit([FromBody] NoticeFilterDto filter)
        {
            if (filter == null) return BadRequest("Invalid input");

            var result = await _service.GetSummaryInitAsync(filter);
            return Ok(ApiResponse<NoticeSummaryInitResponse>.Ok(
                result,
                "Notice summary fetched"
            ));
        }


        [HttpPost("unitmembers/generate")]
        public async Task<IActionResult> Generate([FromBody] NoticeGenerateUnitMemberRequest request)
        {
            var result = await _service.GenerateUnitMembersAsync(request);
            return Ok(result);
        }

        [HttpPost("matterhandledby/generate")]
        public async Task<IActionResult> Generate(
            [FromBody] NoticeGenerateMatterHandledByRequest request)
        {
            var result = await _service.GenerateMatterHandledByAsync(request);
            return Ok(result);
        }

        [HttpPost("parties/generate")]
        public async Task<IActionResult> Generate(
            [FromBody] NoticeGeneratePartyRequest request)
        {
            var result = await _service.GeneratePartiesAsync(request);
            return Ok(result);
        }

        [HttpPost("oppositeparties/generate")]
        public async Task<IActionResult> Generate(
           [FromBody] NoticeGenerateOppositePartyRequest request)
        {
            var result = await _service.GenerateOppositePartiesAsync(request);
            return Ok(result);
        }

        [HttpPost("lawfirmadvocates/generate")]
        public async Task<IActionResult> Generate(
           [FromBody] NoticeGenerateLawFirmAdvocateRequest request)
        {
            var result = await _service.GenerateAsync(request);
            return Ok(result);
        }

        [HttpPost("counterlawfirmadvocates/generate")]
        public async Task<IActionResult> Generate(
            [FromBody] NoticeGenerateCounterLawFirmAdvocateRequest request)
        {
            var result = await _service.GenerateAsync(request);
            return Ok(result);
        }
    }
}
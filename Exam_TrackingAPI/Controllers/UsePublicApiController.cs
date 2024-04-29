using Exam.BusinessLogic.Interfaces;
using Exam.Models.Models.UsePublicApiModel;
using Exam_TrackingAPI.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Exam_TrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthorization]
    public class UsePublicApiController : ControllerBase
    {
        private readonly IUsePublicApiService _UsePublicApiService = null;

        public UsePublicApiController(IUsePublicApiService UsePublicApiService)
        {
            _UsePublicApiService = UsePublicApiService;
        }

        [HttpPost("Track")]
        public async Task<IActionResult> UsePublicApi([FromBody] UsePublicApiRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.emscode))
            {
                return BadRequest("Invalid request. Emscode is required.");
            }

            // Example personal token
            string personalToken = "GLD0C+PiJRMwLdKSFVBRZwMRU#X8GpS8VzBXW;I#J$V_XRMeIWKKVYM~NnY&ELF+CpSLV@HpR.LqZVJICrRuG=L$HWLcSHK_XQMv";

            // Use _trackApiService to get authentication token and track item
            string authToken = await _UsePublicApiService.GetAuthToken(personalToken);
            if (authToken != null)
            {
                // Track the item using the obtained authentication token
                var trackingResult = await _UsePublicApiService.TrackItem(authToken, request.emscode);

                // Check if the tracking result is not null
                if (trackingResult != null)
                {
                    // Return the tracking result
                    return Ok(trackingResult);
                }
                else
                {
                    // Return a bad request if the tracking result is null
                    return BadRequest("Failed to track item.");
                }
            }
            else
            {
                // Return a bad request if failed to obtain authentication token
                return BadRequest("Failed to obtain authentication token.");
            }
        }



    }
}

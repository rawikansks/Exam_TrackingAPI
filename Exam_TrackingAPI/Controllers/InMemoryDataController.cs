using Exam.BusinessLogic.Interfaces;
using Exam.Models.Models.InMemoryDataModel;
using Exam_TrackingAPI.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_TrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthorization]
    public class InMemoryDataController : ControllerBase
    {
        private readonly IInMemoryDataService _service;

        public InMemoryDataController(IInMemoryDataService service)
        {
            _service = service;
        }

        [HttpPost("addCustomerdata")]
        public IActionResult AddCusData([FromBody] InMemoryDataRequest input)
        {
            try
            {
                _service.AddCusData(input);
                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("addTrackingdata")]
        public IActionResult AddTrackData([FromBody] InMemoryDataTrackRequest input)
        {
            try
            {
                _service.AddTrackData(input);
                return Ok("Data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("AllDataCustomer")]
        public async Task<IActionResult> GetAllDataCus()
        {
            try
            {
                var data = await _service.GetAllDataCusAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("AllDataTracking")]
        public async Task<IActionResult> GetAllDataTrack()
        {
            try
            {
                var data = await _service.GetAllDataTrackAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("DataJoinTable")]
        public async Task<IActionResult> GetDataJoinTable()
        {
            try
            {
                var data = await _service.GetDataJoinTableAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}

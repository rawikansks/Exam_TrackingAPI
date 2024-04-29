using Exam.BusinessLogic.Interfaces;
using Exam.Models.Models.SortingDupInputModel;
using Exam_TrackingAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_TrackingAPI.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthorization]
    public class SortingDupController : ControllerBase
    {

        private readonly ISortingDupInputService _sortingDupInputService = null;
        public SortingDupController(ISortingDupInputService sortingDupInputService)
        {
           
            _sortingDupInputService = sortingDupInputService;
        }

        [HttpPost("SortingDup")]
        public List<SortingDupResponse> SortingDup(SortingDupRequest request)
        {
            return _sortingDupInputService.SortingDupInput(request);
        }

    }
}

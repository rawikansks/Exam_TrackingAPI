using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models.Models.SortingDupInputModel;
using Exam.Models.Models.UsePublicApiModel;

namespace Exam.BusinessLogic.Interfaces
{
    public interface IUsePublicApiService
    {

        List<UsePublicApiResponse> UsePublicApi(UsePublicApiRequest request);
        Task<string> GetAuthToken(string personalToken);
        Task<string> TrackItem(string authToken, string emscode);



    }


}

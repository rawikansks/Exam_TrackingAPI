using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models.Models.InMemoryDataModel;

namespace Exam.BusinessLogic.Interfaces
{
    public interface IInMemoryDataService
    {
        List<InMemoryDataResponse> InMemoryData(InMemoryDataRequest request);
        void AddCusData(InMemoryDataRequest input);
        void AddTrackData(InMemoryDataTrackRequest input);
        Task<IEnumerable> GetAllDataCusAsync();
        Task<IEnumerable> GetAllDataTrackAsync();
        Task<IEnumerable> GetDataJoinTableAsync();
        object AddCusData();
    }
}

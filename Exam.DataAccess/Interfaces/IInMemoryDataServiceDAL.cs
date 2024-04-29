using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models.Models.InMemoryDataModel;

namespace Exam.DataAccess.Interfaces
{
    public interface IInMemoryDataServiceDAL
    {
        void AddCusData(InMemoryDataRequest input);
        void AddTrackData(InMemoryDataTrackRequest input);

        Task<IEnumerable> GetAllDataCusAsync();
        Task<IEnumerable> GetAllDataTrackAsync();
        Task<IEnumerable> GetDataJoinTableAsync();

    }

}

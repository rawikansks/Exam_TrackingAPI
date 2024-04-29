using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.BusinessLogic.Interfaces;
using Exam.DataAccess.Interfaces;
using Exam.Models.Models.InMemoryDataModel;


namespace Exam.BusinessLogic.Services
{
    public class InMemoryDataServiceBLL : IInMemoryDataService
    {
        private readonly IInMemoryDataServiceDAL _dataService;

        public InMemoryDataServiceBLL()
        {
        }

        public InMemoryDataServiceBLL(IInMemoryDataServiceDAL dataService)
        {
            _dataService = dataService;
        }

        
        public void AddCusData(InMemoryDataRequest input)
        {
            
            _dataService.AddCusData(input);
        }

        public object AddCusData()
        {
            throw new NotImplementedException();
        }

        public void AddTrackData(InMemoryDataTrackRequest input)
        {
            _dataService.AddTrackData(input);
        }

        public async Task<IEnumerable> GetAllDataCusAsync()
        {
            return await _dataService.GetAllDataCusAsync();
        }

        public async Task<IEnumerable> GetAllDataTrackAsync()
        {
            return await _dataService.GetAllDataTrackAsync();
        }

        public async Task<IEnumerable> GetDataJoinTableAsync()
        {
            return await _dataService.GetDataJoinTableAsync();
        }

        public List<InMemoryDataResponse> InMemoryData(InMemoryDataRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

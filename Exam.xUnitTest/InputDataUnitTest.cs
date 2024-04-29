using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Exam.BusinessLogic.Interfaces;
using Exam.BusinessLogic.Services;
using Exam.Models.Models.InmemoryDataModel;
using Exam.Models.Models.InMemoryDataModel;
using Xunit;

namespace Exam.xUnitTest
{
    public class InputDataUnitTest
    {
        [Theory]
        [InlineData("AAA", "ABB", "0921187", "114 AAA", "E", "E1487844", 1)]
        public void Test_getData(string firstName, string surname, string telNum, string address, string type, string tracknum, int cId)
        {

            // Arrange 
            IInMemoryDataService inMemoryDataService = new InMemoryDataServiceBLL();
            var request = new InMemoryDataDTOResponse()
            {
                Id = cId,
                FirstName = firstName,
                Surname = surname,
                Address = address,
                TelNum = telNum,
                TrackingNum = tracknum,
                Type = type



            };

            // Act 
            var result = inMemoryDataService.GetDataJoinTableAsync();

            // Assert 
            Assert.True(result != null);

        }

        [Theory]
        [InlineData("", "", "0921187", "114 AAA", "", "", 1)]
        public void Test_getDataFalse(string firstName, string surname, string telNum, string address, string type, string tracknum, int cId)
        {

            // Arrange 
            IInMemoryDataService inMemoryDataService = new InMemoryDataServiceBLL();
            var request = new InMemoryDataDTOResponse()
            {
                Id = cId,
                FirstName = firstName,
                Surname = surname,
                Address = address,
                TelNum = telNum,
                TrackingNum = tracknum,
                Type = type


            };

            // Act 
            var result = inMemoryDataService.GetDataJoinTableAsync();

            // Assert 
            Assert.False(result == null);

        }
    }

}

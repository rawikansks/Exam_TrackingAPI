using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Exam.BusinessLogic.Interfaces;
using Exam.BusinessLogic.Services;
using Exam.Models.Models.SortingDupInputModel;
using Xunit;

namespace Exam.xUnitTest
{
    public class AuthenTokenUnitTest
    {
        private HttpClient _httpClient;

        public AuthenTokenUnitTest()
        {
            // Initialize _httpClient if needed
            _httpClient = new HttpClient();
        }


        [Theory]
        [InlineData("GLD0C+PiJRMwLdKSFVBRZwMRU#X8GpS8VzBXW;I#J$V_XRMeIWKKVYM~NnY&ELF+CpSLV@HpR.LqZVJICrRuG=L$HWLcSHK_XQMv")]
        public void Test_ApiAuthenSuccess(string input)
        {

            // Arrange 
            IUsePublicApiService usePublicApiService = new UsePublicApiServiceBLL(_httpClient);

            // Act 
            var result = usePublicApiService.GetAuthToken(input);

            // Assert 
            Assert.True(result != null);

        }


        [Theory]
        [InlineData("AAAAAAAAAAAAA")]
        public void Test_ApiAuthenFailed(string input)
        {

            // Arrange 
            IUsePublicApiService usePublicApiService = new UsePublicApiServiceBLL(_httpClient);

            // Act 
            var result = usePublicApiService.GetAuthToken(input);

            // Assert 
            Assert.False(result == null);

        }
    }
}

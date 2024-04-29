using Exam.BusinessLogic.Interfaces;
using Exam.BusinessLogic.Services;
using Exam.Models.Models.SortingDupInputModel;
using Xunit;

namespace Exam.xUnitTest
{
    public class SortingDupInputUnitTest
    {


        [Theory]
        [InlineData("A,B,1,2,1,AA,3,5,BB,4,2,4,AA,B")]
        [InlineData("1,2,1,3,5,4,2,4")]
        public void Test_Sort_CountMoreThanZero(string input)
        {

            // Arrange 
            ISortingDupInputService sortingDupInputService = new SortingDupInputServiceBLL();
            var request = new SortingDupRequest()
            {
                P1 = input
            };

            // Act 
            var result = sortingDupInputService.SortingDupInput(request);

            // Assert 
            Assert.True(result.Count() > 0);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_Sort_CountIsZero(string input)
        {

            // Arrange 
            ISortingDupInputService sortingDupInputService = new SortingDupInputServiceBLL();
            var request = new SortingDupRequest()
            {
                P1 = input
            };

            // Act 
            var result = sortingDupInputService.SortingDupInput(request);

            // Assert 
            Assert.False(result.Count() > 0);

        }
    }
}
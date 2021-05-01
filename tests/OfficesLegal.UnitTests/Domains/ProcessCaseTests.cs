using AutoBogus;
using Moq;
using OfficesLegal.Common;
using OfficesLegal.Domain.ProcessCases;
using System.Threading.Tasks;
using Xunit;

namespace OfficesLegal.UnitTests
{
    public class ProcessCaseTests
    {
        

        [Theory]
        [InlineData("1245848-45.2454.5.33.3434", false)]
        [InlineData("12458X8-45.2454.5.33.3434", true)]
        public void InvalidCaseNumberStandardFormat_WhenInformedCaseNumber_ShouldBeBooleanValidation(
            string caseNumber,            
            bool expectedResult)
        {
            //arrange
            var processCaseFaker = new AutoFaker<ProcessCase>().Generate();
            var processCase = new ProcessCase(caseNumber, processCaseFaker.CourtName, processCaseFaker.NameOfTheResponsible);

            //act
            var actualResult = processCase.InvalidCaseNumberStandardFormat();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

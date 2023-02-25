using System.Threading.Tasks;
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;
using Moq;
using Xunit;

namespace LiveExamSystemWebApp.UnitTests;

public class TestAnswerService
{
    [Fact]
    public async Task Get_ByAnswerIdAsync_OnSuccess()
    {
        var expected = new Answer();
        // Arrange
        var mockAnswerService = new Mock<IAnswerService>();

        mockAnswerService.Setup(service => service.GetByAnswerIdAsync(1)).Returns(System.Threading.Tasks.Task<LiveExamSystemWebApp.Core.Utilities.Result.IDataResult<LiveExamSystemWebApp.Entities.Concrete.Answer>>());

        // Act
        // var result = await 

        // Assert

    }
}
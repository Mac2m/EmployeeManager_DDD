using EmployeeManager.Api.Commands;
using EmployeeManager.Api.Handlers.Employee;
using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using EmployeeManager.Domain.Events.Employee;

namespace UnitTests.Application.Handlers;

public class CreateEmployeeCommandHandlerTests : UnitTestBase
{
    private readonly CreateEmployeeCommandHandler _employeeCommandHandler;

    public CreateEmployeeCommandHandlerTests()
    {
        _evidenceNumberGeneratorMock.Setup(e => e.GetNextAsync()).ReturnsAsync(1);

        _employeeCommandHandler = new CreateEmployeeCommandHandler(_employeeRepositoryMock.Object, _evidenceNumberGeneratorMock.Object, _publisherMock.Object);
    }

    [Fact]
    public async Task CreateEmployeeCommandHandler_CreateEmployeeHandle_Return_CreatedEmployee()
    {
        var employee = new Employee(Guid.NewGuid(), new EvidenceNumber(1), new Name("John Dee"), new Gender(1));
        _employeeRepositoryMock.Setup(x => x.SaveAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(employee);

        var result = await _employeeCommandHandler.Handle(new CreateEmployeeCommand(employee.Id, employee.Name.Value, (int)employee.Gender.Value), CancellationToken.None);
        
        _employeeRepositoryMock.Verify(x => x.SaveAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Once);
        _evidenceNumberGeneratorMock.Verify(x => x.GetNextAsync(), Times.Once);
        _publisherMock.Verify(x => x.Publish(It.IsAny<EmployeeCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
        Assert.NotNull(result.Number);
        Assert.Equal(employee.Id, result.Id);
        Assert.Equal(employee.Name.Value, result.Name.Value);
        Assert.Equal(employee.Gender.Value, result.Gender.Value);
        
    }
}
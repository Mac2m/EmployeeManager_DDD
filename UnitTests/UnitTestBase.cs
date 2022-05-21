using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using MediatR;

namespace UnitTests;

public class UnitTestBase
{
    internal readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new Mock<IEmployeeRepository>();
    internal readonly Mock<IEvidenceNumberGenerator> _evidenceNumberGeneratorMock = new Mock<IEvidenceNumberGenerator>();
    internal readonly Mock<IPublisher> _publisherMock = new Mock<IPublisher>();

    protected static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
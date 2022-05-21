namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public interface IEvidenceNumberGenerator
{
    Task<int> GetNextAsync();
}
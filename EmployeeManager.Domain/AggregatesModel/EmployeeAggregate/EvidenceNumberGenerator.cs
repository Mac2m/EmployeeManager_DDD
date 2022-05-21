namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public class EvidenceNumberGenerator : IEvidenceNumberGenerator

{
    private int _sequence = 0;
    public Task<int> GetNextAsync() => Task.FromResult(++_sequence);
}
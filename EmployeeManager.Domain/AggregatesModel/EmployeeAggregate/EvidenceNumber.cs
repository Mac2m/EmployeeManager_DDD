using EmployeeManager.Domain.SeedWork;

namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public class EvidenceNumber : ValueObject
{
    public string Value { get; }
    public EvidenceNumber(int sequence)
    {
        var input = sequence.ToString();

        if (input.Length > 8 || sequence < 0)
        {
            throw new Exception("Invalid sequence.");
        }
        Value = input.PadLeft(8, '0');
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
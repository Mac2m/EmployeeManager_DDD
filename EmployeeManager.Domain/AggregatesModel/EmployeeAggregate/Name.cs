using EmployeeManager.Domain.SeedWork;

namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public class Name : ValueObject
{
    public string Value { get; }
    public Name(string input)
    {
        if(input.Length < 1 && input.Length > 50)
        {
            throw new Exception("Name must be between 1 and 50 characters.");
        }
        Value = input;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
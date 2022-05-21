using System.ComponentModel;
using EmployeeManager.Domain.SeedWork;

namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public enum GenderEnum
{
    Female = 0,
    Male = 1
}

public class Gender : ValueObject
{
    public GenderEnum Value { get; }

    public Gender(int input)
    {
        if (!Enum.IsDefined(typeof(GenderEnum), input))
        {
            throw new InvalidEnumArgumentException("Invalid gender.");
        }

        Value = (GenderEnum)input;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
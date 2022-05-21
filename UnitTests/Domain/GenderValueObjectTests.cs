using System.ComponentModel;
using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

namespace UnitTests.Domain;

public class GenderValueObjectTests : UnitTestBase
{
    [Fact]
    public void GenderValueObject_IsCreatedWithMale_ReturnsMale()
    {
        var genderExpected = GenderEnum.Male;
        var gender = new Gender(1);

        Assert.Equal(genderExpected, gender.Value);
    }
    
    [Fact]
    public void GenderValueObject_IsCreatedWithFemale_ReturnsFemale()
    {
        var genderExpected = GenderEnum.Female;
        var gender = new Gender(0);

        Assert.Equal(genderExpected, gender.Value);
    }

    [Fact]
    public void GenderValueObject_IsNotCreatedWithIncorrectAggrement_ThrowsInvalidEnumArgumentException()
    {
        var gender = Assert.Throws<InvalidEnumArgumentException>(() => new Gender(3));
        
        Assert.Equal(typeof(InvalidEnumArgumentException), gender.GetType());
    }
}
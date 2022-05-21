using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

namespace UnitTests.Domain;

public class EmployeeDomainTests : UnitTestBase
{
    public static IEnumerable<object[]> CorrectData =>
        new List<object[]>
        {
            new object[] { Guid.NewGuid(), new EvidenceNumber(1), new Name(RandomString(6)), new Gender(1) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(2), new Name(RandomString(8)), new Gender(1) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(3), new Name(RandomString(4)), new Gender(0) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(4), new Name(RandomString(10)), new Gender(1) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(5), new Name(RandomString(5)), new Gender(0) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(6), new Name(RandomString(20)), new Gender(1) }
        };

    public static IEnumerable<object[]> IncorrectData =>
        new List<object[]>
        {
            new object[] { Guid.Empty, new EvidenceNumber(1), new Name(RandomString(6)), new Gender(0) },
            new object[] { Guid.NewGuid(), null, new Name(RandomString(6)), new Gender(1) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(3), null, new Gender(0) },
            new object[] { Guid.NewGuid(), new EvidenceNumber(4), new Name(RandomString(6)), null }
        };
    
    [Theory]
    [MemberData(nameof(CorrectData))]
    public void CreateEmployee_WithCorrectData_EmployeeIsCreatedSuccesfully(Guid id, EvidenceNumber number, Name name, Gender gender)
    {
        var employee = new Employee(id, number, name, gender);
        
        Assert.Equal(employee.Id, id);
        Assert.Equal(employee.Number, number);
        Assert.Equal(employee.Name, name);
        Assert.Equal(employee.Gender, gender);
    }
    
    [Theory]
    [MemberData(nameof(IncorrectData))]
    public void CreateEmployee_WithInCorrectData_EmployeeIsNotCreated_ThrowException(Guid id, EvidenceNumber number, Name name, Gender gender)
    {
        var employee = Assert.Throws<ArgumentNullException>(() => new Employee(id, number, name, gender));
        
        Assert.Equal(typeof(ArgumentNullException), employee.GetType());
    }

    [Theory]
    [MemberData(nameof(CorrectData))]
    public void UpdateEmployee_WithCorrectData_EmployeeIsUpdatedSuccesfully(Guid id, EvidenceNumber number, Name name,
        Gender gender)
    {
        var employee = new Employee(id, number, name, gender);
        var newName = new Name(RandomString(5));
        var newGender = new Gender(Random.Shared.Next(0, 1));
        
        employee.Update(newName, newGender);
        
        Assert.Equal(employee.Name, newName);
        Assert.Equal(employee.Gender, newGender);
    }

    [Theory]
    [MemberData(nameof(CorrectData))]
    public void UpdateEmployee_WithIncorrectNewData_ThrowsAnException(Guid id, EvidenceNumber number, Name name,
        Gender gender)
    {
        var employee = new Employee(id, number, name, gender);
        var employee2 = new Employee(id, number, name, gender);
        var employee3 = new Employee(id, number, name, gender);
        var newName = new Name(RandomString(5));
        var newGender = new Gender(Random.Shared.Next(0, 1));

        var exception = Assert.Throws<ArgumentNullException>(() => employee.Update(null, newGender));
        var exception2 = Assert.Throws<ArgumentNullException>(() => employee2.Update(newName, null));
        var exception3 = Assert.Throws<ArgumentNullException>(() => employee3.Update(null, null));
        
        Assert.Equal(typeof(ArgumentNullException), exception.GetType());
        Assert.Equal(typeof(ArgumentNullException), exception2.GetType());
        Assert.Equal(typeof(ArgumentNullException), exception3.GetType());
    }
}
using EmployeeManager.Domain.SeedWork;

namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public class Employee : Entity, IAggregateRoot
{
    public EvidenceNumber Number { get; private set; }
    public Name Name { get; private set; }
    public Gender Gender { get; private set; }
    
    public Employee(Guid id, EvidenceNumber number, Name name, Gender gender)
    {
        Id = id != default ? id : throw new ArgumentNullException("Id not specified.");
        Number = number is not null ? number : throw new ArgumentNullException("Number not specified.");
        Name = name is not null ? name : throw new ArgumentNullException("Name not specified.");
        Gender = gender is not null ? gender : throw new ArgumentNullException("Gender not specified.");
    }
    
    public Employee Update(Name name, Gender gender)
    {
        if(name is null || gender is null) 
            throw new ArgumentNullException("Name or Gender not specified.");

        Name = name;
        Gender = gender;
        return this;
    }
}
using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using MediatR;

namespace EmployeeManager.Domain.Events.Employee;

public class EmployeeCreatedEvent : INotification
{
    private readonly EvidenceNumber _number;
    private readonly Name _name;
    private readonly Gender _gender;

    public EmployeeCreatedEvent(EvidenceNumber number, Name name, Gender gender)
    {
        _number = number;
        _name = name;
        _gender = gender;
    }
}
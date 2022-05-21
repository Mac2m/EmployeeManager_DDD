using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using MediatR;

namespace EmployeeManager.Api.Commands;

public class CreateEmployeeCommand : IRequest<Employee>
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Gender { get; private set; }

    public CreateEmployeeCommand(Guid id, string name, int gender)
    {
        Id = id;
        Name = name;
        Gender = gender;
    }
}
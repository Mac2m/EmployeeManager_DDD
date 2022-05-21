using EmployeeManager.Api.Commands;
using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using EmployeeManager.Domain.Events.Employee;
using MediatR;

namespace EmployeeManager.Api.Handlers.Employee;

public class UpdateEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, Domain.AggregatesModel.EmployeeAggregate.Employee>
{
    private readonly IEmployeeRepository _repository;
    private readonly IPublisher _publisher;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IPublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }
    
    public async Task<Domain.AggregatesModel.EmployeeAggregate.Employee> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetAsync(request.Id, cancellationToken);
        employee.Update(new Name(request.Name), new Gender(request.Gender));

        var result = await _repository.SaveAsync(employee, cancellationToken);
        await _publisher.Publish(new EmployeeUpdatedEvent(result.Number, result.Name, result.Gender), cancellationToken);

        return result;
    }
}
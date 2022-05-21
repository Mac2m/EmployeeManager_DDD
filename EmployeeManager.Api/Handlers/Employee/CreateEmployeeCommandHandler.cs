using EmployeeManager.Api.Commands;
using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using EmployeeManager.Domain.Events.Employee;
using MediatR;

namespace EmployeeManager.Api.Handlers.Employee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Domain.AggregatesModel.EmployeeAggregate.Employee>
{
    private readonly IEmployeeRepository _repository;
    private readonly IEvidenceNumberGenerator _generator;
    private readonly IPublisher _publisher;
    
    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IEvidenceNumberGenerator generator, IPublisher publisher)
    {
        _repository = repository;
        _generator = generator;
        _publisher = publisher;
    }
    
    public async Task<Domain.AggregatesModel.EmployeeAggregate.Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var sequence = await _generator.GetNextAsync();
        var evidenceNumber = new EvidenceNumber(sequence);
        var name = new Name(request.Name);
        var gender = new Gender(request.Gender);
        var employee = new Domain.AggregatesModel.EmployeeAggregate.Employee(Guid.NewGuid(), evidenceNumber, name, gender);

        var result = await _repository.SaveAsync(employee, cancellationToken);
        await _publisher.Publish(new EmployeeCreatedEvent(result.Number, result.Name, result.Gender), cancellationToken);

        return result;
    }
}
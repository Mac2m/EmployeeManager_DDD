using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using EmployeeManager.Domain.SeedWork;

namespace EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
namespace EmployeeManager.Domain.SeedWork;

public interface IRepository<T> where T : IAggregateRoot
{
    Task<T> SaveAsync(T entity, CancellationToken cancellationToken = default);
}
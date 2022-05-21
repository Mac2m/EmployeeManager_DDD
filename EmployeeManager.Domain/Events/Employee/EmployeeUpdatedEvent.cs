using EmployeeManager.Domain.AggregatesModel.EmployeeAggregate;
using MediatR;

namespace EmployeeManager.Domain.Events.Employee;

public record EmployeeUpdatedEvent(EvidenceNumber Number, Name Name, Gender Gender) : INotification;
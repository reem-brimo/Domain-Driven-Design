using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuAggregate.Events;

public record MenuCreated (Menu Menu): IDomainEvent;
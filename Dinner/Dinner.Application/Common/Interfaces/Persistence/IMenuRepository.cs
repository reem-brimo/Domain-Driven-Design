using Dinner.Domain.MenuAggregate;

namespace Dinner.Application.Common.interfaces.Presistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}
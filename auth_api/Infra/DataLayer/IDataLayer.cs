using System.Data;
using auth_api.Infra.ValueObj;

namespace auth_api.Infra.DataLayer;

public interface IDataLayer: IDisposable
{
    IEnumerable<IValueObj> GetAll();
    void Persist(IValueObj data);
}
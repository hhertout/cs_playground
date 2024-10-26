namespace auth_api.Infra.DataLayer;

public interface IDataLayer<T> : IDisposable
{
    IEnumerable<T> GetAll();
    void Persist(T data);
}
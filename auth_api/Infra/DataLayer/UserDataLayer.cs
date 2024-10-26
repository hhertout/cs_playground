using auth_api.Config;
using auth_api.Infra.Entity;
using auth_api.Infra.Repository;

namespace auth_api.Infra.DataLayer;

public class UserDataLayer: IDataLayer<UserEntity>
{
    private readonly PostgresContext _context;
    private UserRepository Repository { get; }

    public UserDataLayer(PostgresContext context)
    {
        _context = context;
        Repository = new UserRepository(_context);
    }
    
    public IEnumerable<UserEntity> GetAll()
    {
        return Repository.GetAll();
    }

    public void Persist(UserEntity user)
    {
        Repository.Save(user);
    }

    void IDisposable.Dispose()
    {
        _context.Dispose();
    }
}
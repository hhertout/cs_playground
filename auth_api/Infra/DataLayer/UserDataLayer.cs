using auth_api.App.Jwt;
using auth_api.Config;
using auth_api.Infra.Entity;
using auth_api.Infra.Repository;
using auth_api.Infra.ValueObj;

namespace auth_api.Infra.DataLayer;

public class UserDataLayer: IDataLayer
{
    private readonly PostgresContext _context;
    private UserRepository Repository { get; }

    public UserDataLayer(PostgresContext context)
    {
        _context = context;
        Repository = new UserRepository(_context);
    }
    
    public IEnumerable<IValueObj> GetAll()
    {
        return Repository.GetAll().Select(user => new GetUsersValueObj(user.Email, user.Password));
    }

    public void Persist(IValueObj data)
    {
        if (data is CreateUserValueObj user)
        {
            var hash = new HashingService().Hash(user.Password);
            Repository.Save(new UserEntity(user.Email, hash));
        }
        else
        {
            throw new ApplicationException("data is not a UserValueObj");
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
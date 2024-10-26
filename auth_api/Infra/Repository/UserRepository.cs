using auth_api.Config;
using auth_api.Infra.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace auth_api.Infra.Repository;

public class UserRepository(PostgresContext context)
{
    public IEnumerable<UserEntity> GetAll()
    {
        return context.Users;
    }

    public UserEntity? GetById(string uid)
    {
        return context.Users.FirstOrDefault(u => u.Uid == uid);
    }

    public void Save(UserEntity user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
}
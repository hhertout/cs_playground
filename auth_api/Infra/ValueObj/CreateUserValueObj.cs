namespace auth_api.Infra.ValueObj;

public record CreateUserValueObj(string Email, string Password) : IValueObj
{ }
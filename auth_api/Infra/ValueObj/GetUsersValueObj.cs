namespace auth_api.Infra.ValueObj;

public record GetUsersValueObj(string Email, string Password): IValueObj
{}
namespace Todo.Application.Service.Interface
{
    public interface IIdentityService
    {
        long GetUserIdentity();
        string GetUserEmail();
    }
}
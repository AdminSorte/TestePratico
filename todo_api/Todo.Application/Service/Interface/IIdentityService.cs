namespace Todo.Application.Service.Interface
{
    public interface IIdentityService
    {
        int GetUserIdentity();
        string GetUserEmail();
    }
}
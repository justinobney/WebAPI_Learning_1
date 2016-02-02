namespace WebAPI_Learning_1.Interfaces
{
    public interface IAuthorizer<in TRequest>
    {
        bool Authorize(TRequest message);
    }
}
namespace IdentityApp.Caching
{
    public interface ICacheService
    {
        void Set(string key, string value);
    }
}
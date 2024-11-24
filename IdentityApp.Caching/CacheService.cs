namespace IdentityApp.Caching
{
    public class CacheService : ICacheService
    {
        public void Set(string key, string value)
        {
            Console.WriteLine($"key:{key}, value:{value}");
        }
    }
}
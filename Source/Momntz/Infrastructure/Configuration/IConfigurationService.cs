namespace Momntz.Infrastructure.Configuration
{
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the value by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        string GetValueByKey(string key);
    }
}
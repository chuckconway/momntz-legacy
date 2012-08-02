namespace Momntz.Infrastructure.Security
{
    public interface ICrypto
    {
        string Hash(string password);
        bool IsMatch(string password, string hashedPassword);
    }
}
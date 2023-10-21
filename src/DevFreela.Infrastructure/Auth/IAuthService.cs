namespace DevFreela.Infrastructure.Auth
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
        string GenerateJwtToken(string email, string role);
    }
}
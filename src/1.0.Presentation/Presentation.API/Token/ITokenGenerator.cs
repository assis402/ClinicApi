using Domain.Entities;

namespace Presentation.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}

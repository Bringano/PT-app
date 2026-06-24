using PTApp.Domain.Entities; 

namespace PTApp.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user); 
}
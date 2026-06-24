using PTApp.Application.Interfaces;
using PTApp.Domain.Entities;
using PTApp.Domain.Enums;


namespace PTApp.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception($"User with id {id} not found");
        }

        return user;
    }

    public async Task<User> RegisterUserAsync(string firstName, string lastName, string email, string password, UserRole role)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User(firstName, lastName, email, passwordHash, role);

        await _userRepository.AddAsync(user);

        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash); 
    }
}
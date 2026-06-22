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

    public async Task RegisterUserAsync(string firstName, string lastName, string email, string password)
    {   
        var passwordHash = $"HASHED_{password}"; 

        var user = new User(firstName, lastName, email, passwordHash, UserRole.Client); 

        await _userRepository.AddAsync(user); 
    }
}
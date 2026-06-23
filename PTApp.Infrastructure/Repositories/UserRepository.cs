using Microsoft.EntityFrameworkCore;
using PTApp.Application.Interfaces;
using PTApp.Domain.Entities;
using PTApp.Infrastructure.Data;

namespace PTApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext; 
    }
    public async Task AddAsync(User user)
    {
        _appDbContext.Users.Add(user); 
        await _appDbContext.SaveChangesAsync(); 
     
    }

    public async Task DeleteAsync(Guid id)
    {   
        var user = await _appDbContext.Users.FindAsync(id); 

        if (user != null)
        {
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }
        
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email); 
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _appDbContext.Users.FindAsync(id); 
    }
}
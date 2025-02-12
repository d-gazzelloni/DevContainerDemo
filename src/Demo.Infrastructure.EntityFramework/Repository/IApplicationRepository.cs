using Demo.Infrastructure.EntityFramework.Context;
using Demo.Infrastructure.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.EntityFramework.Repository;

public interface IApplicationRepository
{
    Task<IReadOnlyList<User>> GetUsersAsync();
}

public class ApplicationRepository : IApplicationRepository
{
    private readonly AppDbContext _dbContext;

    public ApplicationRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<User>> GetUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }
    
}
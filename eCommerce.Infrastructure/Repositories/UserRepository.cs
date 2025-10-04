using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        return new ApplicationUser()
        { 
            UserID = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Test User",
            Gender = GenderOptions.Male.ToString()
        };
    }
}

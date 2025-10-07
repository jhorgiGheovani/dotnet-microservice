﻿using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        //SQL Query
        string query = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES (@UserID, @Email, @PersonName, @Gender, @Password)";
        int rowCountAffected =  await _dbContext.GetConnection().ExecuteAsync(query, user);
        
        if(rowCountAffected > 0)
        {
            return user;
        }else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {

        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\"=@Password";

        ApplicationUser user = await _dbContext.GetConnection().QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });


        return user;
    }
}

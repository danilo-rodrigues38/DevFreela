﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implemantations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create ( CreateUserInputModel inputmodel )
        {
            var user = new User(inputmodel.FullName, inputmodel.Email, inputmodel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges ( );

            return user.Id;
        }

        public UserViewModel GetUser ( int id )
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if ( user == null )
            {
                return null;
            }

            return new UserViewModel ( user.FullName, user.Email );
        }
    }
}

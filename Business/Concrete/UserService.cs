using Business.Abstract;
using Common.Settings;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Get(string username, string password)
        {
            return _repository.GetUser(username, password);
        }
    }
}

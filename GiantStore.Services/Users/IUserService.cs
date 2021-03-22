using GiantStore.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiantStore.Services.Users
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetByEmail(string email);
    }
}

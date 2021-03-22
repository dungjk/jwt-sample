using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GiantStore.Entity.Entities;

namespace GiantStore.Services.Users
{
    class UserService : IUserService
    {
        private IList<User> _listUsers = new List<User>
        {
           new User{
                Id = new Guid( "72de3e48-4c34-463f-832e-3422b8947b46"),
                Email =  "test@gmail.com",
                FirstName = "Buckner",
                LastName = "Martinez",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2014-06-26T12:14:17 -07:00"),
                Modified =  DateTimeOffset.Parse("2014-01-10T11:38:34 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "775a0022-a918-4e6a-a46c-d4ffb8d6f27e"),
                Email =  "bucknermartinez@lunchpod.com",
                FirstName = "Francine",
                LastName = "Leon",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2014-10-06T10:49:27 -07:00"),
                Modified = DateTimeOffset.Parse("2014-01-23T11:11:56 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "79eaf68d-d22e-45ae-94a8-8c4f59f55271"),
                Email =  "francineleon@lunchpod.com",
                FirstName = "Ana",
                LastName = "Huff",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2014-09-02T06:37:19 -07:00"),
                Modified = DateTimeOffset.Parse("2016-12-19T12:29:16 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "97f7083c-b7b8-4b66-b4e4-a9a3ac5c95e1"),
                Email =  "anahuff@lunchpod.com",
                FirstName = "Lindsey",
                LastName = "Velez",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2016-12-11T06:48:04 -07:00"),
                Modified = DateTimeOffset.Parse("2018-01-31T08:38:15 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "8c659b11-1464-43d6-b00e-454ba0f2745d"),
                Email =  "lindseyvelez@lunchpod.com",
                FirstName = "Goldie",
                LastName = "Barrera",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2016-03-24T10:01:44 -07:00"),
                Modified = DateTimeOffset.Parse("2020-06-12T11:56:53 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "1701cd3e-e66d-4e3d-8ef9-c6374cf62982"),
                Email =  "goldiebarrera@lunchpod.com",
                FirstName = "Shawn",
                LastName = "Valdez",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2019-12-23T07:19:55 -07:00"),
                Modified = DateTimeOffset.Parse("2015-06-29T06:24:05 -07:00"),
                Status =  1
            },
            new User{
                Id = new Guid( "932be7c3-4f45-4567-af22-c61b963e1440"),
                Email =  "shawnvaldez@lunchpod.com",
                FirstName = "Mayra",
                LastName = "Pierce",
                Password = "123456789",
                Created =  DateTimeOffset.Parse("2014-06-07T12:41:00 -07:00"),
                Modified = DateTimeOffset.Parse("2019-07-24T08:34:41 -07:00"),
                Status =  1
            }
        };
        public IEnumerable<User> GetAll()
        {
            return _listUsers;
        }

        public User GetByEmail(string email)
        {
            return _listUsers.FirstOrDefault(it => string.Equals(it.Email, email, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

using AutoMapper;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Entities.TestDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Services
{
    public interface IUserService
    {
        UserDto.User GetUser(int id);

        UserDto.User AddUser(UserDto.User user);

        UserDto.User DeleteUser(int id);
    }

    public class UserService : IUserService
    {

        private TestDbContext _testDbContext;

        private IMapper _mapper;

        public UserService(TestDbContext testDbContext, IMapper mapper)
        {
            _testDbContext = testDbContext;
            _mapper = mapper;
        }

        public UserDto.User AddUser(UserDto.User user)
        {
            try
            {
                Users users = _mapper.Map<Users>(user);

                _testDbContext.Users.Add(users);
                _testDbContext.SaveChanges();

                return _mapper.Map<UserDto.User>(users);
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public UserDto.User DeleteUser(int id)
        {
            Users users = _testDbContext.Users.Where(w => w.Id == id).FirstOrDefault();

            if (users == null)
                return null;

            _testDbContext.Users.Remove(users);
            _testDbContext.SaveChanges();

            return _mapper.Map<UserDto.User>(users);
        }

        public UserDto.User GetUser(int id)
        {
            Users users = _testDbContext.Users.Where(w => w.Id == id).FirstOrDefault();

            return _mapper.Map<UserDto.User>(users);
        }
    }
}

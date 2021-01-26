using dotnet_core_xunit.Dtos;
using System;
using Xunit;

namespace dotnet_core_xunit_test.Theory
{
    public class UserTheoryData: TheoryData<UserDto.User>
    {
        public UserTheoryData()
        {
            /**
             * Each item you add to the TheoryData collection will try to pass your unit test's one by one.
             */

            // mock data created by https://barisates.github.io/pretend
            Add(new UserDto.User()
            {
                Email = "yft97l",
                CreateDate = DateTime.Now,
                FullName = "8s0quo",
                Id = 210544,
                Password = "d87btl",
                LastLogin = DateTime.Now,
                Status = true,
            });
        }
    }
}

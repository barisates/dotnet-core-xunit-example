using System;

namespace dotnet_core_xunit.Dtos
{
    public class UserDto
    {
        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public DateTime LastLogin { get; set; }
            public DateTime CreateDate { get; set; }
            public bool Status { get; set; }
        }

    }
}
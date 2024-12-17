using Library.Instruments.Enumerations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Instruments.Dto
{
    public class User
    {
        public readonly int Id;
        [Key] public string Login;
        public string Password;
        public UserConditionEnum Role;


        public User(int id, string login, string password, UserConditionEnum role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}

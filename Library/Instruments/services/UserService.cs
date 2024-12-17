using Library.Instruments.DataBase;
using Library.Instruments.Dto;
using Microsoft.EntityFrameworkCore;

namespace Library.Instruments.services
{
    public class UserService
    {
        public static async Task<User> GetByLogin(string login)
        {
            using (UserDb db = new UserDb())
            {
                return await db.Users.FirstOrDefaultAsync(x => x.Login == login);
            }
        }
    }
}

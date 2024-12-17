using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Library.Instruments.jwt
{
    public class JwtOptions
    {
        
        public const string ISSUER = "VavilonLibraryInc"; // издатель токена
        public const string AUDIENCE = "Anchous"; // потребитель токена
        const string KEY = "UlibokTebeDedMakarDorogoiMoiDrugNuTiILoh";   // ключ для шифрации
        public const int LIFETIME = 5760; // время жизни токена - 4 дня
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey (Encoding.ASCII.GetBytes(KEY));
        }
        
    }
}

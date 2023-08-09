using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper                //JSON Web Token'larımızı oluşturduğumuz alan
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
// Credential -->  Bir sisteme girmek için kullanıcı adı ve şifre gibi elimizde olan bilgilere denir. Yani giriş bilgilerine 

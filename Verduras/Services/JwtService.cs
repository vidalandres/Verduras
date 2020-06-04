using Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Verduras.Config;
using Verduras.Models;

namespace Verduras
{
    public class JwtService
    {
    private readonly AppSetting _appSettings;
    public JwtService(IOptions<AppSetting> appSettings) => _appSettings = appSettings.Value;
    public LogViewModel GenerateToken(User userLogIn)
    {
        // return null if user not found
        if (userLogIn == null) return null;
        var userResponse = new LogViewModel() { 
            FirstName = userLogIn.FirstName, 
            LastName = userLogIn.LastName, 
            UserName = userLogIn.UserName,
            Estado = userLogIn.Estado,
            Email = userLogIn.Email,
            MobilePhone = userLogIn.MobilePhone
        };
        // authentication successful so generate jwt token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userLogIn.UserName.ToString()),
                    new Claim(ClaimTypes.Email, userLogIn.Email.ToString()),
                    new Claim(ClaimTypes.MobilePhone, userLogIn.MobilePhone.ToString()),
                    //new Claim(ClaimTypes.Role, "Rol1"),
                    //new Claim(ClaimTypes.Role, "Rol2"),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Role, "Usuario"),
                }
            ),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        userResponse.Token = tokenHandler.WriteToken(token);
        return userResponse;
        }
    }
}
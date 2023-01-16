using EduHome.Buisness.DTIOs.Auth;
using EduHome.Buisness.Services.Interfaces;
using EduHome.Core.Entities;
using EduHome.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Services.implementations;

public class AuthService:IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration   _configuration;


    public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }


    public async Task RegisterAsync(RegisterDTO registerDTO)
    {
        AppUser user = new()
        {
            Fullname= registerDTO.Fullname,
            Email= registerDTO.Email,
            UserName= registerDTO.UserName,
        };
        var identityresult= await _userManager.CreateAsync(user,registerDTO.Password);
        if (!identityresult.Succeeded)
        {
            string errors=string.Empty;
            int count = 0;
            foreach (var error in identityresult.Errors)
            {
                errors += count != 0 ? $",{error.Description}" : $"{error.Description}";
                count++;
            }
        }
        await _userManager.AddToRoleAsync(user,Roles.Member.ToString());
    }
    
    public async Task<TokenResponseDTO> Login(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByNameAsync(loginDTO.Username);
        if (user == null) throw new Exception();
        var check= await _userManager.CheckPasswordAsync(user,loginDTO.Password);
        if(!check) {  throw new Exception(); }

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
        };
        var roles=await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

        SigningCredentials signingCredentials=new(securityKey,SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityTokenjwtToken = new JwtSecurityToken(

                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials:signingCredentials

            ) ;
        JwtSecurityTokenHandler tokenHandler = new();
        string token=tokenHandler.WriteToken(jwtSecurityTokenjwtToken);

        return new()
        {
            Token = token,
            UserName = user.UserName,
            Expires = jwtSecurityTokenjwtToken.ValidTo
        };

    }

  
}

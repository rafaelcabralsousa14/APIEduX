using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using APIEduX.Domains;
using APIEduX.DTO;
using APIEduX.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
            private IConfiguration _config;
            private iConta _contaRepositorio;

            public AccountController(IConfiguration config, iConta contaRepositorio)
            {
                _config = config;
                _contaRepositorio = contaRepositorio;
            }

            [AllowAnonymous]
            [HttpPost("login")]
            public IActionResult Login(Login login)
            {
                var user = _contaRepositorio.Login(login.Email, login.Senha);
                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    return Ok(new { token = tokenString });
                }

                return NotFound();
            }

            [AllowAnonymous]
            [HttpPost("register")]
            public IActionResult Register(Register register)
            {
                try
                {
                    var usuario = _contaRepositorio.Register(register.Nome, register.Email, register.Senha, "Comum");
                    if (usuario != null)
                    {
                        var tokenString = GenerateJSONWebToken(usuario);
                        return Ok(new { token = tokenString });
                    }

                    return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


            private string GenerateJSONWebToken(Usuarios userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Tipo),
                new Claim("role", userInfo.Tipo),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.IdUsuario.ToString())
            };

                var token = new JwtSecurityToken
                    (
                        _config["Jwt:Issuer"],
                        _config["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
}

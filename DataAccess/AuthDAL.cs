using BE_ConsilierInteligent.DataAccess.Exceptions;
using BE_ConsilierInteligent.DataAccess.Persistence;
using ConsilierBackUP.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace BE_ConsilierInteligent.DataAccess
{
    public class AuthDAL : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthDAL(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult checkLogin(string username, string password)
        {
            try
            {
                var _context = new ConsilierContext();
                var user = _context.Utilizator.FirstOrDefault(s => s.username.Equals(username) && s.parola.Equals(password));

                if (user == null)
                {
                    throw new InvalidCredentialsException();
                }

                var response = new LoginResponse
                {
                    Nume = user.nume,
                    Prenume = user.prenume,
                    Username = user.username
                };

                var student = _context.Elev.Any(s => s.id_utilizator.Equals(user.id_utilizator));
                var profesor = _context.Consilier.Any(s => s.id_utilizator.Equals(user.id_utilizator));

                if (student)
                {
                    response.Rol = "Elev";
                }
                else if (profesor)
                {
                    response.Rol = "Consilier";
                }

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, user.username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bhVKdNGTGzz0GPHobhfTClspFJF0arTUGh8uDsBXqmc="));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Tokens:Issuer"],
                    audience: _config["Tokens:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(12),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    Name = response.Nume,
                    Surname = response.Prenume,
                    Role = response.Rol,
                    Username = response.Username
                });
            }
            catch (InvalidCredentialsException)
            {
                return BadRequest(new { message = "Login or password are incorrect" });
            }
            catch (Exception ex)
            {
                // logger.LogError(ex, "An unexpected error occurred during authentication.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

    }
}


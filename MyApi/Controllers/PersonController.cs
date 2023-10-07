using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApi.BL.Person;
using MyApi.Transversal.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IBlPerson service;
        private readonly CustomSettings settings;
        public PersonController(IBlPerson service, CustomSettings settings)
        {
            this.service = service;
            this.settings = settings;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(BePerson objUsuario)
        {
            var usuario = await service.Login(objUsuario);
            if (!usuario.Status)
                return BadRequest(usuario);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, usuario.Data.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{usuario.Data.Name} {usuario.Data.FirstSurname} {usuario.Data.SecondSurname}")
            };

            // var claimsIdentity = new ClaimsIdentity(claims);
            // var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtKey)), SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(
                issuer: settings.JwtAudience,
                audience: settings.JwtIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            usuario.Data.Token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return Ok(usuario);
        }
    }
}
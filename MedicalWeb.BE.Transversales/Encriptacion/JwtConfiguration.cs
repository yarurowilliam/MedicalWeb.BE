using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalWeb.BE.Transversales.Encriptacion
{
    internal class JwtConfiguration
    {
		public static string GetToken(Usuario usuarioInfo, IConfiguration config)
		{
			string SecretKey = config["Jwt:SecretKey"];
			string Issuer = config["Jwt:Issuer"];
			string Audience = config["Jwt:Audience"];

			var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
			var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, usuarioInfo.NombreUsuario),
				new Claim("idUsuario", usuarioInfo.Identificacion.ToString()),
				new Claim("rolId", usuarioInfo.RolId.ToString())
			};

			var token = new JwtSecurityToken(
				issuer: Issuer,
				audience: Audience,
				claims,
				expires: DateTime.Now.AddMinutes(10),
				signingCredentials: credentials

				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public static int GetTokenIdUsuario(ClaimsIdentity identity)
		{
			if (identity != null)
			{
				IEnumerable<Claim> claims = identity.Claims;
				foreach (var claim in claims)
				{
					if (claim.Type == "idUsuario")
					{
						return int.Parse(claim.Value);
					}
				}
			}
			return 0;
		}
	}
}

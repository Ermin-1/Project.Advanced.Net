using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthentitactorController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthentitactorController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin userLogin)
    {
        if (userLogin == null)
        {
            return BadRequest("Invalid client request");
        }

        var role = string.Empty;

        if (userLogin.Username == "admin" && userLogin.Password == "adminpassword")
        {
            role = "Admin";
        }
        else if (userLogin.Username == "user" && userLogin.Password == "userpassword")
        {
            role = "User";
        }
        else if (userLogin.Username == "company" && userLogin.Password == "companypassword")
        {
            role = "Company";
        }
        else
        {
            return Unauthorized();
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userLogin.Username),
            new Claim(ClaimTypes.Role, role)
        };

        var tokeOptions = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])),
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return Ok(new { Token = tokenString });
    }
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}

using MagicApartment_HousingAPI.Data;
using MagicApartment_HousingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

[Authorize]
[Route("api/Yahoo")]
[ApiController]

public class YahooController : ControllerBase
{
    private readonly ApartmentDBContext _dbContext; 

    private IConfiguration _config;
    public YahooController(IConfiguration config, ApartmentDBContext dbContext)
    {
        _config = config;
        _dbContext = dbContext;

    }

    [HttpPost]
    public IActionResult checkLoginCredentials([FromBody] Login loginRequest)
    {
        var user = _dbContext.Users.FirstOrDefault( u => u.username == loginRequest.username && u.password == loginRequest.password);
        if(user == null)
        {
            return Unauthorized();
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(_config["JwtSettings:Issuer"],
          _config["JwtSettings:Issuer"],
          null,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

        return Ok(token);
    }

}
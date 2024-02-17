using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



[Authorize]
[Route("api/Yahoo")]
[ApiController]

public class YahooController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> sayYahoo()
    {
        return Ok("Yahoo");
    } 
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SafariVacation.Models;


namespace SafariVacation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController
  {
    // We wanna do a GET to /api/search?query=Lions
    [HttpGet]
    public ActionResult<string> GetAllAnimals([FromQuery] string query)
    {
      return query;
    }

  }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SafariVacation.Models;

namespace SafariVacation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAllAnimals()
    {
      return new List<Animal> { new Animal { Species = "rat" }, new Animal { Species = "tiger" } };

    }
    // [HttpGet("{id}")]
    // public ActionResult<Animal> GetAnSingleAnimal(int id)
    // {
    //   //TODO: query the database
    //   //return the result
    // }

    // [HttpPost]
    // public ActionResult<Animal> CreateAnimal([FromBody] Animal animalToAdd)
    // {
    //   return new Animal
    //   {
    //     Species = animalToAdd.Species
    //   };
    //   //TODO: query the database
    //   //return the result
    // }
  }
}
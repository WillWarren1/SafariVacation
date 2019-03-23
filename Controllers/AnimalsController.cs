using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SafariVacation.Models;
using System.Linq;
using safarivacation;


namespace SafariVacation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private DatabaseContext db;

    public AnimalsController()
    {
      this.db = new DatabaseContext();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAllAnimals()
    {
      var animals = db.Animals.OrderBy(o => o.Species).ToList();
      return animals;

    }
    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnSingleAnimal(int id)
    {
      //TODO: query the database
      //return the result
      //      var results = db
      //         .Movies
      //         .Where(w => w.IsActive)
      //         .OrderBy(o => o.Title)
      //         .Select(s => new MovieViewModel
      //         {
      //           Title = s.Title,
      //           Rating = s.Rating,
      //           Director = s.Director,
      //           Id = s.Id
      //         })
      //         .ToList();
      //   return results;
      var animal = db.Animals.FirstOrDefault(theAnimal => theAnimal.Id == id);
      return animal;
    }

    [HttpPost]
    public ActionResult<Animal> CreateAnimal([FromBody] Animal animalToAdd)
    {

      db.Animals.Add(animalToAdd);
      db.SaveChanges();
      return animalToAdd;
    }

    [HttpPut("{id}")]
    public ActionResult<Animal> UpdateAnimal(int id, [FromBody] Animal addToAnimal)
    {

      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      animal.Species = addToAnimal.Species;
      animal.CountOfTimesSeen = addToAnimal.CountOfTimesSeen;
      animal.LocationOfLastSeen = addToAnimal.LocationOfLastSeen;
      db.SaveChanges();
      return animal;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
      var animal = db.Animals.FirstOrDefault(a => a.Id == id);
      db.Animals.Remove(animal);
      db.SaveChanges();
      return Ok();
    }

  }
}
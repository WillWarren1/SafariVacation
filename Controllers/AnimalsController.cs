using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SafariVacation.Models;
using System.Linq;
using safarivacation;
using System;


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
      var animal = db.Animals.FirstOrDefault(theAnimal => theAnimal.Id == id);
      return animal;
    }

    [HttpGet("location={location}")]
    public ActionResult<IList<Animal>> GetAnimalsByLocation(string location)
    {
      var animalsByLocation = db.Animals.Where(animal => animal.LocationOfLastSeen == location).ToList();
      return animalsByLocation;
    }


    [HttpPost]
    public ActionResult<Animal> CreateAnimal([FromBody] Animal animalToAdd)
    {

      db.Animals.Add(animalToAdd);
      db.SaveChanges();
      return animalToAdd;
    }

    [HttpPut("{id}")]
    // , [FromBody] Animal addToAnimal
    public ActionResult<Animal> UpdateAnimal(int id)
    {

      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      animal.CountOfTimesSeen++;
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
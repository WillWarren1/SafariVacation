
using System;
using System.Collections.Generic;


namespace SafariVacation.Models
{
  public class Animal
  {

    public int Id { get; set; }
    public string Species { get; set; }
    public int CountOfTimesSeen { get; set; }
    public string LocationOfLastSeen { get; set; }

  }
}
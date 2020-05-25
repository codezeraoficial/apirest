using System;

namespace apirest.Models
{
  public class Student
  {

    public Student()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
  }
}
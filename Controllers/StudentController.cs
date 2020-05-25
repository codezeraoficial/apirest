using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apirest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apirest.Controllers
{
  [Route("api/student")]
  [ApiController]
  public class StudentController : Controller
  {
    private readonly StudentContext _context;

    public StudentController(StudentContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
      var students = await _context.Students.ToListAsync();
      return Ok(students);
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetById(Guid Id)
    {
      var student = await _context.Students.FindAsync(Id);
      return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Student>>> Post(Student student)
    {
      _context.Students.Add(student);

      await _context.SaveChangesAsync();

      return Ok(student);
    }


    [HttpPut("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Student>>> Update(Guid id, Student student)
    {
      if (id != student.Id)
      {
        return BadRequest();
      }

      _context.Entry(student).State = EntityState.Modified;

      await _context.SaveChangesAsync();

      return Ok(student);

    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<Student>>> Delete(Guid id)
    {
        var student = await _context.Students.FindAsync(id);

        if(student == null)
            return NotFound();
        
        _context.Students.Remove(student);

        await _context.SaveChangesAsync();

        return Ok(student);
    }

    ~StudentController()
    {
        _context.Dispose();
    }

  }
}
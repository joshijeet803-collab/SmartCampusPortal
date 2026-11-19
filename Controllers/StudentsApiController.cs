using Microsoft.AspNetCore.Mvc;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsApiController : ControllerBase
    {
        private readonly CampusDb db;

        public StudentsApiController(CampusDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Students.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            var s = db.Students.Find(id);

            if (s == null)
                return NotFound("Student not found.");

            return Ok(s);
        }

        [HttpPost]
        public IActionResult Add(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetOne), new { id = s.Id }, s);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var s = db.Students.Find(id);

            if (s == null)
                return NotFound("Student not found.");

            db.Students.Remove(s);
            db.SaveChanges();

            return Ok("Student deleted.");
        }
    }
}
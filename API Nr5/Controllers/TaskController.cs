using API_Nr5.Data;
using API_Nr5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Nr5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public TaskController(ApiDbContext db)
        {
            _db = db;
        }


        // GET: api/TaskApi?statusas=Vykdoma&nuo=2024-01-01
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskApi>>> GetFilteredTasks(
            [FromQuery] string? status,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to)
        {
            var uzklausos = _db.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                uzklausos = uzklausos.Where(t => t.Status == status);
            }

            if (from.HasValue)
            {
                uzklausos = uzklausos.Where(t => t.TaskDate >= from.Value);
            }

            if (to.HasValue)
            {
                uzklausos = uzklausos.Where(t => t.TaskDate <= to.Value);
            }

            return await uzklausos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TaskApi>> CreateTask([FromBody]  TaskCreateDto newtask)
        {
            if (string.IsNullOrEmpty(newtask.NameTask) || string.IsNullOrEmpty(newtask.Status) || newtask.TaskDate==null)
                return BadRequest("Ne visi butini duomenys gauti");

            TaskApi task = await _db.Tasks.FirstOrDefaultAsync(t => t.NameTask == newtask.NameTask);
            if (task!=null)
            {
                return BadRequest("Tokia uzduotis jau egzistuoja");
            }

           
            TaskApi newTask = new TaskApi(newtask.NameTask, newtask.Status, newtask.TaskDate);
            _db.Tasks.Add(newTask);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{nameTask}")]
        public async Task<IActionResult> UpdateStatus(string nameTask, [FromBody] string newStatus)
        {
            if (string.IsNullOrWhiteSpace(nameTask) || string.IsNullOrWhiteSpace(newStatus))
                return BadRequest("Trūksta reikalingų duomenų.");

            // Ieškome pagal pavadinimą
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.NameTask == nameTask);

            if (task == null)
                return NotFound($"Užduotis su pavadinimu '{nameTask}' nerasta.");

            // Atnaujiname statusą
            task.Status = newStatus;

            await _db.SaveChangesAsync();

            return Ok($"Statusas atnaujintas į: {newStatus}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _db.Tasks.FindAsync(id);

            if (task == null)
                return NotFound($"Task su ID {id} nerastas.");

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();

            return Ok($"Task su ID {id} sėkmingai ištrintas.");
        }





    }
}

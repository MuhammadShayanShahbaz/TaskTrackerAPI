using Microsoft.AspNetCore.Mvc;
using TaskTracker.BLL;
using TaskTracker.Models;

namespace TaskTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskLogic _bll = new TaskLogic();

        // GET: api/task
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _bll.GetTasks();
            return Ok(tasks);
        }

        // POST: api/task
        [HttpPost]
        public IActionResult Post([FromBody] TaskModel newTask)
        {
            bool isSuccess = _bll.CreateNewTask(newTask);

            if (isSuccess)
            {
                return Ok(new { Message = "Task created successfully!" });
            }

            return BadRequest("Invalid task data. Title must be at least 3 characters.");
        }

        // PUT: api/task/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskModel updatedTask)
        {
            // Ensure the ID in the URL matches the ID in the JSON body
            if (id != updatedTask.TaskID)
            {
                return BadRequest("Task ID mismatch.");
            }

            bool isSuccess = _bll.UpdateExistingTask(updatedTask);

            if (isSuccess)
            {
                return Ok(new { Message = "Task updated successfully!" });
            }

            return BadRequest("Invalid task data provided for update.");
        }

        // DELETE: api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isSuccess = _bll.RemoveTask(id);

            if (isSuccess)
            {
                return Ok(new { Message = $"Task {id} deleted successfully!" });
            }

            return BadRequest("Invalid Task ID.");
        }
    }
}
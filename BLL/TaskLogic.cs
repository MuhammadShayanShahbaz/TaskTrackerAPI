using TaskTracker.DAL;
using TaskTracker.Models;

namespace TaskTracker.BLL
{
    public class TaskLogic
    {
        private TaskDataAccess _dal = new TaskDataAccess();

        public List<TaskModel> GetTasks()
        {
            return _dal.GetAllTasks();
        }

        public bool CreateNewTask(TaskModel newTask)
        {
            // Business Rule: A task title cannot be empty or too short
            if (string.IsNullOrWhiteSpace(newTask.TaskTitle) || newTask.TaskTitle.Length < 3)
            {
                return false;
            }

            // Force new tasks to always start as 'Pending' regardless of user input
            newTask.Status = "Pending";

            _dal.AddTask(newTask);
            return true;
        }

        public bool UpdateExistingTask(TaskModel updatedTask)
        {
            // Edge Case Protection: ID must exist, and title/status cannot be empty
            if (updatedTask.TaskID <= 0 || string.IsNullOrWhiteSpace(updatedTask.TaskTitle) || string.IsNullOrWhiteSpace(updatedTask.Status))
            {
                return false;
            }

            _dal.UpdateTask(updatedTask);
            return true;
        }

        public bool RemoveTask(int taskId)
        {
            // Edge Case Protection: Prevent invalid IDs
            if (taskId <= 0)
            {
                return false;
            }

            _dal.DeleteTask(taskId);
            return true;
        }
    }
}
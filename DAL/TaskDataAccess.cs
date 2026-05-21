using System.Data;
using System.Data.SqlClient;
using TaskTracker.Models;
using Microsoft.Data.SqlClient;
namespace TaskTracker.DAL
{
    public class TaskDataAccess
    {
        private readonly string _connectionString = @"Server=DESKTOP-RBQF78R\SQLEXPRESS;Database=TaskTrackerAPI;Trusted_Connection=True;TrustServerCertificate=True;";
        public List<TaskModel> GetAllTasks()
        {
            var taskList = new List<TaskModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllTasks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            taskList.Add(new TaskModel
                            {
                                TaskID = Convert.ToInt32(reader["TaskID"]),
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                TaskTitle = reader["TaskTitle"].ToString(),
                                Status = reader["Status"].ToString(),
                                DueDate = Convert.ToDateTime(reader["DueDate"])
                            });
                        }
                    }
                }
            }
            return taskList;
        }

        public void AddTask(TaskModel task)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", task.ProjectID);
                    cmd.Parameters.AddWithValue("@TaskTitle", task.TaskTitle);
                    cmd.Parameters.AddWithValue("@Status", task.Status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTask(TaskModel task)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskID", task.TaskID);
                    cmd.Parameters.AddWithValue("@TaskTitle", task.TaskTitle);
                    cmd.Parameters.AddWithValue("@Status", task.Status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskID", taskId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
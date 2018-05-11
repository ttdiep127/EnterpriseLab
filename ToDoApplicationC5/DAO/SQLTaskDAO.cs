using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAO
{
    public class SQLTaskDAO : ITaskDAO<Task>
    {
        
        public SQLTaskDAO()
        {
            
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SQLData"].ConnectionString);            
        }

        public bool DeleteTask(Task task)
        {
            return false;
        }

        public IList<Task> GetTaskList()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var cmd = new SqlDataAdapter("select * from Tasks", connection))
                    {
                        using (var ds = new DataSet())
                        {
                            cmd.Fill(ds, "Tasks");
                            var tasks = ds.Tables["Tasks"].AsEnumerable().Select(
                                dataField =>
                                new Task
                                {
                                    ID = dataField[0].ToInt(),
                                    Title = dataField[1].ToString(),
                                    Description = dataField[2].ToString(),
                                    CreateDate = dataField[3].ToDateTime(),
                                    FinishDate = dataField[4].ToDateTime(),
                                    Type = (KindOfTask)dataField[5].ToInt()
                                }).ToList();

                            return tasks;
                        }
                    }
                }                
            }
            catch
            {
                return null;
            }
        }

        public bool InsertTask(Task task)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Tasks(Title, Description, CreateDate, FinishDate, TypeID) VALUES(@param1,@param2,@param3,@param4,@param5)", connection))
                    {
                        cmd.Parameters.AddWithValue("@param1", task.Title);
                        cmd.Parameters.AddWithValue("@param2", task.Description);
                        cmd.Parameters.AddWithValue("@param3", task.CreateDate);
                        cmd.Parameters.AddWithValue("@param4", task.FinishDate);
                        cmd.Parameters.AddWithValue("@param5", Convert.ToInt32(task.Type));

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTask(Task task)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Tasks SET Title=@param1, Description=@param2, CreateDate=@param3, FinishDate=@param4, TypeID=@param5 Where Id=@ID", connection))
                    {
                        cmd.Parameters.AddWithValue("@param1", task.Title);
                        cmd.Parameters.AddWithValue("@param2", task.Description);
                        cmd.Parameters.AddWithValue("@param3", task.CreateDate);
                        cmd.Parameters.AddWithValue("@param4", task.FinishDate);
                        cmd.Parameters.AddWithValue("@param5", task.Type.ToInt());
                        cmd.Parameters.AddWithValue("@ID", task.ID);

                        cmd.ExecuteNonQuery();
                        
                    }
                    connection.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using DepartmentsEmployeesConsole.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentsEmployeesConsole.Data
{
    // This class is for retrieving data from our database
    public class DepartmentRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=DepartmentsEmployees37; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Department> GetAllDepartments()
        {
            // 1. Open a connection to the database
            // 2. Create a SQL SELECT statement as a C# string
            // 3. Execute that SQL statement against the database
            // 4. From the database, we get "raw data" back. We need to parse this as a C# object
            // 5. Close the connection to the database
            // 6. Return the Employee object


            // This opens the connection SQLConnection triggers the beginning of the heist operation
            using (SqlConnection conn = Connection)
            {
                // This opens the VAULTS inside of the bank
                conn.Open();

                // SQLCommand is the list of instructions to give to the bank robber when they exit the vault
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here is the sql command that we want to be run when the bank robber gets to the vault (database)
                    cmd.CommandText = @"
                        SELECT Id, DeptName
                        FROM Department";

                    // ExecuteReader actually has the bank robber go to the vault and executes that command. The bank robber then comes back with a bunch of valuables (data) from the vault (database). This is stashed in the getaway car (variable) called "reader"
                    SqlDataReader reader = cmd.ExecuteReader();

                    // This is just us initializing the list that we'll eventually return
                    List<Department> allDepartments = new List<Department>();

                    // The reader will read the returned data from the database one row at a time. This is why we put it in a while loop.
                    while (reader.Read())
                    {
                        // Get ordinal returns us what "position" the Id column is in
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int deptNameColumnPosition = reader.GetOrdinal("DeptName");
                        string deptNameValue = reader.GetString(deptNameColumnPosition);

                        // Now that all the data is parsed, we create a new C# object
                        Department department = new Department()
                        {
                            Id = idValue,
                            DeptName = deptNameValue
                        };

                        // Now that we have a parsed C# object, we can add it to the list and continue with the while loop
                        allDepartments.Add(department);
                    }

                    // Now we can close the connection
                    reader.Close();

                    // and return all departments
                    return allDepartments;
                }
            }
        }

        public Department GetDepartmentById(int departmentId)
        {
            // This opens the connection SQLConnection triggers the beginning of the heist operation
            using (SqlConnection conn = Connection)
            {
                // This opens the VAULTS inside of the bank
                conn.Open();

                // SQLCommand is the list of instructions to give to the bank robber when they exit the vault
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here is the sql command that we want to be run when the bank robber gets to the vault (database)
                    cmd.CommandText = @"
                        SELECT Id, DeptName
                        FROM Department
                        WHERE Id = @id";

                    // This is us telling the bank robber that there is a VARIABLE in the sql statement. When you get to the database, replace the string "@id" with employeeId
                    cmd.Parameters.Add(new SqlParameter("@id", departmentId));

                    // ExecuteReader actually has the bank robber go to the vault and executes that command. The bank robber then comes back with a bunch of valuables (data) from the vault (database). This is stashed in the getaway car (variable) called "reader"
                    SqlDataReader reader = cmd.ExecuteReader();

                    // The reader will read the returned data from the database if it finds the single row we're looking for. If it doesn't find the employee with the given Id, reader.Read() will return false
                    if (reader.Read())
                    {
                        // Get ordinal returns us what "position" the Id column is in
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int deptNameColumnPosition = reader.GetOrdinal("DeptName");
                        string deptNameValue = reader.GetString(deptNameColumnPosition);

                        // Now that all the data is parsed, we create a new C# object
                        // Now that all the data is parsed, we create a new C# object
                        Department department = new Department()
                        {
                            Id = idValue,
                            DeptName = deptNameValue
                        };

                        // Now that we have a parsed C# object, we can add it to the list and continue with the while loop

                        // Now we can close the connection
                        reader.Close();

                        return department;
                    }
                    else
                    {
                        // We didn't find the employee with that ID in the database. return null
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Add a new department to the database
        /// NOTE: This method sends data to the database,
        /// it does not get anything from the database, so there is nothing to return.
        /// </summary>
        
        public void AddDepartment (Department department)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // These SQL parameters are annoying. Why can't we use string interpolation?
                    // .. sql injection attacks!!!
                    cmd.CommandText = "INSERT INTO Department (DeptName) OUTPUT INSERTED.Id Values (@deptName)";
                    cmd.Parameters.Add(new SqlParameter("@deptName", department.DeptName));
                    int id = (int)cmd.ExecuteScalar();

                    department.Id = id;
                } 
            }

            // when this method is finished we can look in the database and see the new department.
        }

        public void UpdateDepartment(int id, Department department)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Department
                                            SET DeptName = @deptName
                                            WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@deptName", department.DeptName));
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    cmd.ExecuteNonQuery();
                }    
            }
        }

        /// <summary>
        /// Delete the department with the given id
        /// </summary>
        public void DeleteDepartment(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Department where Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                }    
            }
        }
    }
}

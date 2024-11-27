using ylee39BAIS3150CodeSample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ylee39BAIS3150CodeSample.TechnicalServices
{
    public class Students
    {
        public bool AddStudent(Student acceptedStudent, string programCode) // parameter, Camel Case
        {
            bool Success = false;
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;";
            MyDataSource.Open();
            SqlCommand AddStudentCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddStudent"
            };
            SqlParameter AddStudentCommandParameter;
            AddStudentCommandParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.StudentID
            };
            AddStudentCommand.Parameters.Add(AddStudentCommandParameter);
            AddStudentCommandParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.FirstName
            };
            AddStudentCommand.Parameters.Add(AddStudentCommandParameter);
            AddStudentCommandParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.LastName
            };
            AddStudentCommand.Parameters.Add(AddStudentCommandParameter);
            AddStudentCommandParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.Email
            };
            AddStudentCommand.Parameters.Add(AddStudentCommandParameter);
            AddStudentCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            AddStudentCommand.Parameters.Add(AddStudentCommandParameter);
            AddStudentCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;
        }

        // Method to return a single Student object from the database by studentID
        public Student GetStudent(string studentID)
        {
            Student EnrolledStudent = new();

            SqlConnection MyDataSource = new SqlConnection
            {
                ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;"
            };

                MyDataSource.Open();

                SqlCommand FindStudentCommand = new SqlCommand
                {
                    Connection = MyDataSource,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetStudent" // Stored procedure that retrieves student by ID
                };

                SqlParameter StudentCommandParameter = new SqlParameter
                {
                    ParameterName = "@StudentID",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = studentID
                };

                FindStudentCommand.Parameters.Add(StudentCommandParameter);

                using (SqlDataReader StudentDataReader = FindStudentCommand.ExecuteReader())
                {
                    if (StudentDataReader.Read())
                    {
                        EnrolledStudent.StudentID = StudentDataReader["StudentID"]?.ToString() ?? string.Empty;
                        EnrolledStudent.FirstName = StudentDataReader["FirstName"]?.ToString() ?? string.Empty;
                        EnrolledStudent.LastName = StudentDataReader["LastName"]?.ToString() ?? string.Empty;
                        EnrolledStudent.Email = StudentDataReader["Email"]?.ToString() ?? string.Empty;
                    }
                }
            
                MyDataSource.Close();
     

            return EnrolledStudent;
        }

        //passes student object
        public bool UpdateStudent(Student enrolledStudent)
        {
            bool Success = false;
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand ModifyStudentCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateStudent"
            };
            SqlParameter StudentCommandParameter;
            StudentCommandParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.StudentID
            };


            ModifyStudentCommand.Parameters.Add(StudentCommandParameter);

            SqlParameter StudentCommandParameter2;
            StudentCommandParameter2 = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.FirstName
            };
            ModifyStudentCommand.Parameters.Add(StudentCommandParameter2);

            SqlParameter StudentCommandParameter3;
            StudentCommandParameter3 = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.LastName
            };
            ModifyStudentCommand.Parameters.Add(StudentCommandParameter3);

            SqlParameter StudentCommandParameter4;
            StudentCommandParameter4 = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.Email
            };

            ModifyStudentCommand.Parameters.Add(StudentCommandParameter4);

            SqlParameter StudentCommandParameter5;
            StudentCommandParameter5 = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "CS123"
            };

            ModifyStudentCommand.Parameters.Add(StudentCommandParameter5);

            ModifyStudentCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;

        }

        //remove student
        public bool DeleteStudent(string studentID)
        {
            bool Success = false;
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand RemoveStudentCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStudent"
            };
            SqlParameter RemoveStudentCommandParameter;

            RemoveStudentCommandParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = studentID
            };
            RemoveStudentCommand.Parameters.Add(RemoveStudentCommandParameter);
            RemoveStudentCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;
        }

        //remove student
        public List<Student> GetStudents(string programCode)
        {
            List<Student> EnrolledStudents = new List<Student>();

            SqlConnection MyDataSource = new SqlConnection
            {
                ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;"
            };

    
                MyDataSource.Open();

                SqlCommand GetStudentsCommand = new SqlCommand
                {
                    Connection = MyDataSource,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetStudentsByProgram" // Stored procedure that retrieves students by ProgramCode
                };

                SqlParameter GetStudentsCommandParameter = new SqlParameter
                {
                    ParameterName = "@ProgramCode",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = programCode
                };

                GetStudentsCommand.Parameters.Add(GetStudentsCommandParameter);

                using (SqlDataReader StudentDataReader = GetStudentsCommand.ExecuteReader())
                {
                    while (StudentDataReader.Read())
                    {
                        Student EnrolledStudent = new Student
                        {
                            StudentID = StudentDataReader["StudentID"]?.ToString() ?? string.Empty,
                            FirstName = StudentDataReader["FirstName"]?.ToString() ?? string.Empty,
                            LastName = StudentDataReader["LastName"]?.ToString() ?? string.Empty,
                            Email = StudentDataReader["Email"]?.ToString() ?? string.Empty
                        };

                        EnrolledStudents.Add(EnrolledStudent);
                    }
                }
      
                MyDataSource.Close();
     
            return EnrolledStudents;
        }
    }
}

using ylee39BAIS3150CodeSample.Domain;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ylee39BAIS3150CodeSample.TechnicalServices
{
    public class Programs
    {
        public Domain.Program GetProgram(string programCode)
        {
            Domain.Program ActiveProgram = new();
            Students StudentManager = new();
            List<Student> EnrolledStudents = StudentManager.GetStudents(programCode);

            ActiveProgram.EnrolledStudents = EnrolledStudents;

            SqlConnection MyDataSource = new SqlConnection
            {
                ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;"
            };

   
                MyDataSource.Open();

                SqlCommand FindProgramCommand = new SqlCommand
                {
                    Connection = MyDataSource,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetProgram" // Stored procedure that retrieves program by ProgramCode
                };

                SqlParameter ProgramCommandParameter = new SqlParameter
                {
                    ParameterName = "@ProgramCode",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = programCode
                };

                FindProgramCommand.Parameters.Add(ProgramCommandParameter);

                using (SqlDataReader ProgramDataReader = FindProgramCommand.ExecuteReader())
                {
                    // No need to check if ProgramDataReader is null, just check if Read() returns true
                    if (ProgramDataReader.Read())
                    {
                        // Using the null-coalescing operator ?? to handle null or DBNull
                        ActiveProgram.ProgramCode = ProgramDataReader["ProgramCode"] as string ?? string.Empty;
                        ActiveProgram.Description = ProgramDataReader["Description"] as string ?? string.Empty;
                    }
                }

                
                MyDataSource.Close();
 
            return ActiveProgram;
        }

        //create a program object?
        public bool AddProgram(string programCode, string description)
        {
            bool Success = false;
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=ylee39;User ID=ylee39;Password=Zheldcjswo8fd87559;server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand CreateProgramCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddProgram"
            };

            SqlParameter CreateProgramCommandParameter;
            CreateProgramCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };

            SqlParameter CreateProgramCommandParameter2;
            CreateProgramCommandParameter2 = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = description
            };

            CreateProgramCommand.Parameters.Add(CreateProgramCommandParameter);
            CreateProgramCommand.Parameters.Add(CreateProgramCommandParameter2);
            CreateProgramCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;
        }
}
}

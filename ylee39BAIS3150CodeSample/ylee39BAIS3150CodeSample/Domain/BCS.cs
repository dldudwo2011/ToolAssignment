using ylee39BAIS3150CodeSample.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ylee39BAIS3150CodeSample.Domain
{
    internal class BCS
    {
        public bool CreateProgram(string programCode, string description)
        {
            bool Success;
            Programs ProgramManager = new();
            Success = ProgramManager.AddProgram(programCode, description);
            return Success;
        }

        //enroll student
        public bool EnrollStudent(Student acceptedStudent, string programCode)
        {
            bool Success;
            Students StudentManager = new();
            Success = StudentManager.AddStudent(acceptedStudent, programCode);
            return Success;
        }

        //find student
        public Student FindStudent(string studentID)
        {
            Student EnrolledStudent;
            Students StudentManager = new();
            EnrolledStudent = StudentManager.GetStudent(studentID);
            return EnrolledStudent;
        }

        //modify student
        public bool ModifyStudent(Student enrolledStudent)
        {
            bool Success;
            Students StudentManager = new();
            Success = StudentManager.UpdateStudent(enrolledStudent);
            return Success;
        }


        //remove student
        public bool RemoveStudent(string studentID)
        {
            bool Success;
            Students StudentManager = new();
            Success = StudentManager.DeleteStudent(studentID);
            return Success;
        }

        //find program
        public Domain.Program FindProgram(string programCode)
        {
            Programs ProgramManager = new();
            Domain.Program ActiveProgram = ProgramManager.GetProgram(programCode);
            return ActiveProgram;
        }
    }
}

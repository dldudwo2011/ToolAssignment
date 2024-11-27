using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ylee39BAIS3150CodeSample.Domain
{
    public class Program
    {
        // string.Empty (default non-null value, if object required before setting)
        // ? (nullable reference type)
        private string _programCode = string.Empty; // Camel Case preceded with underscore
        private string _description = "";
        private List<Student> _enrolledStudents = new List<Student>();

        public string ProgramCode // Pascal case
        {
            get
            {
                return _programCode;
            }
            set
            {
                _programCode = value;
            }
        }
        public string Description // Expression-Bodied Property Assessors
        {
            get => _description; // implementation can be made up of only a single statement
            set => _description = value;
        }
        public List<Student> EnrolledStudents // Property for the list of students
        {
            get => _enrolledStudents;
            set => _enrolledStudents = value;
        }
    }
}

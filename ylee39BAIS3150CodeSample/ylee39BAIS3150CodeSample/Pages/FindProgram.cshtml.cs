using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ylee39BAIS3150CodeSample.TechnicalServices;
using ylee39BAIS3150CodeSample.Domain;

namespace ylee39BAIS3150CodeSample.Pages.StudentProgram
{

    public class FindProgramModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Program code is required.")]
        public string ProgramCode { get; set; } = string.Empty;

        public Domain.Program Program { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new();
                Program = RequestDirector.FindProgram(ProgramCode);

                // Retrieve enrolled students if program is found
                if (Program != null)
                {
                    EnrolledStudents = Program.EnrolledStudents;
                }
            }

        }
    }

}
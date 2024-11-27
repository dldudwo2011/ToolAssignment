using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ylee39BAIS3150CodeSample.Domain;

namespace ylee39BAIS3150CodeSample.Pages.StudentProgram
{
    public class EnrollStudentModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Student ID is required.")]
        public string StudentID { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Program code is required.")]
        public string ProgramCode { get; set; } = string.Empty;

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {

                BCS RequestDirector = new();
                Student AcceptedStudent = new Student
                {
                    StudentID = StudentID,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    ProgramCode = ProgramCode
                };
                Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);

            }
        }
    }
}

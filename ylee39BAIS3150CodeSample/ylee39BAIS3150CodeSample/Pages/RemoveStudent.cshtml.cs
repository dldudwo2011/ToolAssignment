using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ylee39BAIS3150CodeSample.Domain;

namespace ylee39BAIS3150CodeSample.Pages.StudentProgram
{
    public class RemoveStudentModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Student ID is required.")]
        public string StudentID { get; set; }

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new();
                Confirmation = RequestDirector.RemoveStudent(StudentID);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ylee39BAIS3150CodeSample.TechnicalServices;
using ylee39BAIS3150CodeSample.Domain;

namespace ylee39BAIS3150CodeSample.Pages.StudentProgram
{
    public class FindStudentModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Student ID is required.")]
        public string StudentID { get; set; } = string.Empty;

        public Student Student { get; set; } 

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new();
                Student = RequestDirector.FindStudent(StudentID);
            }
        }
    }
}

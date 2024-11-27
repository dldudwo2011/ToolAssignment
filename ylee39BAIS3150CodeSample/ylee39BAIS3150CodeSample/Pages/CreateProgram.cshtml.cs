using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ylee39BAIS3150CodeSample.Domain;

namespace ylee39BAIS3150CodeSample.Pages.StudentProgram
{
    public class CreateProgramModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Program code is required.")]
        [StringLength(10, ErrorMessage = "Program code cannot exceed 10 characters.")]
        public string ProgramCode { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; } = string.Empty;

        public bool Confirmation { get; set; } = false;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                BCS RequestDirector = new();
                Confirmation = RequestDirector.CreateProgram(ProgramCode, Description);
            }
        }
    }
}
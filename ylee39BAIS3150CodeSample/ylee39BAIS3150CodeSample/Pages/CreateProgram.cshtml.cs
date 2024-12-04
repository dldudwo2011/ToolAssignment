using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ylee39BAIS3150CodeSample.Domain;

namespace ylee39BAIS3150CodeSample.Pages.StudentProgram
{
    public class CreateProgramModel : PageModel
    {
        [BindProperty]
        public string ProgramCode { get; set; } = string.Empty;

        [BindProperty]
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
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

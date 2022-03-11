using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AbbyWeb.Model;
using AbbyWeb.Data;

namespace AbbyWeb.Pages.Categories
{

    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
      

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);

        }


        public async Task<IActionResult> OnPost()
        {

            // Custome error (if Name and Displayorder are same)
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Display Order Cannot Exactly match the Name");
            }

            
            if(ModelState.IsValid)
            {

                   _db.Category.Update(Category);
                   await _db.SaveChangesAsync();
                   TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");

            }

            return Page();
        }

    }
}

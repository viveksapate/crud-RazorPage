using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AbbyWeb.Model;
using AbbyWeb.Data;

namespace AbbyWeb.Pages.Categories
{

    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
      

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);

        }


        public async Task<IActionResult> OnPost()
        {
           
                var categoryfromdb = _db.Category.Find(Category.Id);
                if(categoryfromdb != null)
                {
                    _db.Category.Remove(categoryfromdb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Category Deleted Successfully";
                    return RedirectToPage("Index");

                }

               
            return Page();
        }

    }
}

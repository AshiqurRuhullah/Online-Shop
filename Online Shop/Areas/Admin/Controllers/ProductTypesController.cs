using Microsoft.AspNetCore.Mvc;
using Online_Shop.Data;
using Online_Shop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // var data = _db.ProductTypes.ToList();
            return View(_db.ProductTypes.ToList());
        }

        [HttpGet]
        // Create GET Action Method 
        public ActionResult Create()
        {
            return View();
        }
        // Create POST Action Method 
        [HttpPost]
        [ValidateAntiForgeryToken]

        //AntiForgeryToken use for security purpose 
        // Microsoft Built in 
        // check valid token then
        //Task async use for asynchronous code 
        // asynchronous one by one execute the method 
        // if, in the same time comes multiple requests then it handle and don't show error 

        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes); 
        }



        [HttpGet]
        // Edit GET Action Method 
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType ==null)
            {
                return NotFound();
            }
            return View(productType);
        }



        // Edit  POST Action Method  
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            { 
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }



        [HttpGet]
        // Details GET Action Method 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }




        [HttpGet]
        // Delete GET Action Method 
        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }



        // Delete  POST Action Method  
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!=productTypes.Id)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

    }
}

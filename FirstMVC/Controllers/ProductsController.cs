using Microsoft.AspNetCore.Mvc;

using FirstMVC.Models;

public class ProductsController : Controller
{
    // private static List<Product> products = new List<Product>
    // {
    //     new Product { ID = 1, Name = "Laptop", Price = 999.99f },
    //     new Product { ID = 2, Name = "Smartphone", Price = 499.99f },
    //     new Product { ID = 3, Name = "Tablet", Price = 299.99f }
    // };
    private AppDbContext appDbContext;
    public ProductsController(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return View(appDbContext.Products.ToList());
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        appDbContext.Products.Add(product);
        appDbContext.SaveChanges();
        return RedirectToAction("GetAll");
    }

    // [HttpGet("api/products")]
    // public ActionResult<IEnumerable<Product>> GetProducts()
    // {
    //     return appDbContext.Products.ToList();
    // }

    // [HttpGet("api/products/{id}")]
    // public ActionResult<Product> GetProduct(int id)
    // {
    //     var product = products.FirstOrDefault(p => p.ID == id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(product);
    // }

    // [HttpPost()]
    // public void Post([FromBody] Product newProduct)
    // {
    //     appDbContext.Products.Add(newProduct);
    //     appDbContext.SaveChanges();
    //     return ;
    // }

    [HttpPut]
    public void Put(int id, Product product)
    {
        
    }
    // public void Put(int id , Product product)
    // {
    //     var oldProduct = products.Find(p => p.ID == id);
    //     oldProduct.Name = product.Name;
    //     oldProduct.Price = oldProduct.Price;

    // }

    [HttpDelete]
    public void Delete(int id)
    {
        var oldProduct = appDbContext.Products.Find(id);
        appDbContext.Products.Remove(oldProduct);
        appDbContext.SaveChanges();
    }
}
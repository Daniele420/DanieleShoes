using Castle.Components.DictionaryAdapter;
using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Models.Brand;
using DiplomenProektNo7.Models.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace DiplomenProektNo7.Models.Shoe
{
    public class ShoeCreateVM
    {
        public ShoeCreateVM()
        {

            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
         [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Shoe Name")]
        public string ShoeName { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }
        
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Range(0, 2000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
    public class ShoeController : Controller
    {
        private readonly IShoeService _shoeService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ShoeController(IShoeService shoeService, ICategoryService categoryService, IBrandService brandService)
        {
            this._shoeService = shoeService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }
        public ActionResult Create()
        {
            var shoe = new ShoeCreateVM();
            shoe.Brands = _brandService.GetBrands()
                .Select(x => new BrandPairVM()
                {
                    Id = x.Id,
                    Name = x.BrandName
                }).ToList();
            shoe.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryPairVM()
                {
                Id = x.Id,
                    Name = x.CategoryName
                }).ToList();
            return View(shoe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ShoeCreateVM shoe)
        {
            if (ModelState.IsValid) 
            {
                var createId = _shoeService.Create(shoe.ShoeName, shoe.BrandId,
                                                   shoe.CategoryId, shoe.Picture,
                                                   shoe.Quantity, shoe.Price, shoe.Discount);
                if (createId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public ActionResult Index(string searchStringCategoryName, string searchStringBrandName)
        {
            List<ShoeIndexVM> shoes = _shoeService.GetShoes(searchStringCategoryName, searchStringBrandName)
                .Select(shoe => new ShoeIndexVM
                {
                    Id = shoe.Id,
                    ShoeName = shoe.ShoeName,
                    BrandId = shoe.BrandId,
                    BrandName = shoe.Brand.BrandName,
                    CategoryId = shoe.CategoryId,
                    CategoryName = shoe.Category.CategoryName,
                    Picture = shoe.Picture,
                    Quantity = shoe.Quantity,
                    Price = shoe.Price,
                    Discount = shoe.Discount

                }).ToList();
            return this.View(shoes);
        }
    }
}

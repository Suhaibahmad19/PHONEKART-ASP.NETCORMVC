using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PHONEKART.Models;
using PHONEKART.Constants;
using PHONEKART.Models.DTOs;
using PHONEKART.Repositories;

namespace PHONEKART.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepo;

        public BrandController(IBrandRepository brandRepo)
        {
            _brandRepo = brandRepo;
        }

        public async Task<IActionResult> Index()
        {
            var Brands = await _brandRepo.GetBrands();
            return View(Brands);
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandDTO Brand)
        {
            if(!ModelState.IsValid)
            {
                return View(Brand);
            }
            try
            {
                var BrandToAdd = new Brand { BrandName = Brand.BrandName, Id = Brand.Id };
                await _brandRepo.AddBrand(BrandToAdd);
                TempData["successMessage"] = "Brand added successfully";
                return RedirectToAction(nameof(AddBrand));
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = "Brand could not added!";
                return View(Brand);
            }

        }

        public async Task<IActionResult> UpdateBrand(int id)
        {
            var Brand = await _brandRepo.GetBrandById(id);
            if (Brand is null)
                throw new InvalidOperationException($"Brand with id: {id} does not found");
            var BrandToUpdate = new BrandDTO
            {
                Id = Brand.Id,
                BrandName = Brand.BrandName
            };
            return View(BrandToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(BrandDTO BrandToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(BrandToUpdate);
            }
            try
            {
                var Brand = new Brand { BrandName = BrandToUpdate.BrandName, Id = BrandToUpdate.Id };
                await _brandRepo.UpdateBrand(Brand);
                TempData["successMessage"] = "Brand is updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Brand could not updated!";
                return View(BrandToUpdate);
            }

        }

        public async Task<IActionResult> DeleteBrand(int id)
        {
            var Brand = await _brandRepo.GetBrandById(id);
            if (Brand is null)
                throw new InvalidOperationException($"Brand with id: {id} does not found");
            await _brandRepo.DeleteBrand(Brand);
            return RedirectToAction(nameof(Index));

        }

    }
}

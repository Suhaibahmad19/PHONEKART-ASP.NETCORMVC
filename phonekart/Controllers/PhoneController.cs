using PHONEKART.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PHONEKART.Repositories;
using PHONEKART.Constants;
using PHONEKART.Models.DTOs;

namespace PHONEKART.Controllers;

[Authorize(Roles = nameof(Roles.Admin))]
public class PhoneController : Controller
{
    private readonly IPhoneRepository _phoneRepo;
    private readonly IBrandRepository _brandRepo;
    private readonly IFileService _fileService;

    public PhoneController(IPhoneRepository phoneRepo, IBrandRepository brandRepo, IFileService fileService)
    {
        _phoneRepo = phoneRepo;
        _brandRepo = brandRepo;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var phones = await _phoneRepo.Getphones();
        return View(phones);
    }

    public async Task<IActionResult> AddPhone()
    {
        var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
        {
            Text = brand.BrandName,
            Value = brand.Id.ToString(),
        });
        PhoneDTO phoneToAdd = new() { BrandList = brandSelectList };
        return View(phoneToAdd);
    }

    [HttpPost]
    public async Task<IActionResult> AddPhone(PhoneDTO phoneToAdd)
    {
        var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
        {
            Text = brand.BrandName,
            Value = brand.Id.ToString(),
        });
        phoneToAdd.BrandList = brandSelectList;

        if (!ModelState.IsValid)
            return View(phoneToAdd);

        try
        {
            if (phoneToAdd.ImageFile != null)
            {
                if(phoneToAdd.ImageFile.Length> 1 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Image file can not exceed 1 MB");
                }
                string[] allowedExtensions = [".jpeg",".jpg",".png"];
                string imageName=await _fileService.SaveFile(phoneToAdd.ImageFile, allowedExtensions);
                phoneToAdd.Image = imageName;
            }
            // manual mapping of PhoneDTO -> Phone
            Phone phone = new()
            {
                Id = phoneToAdd.Id,
                Model = phoneToAdd.PhoneName,
                Image = phoneToAdd.Image,
                BrandId = phoneToAdd.BrandId,
                Price = phoneToAdd.Price
            };
            await _phoneRepo.Addphone(phone);
            TempData["successMessage"] = "Phone is added successfully";
            return RedirectToAction(nameof(AddPhone));
        }
        catch (InvalidOperationException ex)
        {
            TempData["errorMessage"]= ex.Message;
            return View(phoneToAdd);
        }
        catch (FileNotFoundException ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View(phoneToAdd);
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = "Error on saving data";
            return View(phoneToAdd);
        }
    }

    public async Task<IActionResult> UpdatePhone(int id)
    {
        var phone = await _phoneRepo.GetphoneById(id);
        if(phone == null)
        {
            TempData["errorMessage"] = $"Phone with the id: {id} does not found";
            return RedirectToAction(nameof(Index));
        }
        var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
        {
            Text = brand.BrandName,
            Value = brand.Id.ToString(),
            Selected=brand.Id==phone.BrandId
        });
        PhoneDTO phoneToUpdate = new() 
        { 
            BrandList = brandSelectList,
            PhoneName= phone.Model,
            BrandId= phone.BrandId,
            Price= phone.Price,
            Image= phone.Image 
        };
        return View(phoneToUpdate);
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePhone(PhoneDTO phoneToUpdate)
    {
        var brandSelectList = (await _brandRepo.GetBrands()).Select(brand => new SelectListItem
        {
            Text = brand.BrandName,
            Value = brand.Id.ToString(),
            Selected=brand.Id==phoneToUpdate.BrandId
        });
        phoneToUpdate.BrandList = brandSelectList;

        if (!ModelState.IsValid)
            return View(phoneToUpdate);

        try
        {
            string oldImage = "";
            if (phoneToUpdate.ImageFile != null)
            {
                if (phoneToUpdate.ImageFile.Length > 1 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Image file can not exceed 1 MB");
                }
                string[] allowedExtensions = [".jpeg", ".jpg", ".png"];
                string imageName = await _fileService.SaveFile(phoneToUpdate.ImageFile, allowedExtensions);
                // hold the old image name. Because we will delete this image after updating the new
                oldImage = phoneToUpdate.Image;
                phoneToUpdate.Image = imageName;
            }
            // manual mapping of PhoneDTO -> Phone
            Phone phone = new()
            {
                Id=phoneToUpdate.Id,
                //Model = phoneToUpdate.Model,
                BrandId = phoneToUpdate.BrandId,
                Price = phoneToUpdate.Price,
                Image = phoneToUpdate.Image
            };
            await _phoneRepo.Updatephone(phone);
            // if image is updated, then delete it from the folder too
            if(!string.IsNullOrWhiteSpace(oldImage))
            {
                _fileService.DeleteFile(oldImage);
            }
            TempData["successMessage"] = "Phone is updated successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View(phoneToUpdate);
        }
        catch (FileNotFoundException ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View(phoneToUpdate);
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = "Error on saving data";
            return View(phoneToUpdate);
        }
    }

    public async Task<IActionResult> DeletePhone(int id)
    {
        try
        {
            var phone = await _phoneRepo.GetphoneById(id);
            if (phone == null)
            {
                TempData["errorMessage"] = $"Phone with the id: {id} does not found";
            }
            else
            {
                await _phoneRepo.Deletephone(phone);
                if (!string.IsNullOrWhiteSpace(phone.Image))
                {
                    _fileService.DeleteFile(phone.Image);
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            TempData["errorMessage"] = ex.Message;
        }
        catch (FileNotFoundException ex)
        {
            TempData["errorMessage"] = ex.Message;
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = "Error on deleting the data";
        }
        return RedirectToAction(nameof(Index));
    }

}

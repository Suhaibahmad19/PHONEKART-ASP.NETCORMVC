using PHONEKART.Models;
using PHONEKART.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookShoppingCartMvcUI.Models;

namespace PHONEKART.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sterm="",int BrandId=0)
        {
            IEnumerable<Phone> phones = await _homeRepository.GetPhones(sterm, BrandId);
            IEnumerable<Brand> Brands = await _homeRepository.Brands();
            PhoneDisplayModel phoneModel = new PhoneDisplayModel
            {
              Phones=phones,
              brands=Brands,
              STerm=sterm,
              BrandId=BrandId
            };
            return View(phoneModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
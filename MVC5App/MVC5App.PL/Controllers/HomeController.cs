using MVC5App.Core.DTOs.Concrete;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MVC5App.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryService.CountryServiceClient _client;
        public HomeController()
        {
            _client = new CountryService.CountryServiceClient();
        }

        public ActionResult Index()
        {
            ViewBag.Countries = _client.GetListOfCountryNamesByCode(); 
            return View();
        }

        [HttpPost]
        public ActionResult Index(CountryAddDto countryAddDto)
        {
            _client.AddCountry(countryAddDto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public string GetCountryInfoByName(string name)
        {
            var res = _client.GetCountryInfoByName(name);
            return JsonConvert.SerializeObject(res);
        }
    }
}
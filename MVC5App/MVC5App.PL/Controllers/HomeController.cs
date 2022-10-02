using MVC5App.Core.DTOs.Concrete;
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
            ViewBag.Countries = _client.GetListOfCountryNamesByCode(); ;
            return View();
        }


        public CountryInfoByServiceDto GetCountryInfoByName(string name)
        {
            return _client.GetCountryInfoByName(name);
        }

        public void SaveCountry(CountryAddDto countryAddDto)
        {
            _client.AddCountry(countryAddDto);
        }
    }
}
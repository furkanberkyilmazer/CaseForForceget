using CaseForForceget.EntityLayer.Dtos;
using CaseForForceget.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace CaseForForceget.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string apiUrl = "https://localhost:7091/api/Offers/";

        private readonly HttpClient httpClient;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(OfferDto offerDto)
        {


            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(offerDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl+"Add", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.SuccessMessage = "Kayýt Tamamlandý";
                    return View();
                }
                else
                {
                    return RedirectToAction("Error");

                }

            }
            catch (Exception ex)
            {

                return RedirectToAction("Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            try
            {


                var response = await httpClient.GetAsync(apiUrl + "GetAll");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var offerDtoList = JsonConvert.DeserializeObject<List<OfferDto>>(content);

                    return View(offerDtoList); 
                }
                else
                {
                    return RedirectToAction("Error");

                }

            }
            catch (Exception ex)
            {

                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

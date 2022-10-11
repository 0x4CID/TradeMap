using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TradeMap.Models;
using TradeMap.Services;
namespace TradeMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            FXNewsService newsService = new FXNewsService();
            var news = await newsService.GetNews();

            var model = new FXNewsListModel()
            {
                FXNewsList = news

            };
            
            return View(model);
        }

        public async Task<IActionResult> Rates()
        {
            RatesStreamingService stream = new RatesStreamingService();
            stream.Authenticate();
            stream.ChooseInstruments("EUR_USD");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
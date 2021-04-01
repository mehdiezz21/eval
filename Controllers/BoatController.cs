using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Boat.Models;

namespace Boat.Controllers
{
    public class BoatController : Controller
    {
        private const string _cookieKey = "stations";

        public IActionResult Liste()
        {
            var stations = GetBoatFromApi();



            return View(stations);
        }

        public IActionResult Carte()
        {
            var stations = GetBoatFromApi();
            return View(stations);
        }



        private static List<Boats> GetBoatFromApi()
        {

            using (var client = new HttpClient())
            {

                var response = client.GetAsync("https://api.alexandredubois.com/pont-chaban/api.php");

                var stringResult = response.Result.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Boats>>(stringResult.Result);
                return result;
            }
        }
    }
}


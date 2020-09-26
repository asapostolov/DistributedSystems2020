using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistributedSystems2020.Models;
using System.Net;
using Newtonsoft.Json;

namespace DistributedSystems2020.Controllers {
    public class HomeController : Controller {
        public ActionResult Index( string id ) {
            var viewModel = new IndexViewModel() {
                Title = "Разпределени Системи 2020 " + id,
                //Description = body
            };
            
            var bgTollUrl = "https://check.bgtoll.bg/check/vignette/plate/BG/";

            var client = new WebClient();
            var body = "";
            if ( id != null && id != "" ) {
                body = client.DownloadString( bgTollUrl + id );
                viewModel.BgToll = JsonConvert.DeserializeObject<BGTollModel>( body );
            }
            
            return View( viewModel );
        }

        public ActionResult Weather( string city ) {
            var viewModel = new WeatherModel() {
                City = city
            };

            if ( city != null && city != "" ) {
                var apiKey = "5afa920673234dc90e1018bf6f4ceeb2";
                var info = new WebClient()
                    .DownloadString( 
        $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric" );

                viewModel.Weather = JsonConvert.DeserializeObject<WeatherInfo>( info );
            }


            return View( viewModel );
        }


        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            var a = "about";
            var b = a;

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
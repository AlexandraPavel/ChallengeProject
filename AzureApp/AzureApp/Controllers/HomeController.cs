using AzureApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        // GET: EnrolledInChallenges/Delete/5
        public IActionResult Transform()
        {
            return View();
        }

        // POST: EnrolledInChallenges/Delete/5

        // GET: EnrolledInChallenges/Details/5
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(String TextMsg)
        {
            var config = SpeechConfig.FromSubscription("bbdc4a0ceb7c4f229dd1cf6d4f2a5115", "westeurope");
            var synthesizer = new SpeechSynthesizer(config);
            //var ssml = File.ReadAllText("./ssml.xml");
            //var result = await synthesizer.SpeakSsmlAsync(ssml);
            var result = await synthesizer.SpeakTextAsync(TextMsg);
            /*await synthesizer.SpeakTextAsync(TextMsg);*/
            var stream = AudioDataStream.FromResult(result);
            /*await stream.SaveToWaveFileAsync("E:/text-to-speech-result/andrei.wav");*/
            ViewBag.result = result;
            return View();
        }

    }
}

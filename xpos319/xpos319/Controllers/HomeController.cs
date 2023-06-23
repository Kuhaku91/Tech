using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using xpos319.Models;

namespace xpos319.Controllers
{
    public class HomeController : Controller
    {
        private static List<Friend> friends = new List<Friend>()
            {
                new Friend() {Id = 1, Nama = "Rizwan", Address ="London"},
                new Friend() {Id = 2, Nama = "Fahri", Address ="Jakarta"}
            };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<Friend> friends = new List<Friend>()
            //{
            //    new Friend() {Id = 1, Nama = "Rizwan", Address ="London"},
            //    new Friend() {Id = 2, Nama = "Fahri", Address ="Jakarta"}
            //};
            //ViewBag.ListFriends = friends;

            return View(friends);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Friend friend)
        {
            friends.Add(friend);
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            Friend friend = friends.Find(a => a.Id == id)!;
            return View(friend);
        }

        [HttpPost]
        public IActionResult Edit(Friend data)
        {
            Friend friend = friends.Find(a => a.Id == data.Id);
            int index = friends.IndexOf(friend);

            if (index > -1)
            {
                friends[index].Nama = data.Nama;
                friends[index].Address = data.Address;

            }

            return RedirectToAction("Index");
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
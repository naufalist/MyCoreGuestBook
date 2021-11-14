using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCoreGuestBook.Models;
using MySql.Data.MySqlClient;

namespace MyCoreGuestBook.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
      /* using EF Core */
      GuestBookDataContext db = new GuestBookDataContext();
      var items = db.GuestBooks.ToList();

      // IList<GuestBook> items = new List<GuestBook>();

      // // database connection
      // MySqlConnection conn = new MySqlConnection
      // {
      //   ConnectionString = Startup.ConnectionString
      //   // ConnectionString = "server=127.0.0.1;port=3306;userid=root;pwd=12345;database=elibrary;sslmode=none"
      // };
      // conn.Open();

      // // prepare query
      // MySqlCommand cmd = new MySqlCommand("SELECT * FROM guestbooks;", conn);

      // // read data
      // MySqlDataReader dataReader = cmd.ExecuteReader();
      // while (dataReader.Read())
      // {
      //   // save record to model object
      //   GuestBook item = new GuestBook();
      //   item.Email = Convert.ToString(dataReader["guest_email"]);
      //   item.Name = Convert.ToString(dataReader["guest_name"]);
      //   item.Message = Convert.ToString(dataReader["message"]);

      //   // save model object to collection
      //   items.Add(item);
      // }
      // // close reader
      // dataReader.Close();
      // conn.Close();

      return View(items);
    }

    // [HttpPost]
    // public IActionResult Index(GuestBook data)
    // {
    //   ViewBag.GuestBookMessage = "Hello " + data.Name + "(" + data.Email + ") menulis " + data.Message;

    //   return View();
    // }

    [HttpGet]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(GuestBook item)
    {
      if (ModelState.IsValid)
      {
        /* using EF Core */
        GuestBookDataContext db = new GuestBookDataContext();
        db.Add(item);
        db.SaveChanges();

        // MySqlConnection conn = new MySqlConnection
        // {
        //   ConnectionString = Startup.ConnectionString
        // };
        // conn.Open();

        // MySqlCommand command = conn.CreateCommand();
        // command.CommandText = "INSERT INTO guestbooks (guest_name, guest_email, message) VALUES (?name, ?email, ?message)";

        // command.Parameters.AddWithValue("?name", item.Name);
        // command.Parameters.AddWithValue("?email", item.Email);
        // command.Parameters.AddWithValue("?message", item.Message);
        // command.ExecuteNonQuery();

        // conn.Close();

        // return RedirectToAction("Index");
      }
      return View();
    }

  }
}

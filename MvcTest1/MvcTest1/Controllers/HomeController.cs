using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcTest1.Models;
using MvcTest1.Utills;

namespace MvcTest1.Controllers {
	public class HomeController : Controller {
		// создаем контекст данных
		BookContext db = new BookContext();

		public ActionResult Index() {
			// получаем из бд все объекты Book
			IEnumerable<Book> books = db.Books;
			// передаем все объекты в динамическое свойство Books в ViewBag
			//ViewBag.Books = books;
			// возвращаем представление
			return View(books);
		}

		public ActionResult Partial() {
			ViewBag.Message = "Это частичное представление.";
			return PartialView();
		}

		// асинхронный метод
		public async Task<ActionResult> BookList() {
			IEnumerable<Book> books = await db.Books.ToListAsync();
			ViewBag.Books = books;
			return View("Index");
		}

		[HttpGet]
		public ActionResult Buy(int id) {
			ViewBag.BookId = id;
			return View();
		}

		[HttpPost]
		public string Buy(Purchase purchase) {
			purchase.Date = DateTime.Now;
			// добавляем информацию о покупке в базу данных
			db.Purchases.Add(purchase);
			// сохраняем в бд все изменения
			db.SaveChanges();
			return "Спасибо," + purchase.Person + ", за покупку!";
		}

		//// Home/Square?a=10&h=3
		////Home/Square?h=5
		////Home/Square/
		//public string Square(int a=10, int h=3) {
		//	double s = a * h / 2;
		//	return "<h2>Площадь треугольника с основанием " + a +
		//			" и высотой " + h + " равна " + s + "</h2>";
		//}

		public string Square() {
			int a = Int32.Parse(Request.Params["a"]);
			int h = Int32.Parse(Request.Params["h"]);
			double s = a * h / 2;
			return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
		}

		public ActionResult GetHtml() {
			return new HtmlResult("<h2>Hello world!</h2>");
		}

		public ActionResult GetImage() {
			string path = "../Images/1.jpg";
			return new ImageResult(path);
		}

		//public string Index() {
		//	string browser = HttpContext.Request.Browser.Browser;
		//	string user_agent = HttpContext.Request.UserAgent;
		//	string url = HttpContext.Request.RawUrl;
		//	string ip = HttpContext.Request.UserHostAddress;
		//	string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
		//	return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
		//		"</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
		//}

	}
}
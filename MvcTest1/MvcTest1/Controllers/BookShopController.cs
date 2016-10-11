using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest1.Controllers {
	public class BookShopController : Controller {
		public ActionResult Index() {
			return View();
		}
	}
}
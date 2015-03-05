using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListDataInGridView()
        {
            System.Web.UI.WebControls.GridView gView = new System.Web.UI.WebControls.GridView();

            using (MvcMusicStoreEntities db = new MvcMusicStoreEntities())
            {
                gView.DataSource = db.Artist.ToList();
                gView.DataBind();
            }

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                {
                    gView.RenderControl(htw);
                    ViewBag.GridViewString = sw.ToString();
                }
            }
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MernisTcDogrulama.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public int TcDogrula(long tcNo, int dogumYili , string ad , string soyad)
        {
            bool? dogruMu = false;
            try
            {
                using (tcKimlikServis.KPSPublicSoapClient tcServis = new tcKimlikServis.KPSPublicSoapClient())
                {
                    dogruMu = tcServis.TCKimlikNoDogrula(tcNo, ad, soyad, dogumYili);
                }
            }
            catch (Exception)
            {
                dogruMu = null;
            }
            if (dogruMu == true)
            {
                return  1; //DOĞRUYSA
            }
            if (dogruMu == false)
            {
                return 2; //YANLIŞSA
            }
            return 0;
        }
    }
}
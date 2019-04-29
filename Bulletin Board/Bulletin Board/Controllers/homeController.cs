using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Bulletin_Board.Models;

namespace Bulletin_Board.Controllers
{
    public class homeController : Controller
    {
        private BulletinBoardDB db = new BulletinBoardDB();
        
        // GET: home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddUser()
        {
            var users = db.Zhibanyuans;
            ViewBag.users = users;
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Zhibanyuan zby)
        {
            if(ModelState.IsValid)
            {
                db.Zhibanyuans.Add(zby);
                db.SaveChanges();

            }
            var users = db.Zhibanyuans;
            ViewBag.users = users;
            return View();
        }

        public ActionResult DeleteUser(int? Id)
        {

            if(Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zhibanyuan zby = db.Zhibanyuans.Find(Id);
            if(zby==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            db.Zhibanyuans.Remove(zby);
            db.SaveChanges();
            return RedirectToAction("AddUser");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Bulletin_Board.Models;
using System.Data;
using System.Data.Entity;

namespace Bulletin_Board.Controllers
{
    public class homeController : Controller
    {
        private BulletinBoardDB db = new BulletinBoardDB();
        
        // GET: home
        public ActionResult Index()
        {

            var rpmsg = db.Msgs.First();
            if(Request["w"]!=null && Request["h"]!=null)
            {
                ViewBag.w = Request["w"];
                ViewBag.h = Request["h"];

            }
            else
            {
                if(db.Msgs.First().screenwidth>0 && db.Msgs.First().screenheight>0)
                {
                    ViewBag.w = db.Msgs.First().screenwidth.ToString() + "px";
                    ViewBag.h = db.Msgs.First().screenheight.ToString() + "px";
                }
                else
                {
                    ViewBag.w = "1920px";
                    ViewBag.h = "1080px";
                }
                
            }
            return View(rpmsg);
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

        public ActionResult EditMessage()
        {

            ViewBag.userlist = new SelectList(db.Zhibanyuans, "Name", "Name");

            try
            {
                if (db.Msgs.Count() > 0)
                {

                    MessageModel msg = db.Msgs.First();
                    return View(msg);
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditMessage(MessageModel remsg)
        {

            //if (!ModelState.IsValid)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ViewBag.userlist = new SelectList(db.Zhibanyuans, "Name", "Name");
            if (db.Msgs.Count()>0)
            {
                
                db.Entry(remsg).State = EntityState.Modified;
                db.SaveChanges();
                
                
            }
            else
            {
                db.Msgs.Add(remsg);
                db.SaveChanges();

            }

            return View(remsg);
        }
    }
}
﻿using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{
    public class SkladController : Controller
    {
        WorkInBDSklad workInBDSklad = new WorkInBDSklad();
        WorkInBDWorkes workWorkes = new WorkInBDWorkes();
        BDContext db = new BDContext();

        //склад

        public ActionResult Index()
        {
            creatSeachName();
            ViewBag.element = " ";
            ViewBag.details = workInBDSklad.GetDeteilAll(Static.UserGame.UserId);
            return View(ViewBag.details);
        }

        private void creatSeachName()
        {
            ViewBag.ListName = "error";
            ViewBag.ListName = workInBDSklad.GetSeachMenu();
        }

        [HttpPost]
        public ActionResult Index(string dropdowntipo, string filtr)
        {
            ViewBag.element = dropdowntipo;
            creatSeachName();
            switch (dropdowntipo)
            {
                case "все":
                    {
                        ViewBag.details = workInBDSklad.GetDeteilAll(Static.UserGame.UserId);
                        return View(db.Details);
                    }
                default:
                    {
                        ViewBag.details = workInBDSklad.GetDeteilSomeBdByName(dropdowntipo, Static.UserGame.UserId);
                        return View(ViewBag.details);
                    }
            }
        }
        public PartialViewResult SkladPartial(string dropdowntipo)
        {
            ViewBag.details = workInBDSklad.GetDeteilSomeBdByName(dropdowntipo, Static.UserGame.UserId);
            return PartialView("SkladPartial", ViewBag.details);
        }
    }
}
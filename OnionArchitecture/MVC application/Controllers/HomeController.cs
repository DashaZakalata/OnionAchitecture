﻿using ApplicationServices;
using DAL;
using DomainCore;
using DomainServices.Repositories;
using MVC_application.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_application.Controllers
{
    public class HomeController : Controller
    {
        IGoodBO goodBO;
        IEnumerable<Good> goods;

        public HomeController(IGoodBO goodBO)
        {
            this.goodBO = goodBO;

            goods = this.goodBO.GetGoods();
        }
        public ActionResult Index(int page = 1)
        {
            try
            {
                var model = new GoodsModel()
                {
                    Goods = GetGoodsForPage(page),
                    PageInfo = GetInfo(page)
                };
                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("InternalServerError", "Errors");
            }

        }

        private IEnumerable<Good> GetGoodsForPage(int page, int pageSize = 2)
        {
            return goods.Skip((page - 1) * pageSize).Take(pageSize);
        }

        private PageInfo GetInfo(int page, int pageSize = 2)
        {
            return new PageInfo()
            {
                CurrentNumber = page,
                TotalQuantity = goods.Count<Good>(),
                PageSize = pageSize,
                PagesCount = (int)Math.Ceiling((decimal)goods.Count<Good>() / pageSize)
            };
        }
    }
}
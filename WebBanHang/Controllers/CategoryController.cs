﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Core;
using WebBanHang.Utils;
using WebBanHang.Core.RepositoryModel;
using PagedList;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CategoryController : BaseController
    {
        GroupProductRepository groupRepository;
        public CategoryController()
        {
            groupRepository = Repository.Bind<GroupProductRepository>();
        }
        //
        // GET: /Category/
        public ActionResult Index(int? id)
        {
            return Detail(id);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("NotFound", "Error");
            var model = Repository.GroupProduct.FindById(id);
            if (model == null) return RedirectToAction("Error404", "Error");
            ViewData["ListColor"] = Repository.Color.FetchAll();
            return View("Detail",model);
        }

        public ActionResult ListGroupProduct(int id)
        {
            dynamic model = new ExpandoObject();
            model.GroupProducts = groupRepository.GetListSubGroups(id);
            model.CurrentGroup = groupRepository.FindById(id);
            return PartialView(model);
        }

        public ActionResult ShowProductInCategory(int id, int? page)
        {
            var config = Repository.Bind<ConfigRepository>().FindById("product_per_page");
            var pageSize = config.Value.ToIntWithDef(1);
            if (pageSize < 1) pageSize = 1;
            int pageNumber = (page ?? 1);

            var model = groupRepository.GetProductInGroups(id, Request.QueryString);

            ViewData["groupID"] = id;
            return PartialView(model.ToPagedList(pageNumber, pageSize));
        }
	}
}
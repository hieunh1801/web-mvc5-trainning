using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesShop.Areas.Admin.Models.Entities;
using ShoesShop.Areas.Admin.Models.Functions;
using ShoesShop.Areas.Admin.Models.ViewModals;
using ShoesShop.Areas.Admin.Security;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class AdminProductDetailController : Controller
    {
        // GET: Admin/AdminProductDetailController
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View("List");
        }

        [HttpGet]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult List()
        {
            AdminProductDetailModal adminProductDetailModal = new AdminProductDetailModal();
            return View(adminProductDetailModal);
        }

        /// <summary>
        /// Insert new product detail for Shoes
        /// </summary>
        /// <param name="idShoes"></param>
        /// <returns></returns>
        [HttpGet]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Insert(int idShoes)
        {
            ViewBag.idShoes = idShoes;
            ColorFunction colorFunction = new ColorFunction();
            SizeFunction sizeFunction = new SizeFunction();
            ViewBag.listColor = colorFunction.GetAll();
            ViewBag.listSize = sizeFunction.GetAll();
            return View();
        }

        [HttpPost]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Insert(ShoesDetail shoesDetail, HttpPostedFileBase photo)
        {
            Console.WriteLine("sdfasjdfh");
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            if (photo != null)
            {
                string path = "/Content/Images/" + photo.FileName;
                photo.SaveAs(Server.MapPath("~" + path));
                shoesDetail.urlImage = path;
            }
            if (shoesDetailFunction.Insert(shoesDetail))
            {
                return RedirectToAction("List", "AdminProductDetail");
            }
            else
            {
                return RedirectToAction("InsertFail", "AdminError");
            };
        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult GetProductDetailListById(int idShoes)
        {
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            List<ShoesDetail> listShoes = shoesDetailFunction.GetAllDetailById(idShoes);
            var result = listShoes.Select(item => new {
                item.idShoesDetail,
                item.idColor,
                item.idShoes,
                item.idSize,
                item.quantity,
                item.urlImage,
            });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult SearchShoes(string searchValue)
        {
            ShoesFunction shoesFunction = new ShoesFunction();
            List<Sho> listShoes = shoesFunction.Search(searchValue);
            var result = listShoes.Select(item => new {
                item.name,
                item.idShoes,
            });
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Delete(int idShoesDetail)
        {
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            shoesDetailFunction.Delete(idShoesDetail);
            var listShoes = shoesDetailFunction.GetAll();
            var result = listShoes.Select(item => new {
                item.idShoesDetail,
                item.idColor,
                item.idShoes,
                item.idSize,
                item.quantity,
                item.urlImage,
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult SearchShoesDetail(string searchValue)
        {
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            List<ShoesDetail> listShoesDetail = shoesDetailFunction.Search(searchValue);
            var result = listShoesDetail.Select(item => new {
                item.idShoesDetail,
                item.idColor,
                item.idShoes,
                item.idSize,
                item.quantity,
                item.urlImage,
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Update(int idShoesDetail)
        {
            ColorFunction colorFunction = new ColorFunction();
            SizeFunction sizeFunction = new SizeFunction();
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            ViewBag.listColor = colorFunction.GetAll();
            ViewBag.listSize = sizeFunction.GetAll();
            ViewBag.idShoesDetail = idShoesDetail;
            ShoesDetail shoesDetail = shoesDetailFunction.GetById(idShoesDetail);
            return View(shoesDetail);
        }
        [HttpPost]
        [MyAdminAuthorize(Roles = "admin")]
        public ActionResult Update(ShoesDetail shoesDetail, HttpPostedFileBase photo)
        {
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            if (photo != null)
            {
                string path = "/Content/Images/" + photo.FileName;
                photo.SaveAs(Server.MapPath("~" + path));
                shoesDetail.urlImage = path;
            }
            if (shoesDetailFunction.Update(shoesDetail))
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("InsertFail", "AdminError");
            }

        }
    }
}
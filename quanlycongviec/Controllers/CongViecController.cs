using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlycongviec.Models;

namespace quanlycongviec.Controllers
{
    public class CongViecController : Controller
    {
        // GET: CongViec
        quanlycongviecEntities db = new quanlycongviecEntities();
        public ActionResult Index()
        {
            List<congviec> danhSachCongViec = db.congviecs.ToList();
            return View(danhSachCongViec);
        }

        public ActionResult AddNewWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewWork(congviec model)
        {
            db.congviecs.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult UpdateWork(int id)
        {
            congviec model = db.congviecs.Find(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateWork(congviec model)

        {
            // Tìm đối tượng cần update
            var updateModel = db.congviecs.Find(model.id);

            // Gán giá trị 
            updateModel.nhanvien = model.nhanvien;
            updateModel.nhanvien_name = model.nhanvien_name;
            updateModel.startday = model.startday;
            updateModel.endday = model.endday;

            // lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteWork(int id)
        {
            // tìm đối tượng cần xóa
            var deleteModel = db.congviecs.Find(id);
            // xóa
            db.congviecs.Remove(deleteModel);
            //lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
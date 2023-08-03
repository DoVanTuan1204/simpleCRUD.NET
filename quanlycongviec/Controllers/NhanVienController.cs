using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlycongviec.Models;

namespace quanlycongviec.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        quanlycongviecEntities db = new quanlycongviecEntities();

        public ActionResult Index()
        {
            List<nhanvien> danhSachNhanVien = db.nhanviens.ToList();
            return View(danhSachNhanVien);
        }

        public ActionResult CreateEmployee()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult CreateEmployee(nhanvien model)
        {
            db.nhanviens.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult UpdateEmployee(int id)
        {
            nhanvien model = db.nhanviens.Find(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(nhanvien model)

        {
            // Tìm đối tượng cần update
            var updateModel = db.nhanviens.Find(model.id);

            // Gán giá trị 
            updateModel.name = model.name;
            updateModel.title= model.title;

            // lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult DeleteEmployee(int id)
        {
            // tìm đối tượng cần xóa
            var deleteModel = db.nhanviens.Find(id);
            // xóa
            db.nhanviens.Remove(deleteModel);
            //lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
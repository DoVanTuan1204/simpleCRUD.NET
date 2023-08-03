using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlycongviec.Models;
namespace quanlycongviec.Controllers
{
    public class ChucDanhController : Controller
    {
        // GET: ChucDanh
        quanlycongviecEntities db = new quanlycongviecEntities();
        public ActionResult Index()
        {
            List<vitri> danhSachViTri = db.vitris.ToList(); 
            return View(danhSachViTri);
        }

        public ActionResult AddNewTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewTitle(vitri model) {

            db.vitris.Add(model);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
         public ActionResult UpdateTitle (int id)
        {
            //3. Tìm đối tượng theo ID
            
            // cách 1:
           // KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            
            // cách 2:
            vitri model = db.vitris.Find(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateTitle(vitri model)

        {
            // Tìm đối tượng cần update
            var updateModel = db.vitris.Find(model.id);

            // Gán giá trị 
            updateModel.titlename = model.titlename;

            // lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteTitle(int id)
        {
            // tìm đối tượng cần xóa
            var deleteModel = db.vitris.Find(id);
            // xóa
            db.vitris.Remove(deleteModel);
            //lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
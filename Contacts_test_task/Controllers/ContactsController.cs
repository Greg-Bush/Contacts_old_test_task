using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts_test_task.Workers;
using Contacts_test_task.Models;

namespace Contacts_test_task.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsManager _manager;

        private ContactsManager contactsManager
        {
            get
            {
                return _manager ?? new ContactsManager(
                    new DataProvider(HttpContext.Server.MapPath("~/App_Data") + "/MOCK_DATA.json"),
                    new CacheProvider());
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Search(SearchModel searchFilter, PaginationModel pageFilter)
        {
            return PartialView("ContactsPartial", contactsManager.GetContacts(pageFilter, searchFilter));
        }

        public JsonResult Remove(Guid id)
        {
            contactsManager.RemoveContact(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Item model)
        {
            model.id = Guid.NewGuid();
            model.date = DateTime.Now;
            contactsManager.AddContact(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Item model)
        {
            contactsManager.UpdateContact(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
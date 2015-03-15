using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MongoDB.Bson;
using passstore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        #region Home
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }
        #endregion

        #region Login
        public PartialViewResult ViewLogin()
        {
            return PartialView();
        }
        public JsonResult Login(string username, string password)
        {
            var user = new User { Username = username, MasterPassword = password };
            user.Auth();

            if (user.MasterPassword != null)
            {
                Session["user"] = user;
                Session["auth"] = true;
                return Json(user.Name, JsonRequestBehavior.AllowGet);
            }
            Session["user"] = null;
            Session["auth"] = false;
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public void Logout()
        {
            Session["user"] = null;
        }
        public JsonResult Auth()
        {
            var user = (User)Session["user"];
            if (Session["auth"] != null) if ((bool)Session["auth"]) return Json(user.Name, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Passstore
        public JsonResult GetPasswords()
        {
            var t = Task.Run(() =>
            {
                List<Password> passwords = new Passstore().GetEncryptedPasswords((User)Session["user"]);
                var modelPasss = new List<pass>();

                Parallel.ForEach(passwords, p =>
                {
                    var pass = new pass();
                    pass.Name = p.Name;
                    pass.Username = p.Username;
                    pass.PassId = p._id.ToString();

                    modelPasss.Add(pass);
                });

                return Json(modelPasss, JsonRequestBehavior.AllowGet);
            });
            t.Wait();
            return t.Result;
        }

        public JsonResult ShowPassword(string strId)
        {
            var passId = new ObjectId();
            ObjectId.TryParse(strId, out passId);

            Password pass = new Passstore().GetDecryptedPassword((User)Session["user"], passId);

            return Json(pass.Pass, JsonRequestBehavior.AllowGet);
        }

        public void AddPass(string name, string username, string password)
        {
            new Passstore().AddPass((User)Session["user"], name, username, password);
        }

        public void DeletePass(string strId)
        {
            var passId = new ObjectId();
            ObjectId.TryParse(strId, out passId);

            new Passstore().RemovePass((User)Session["user"], passId);
        }
        #endregion
    }
}
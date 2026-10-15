using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Net;
using System.Text;
using Newtonsoft.Json;
namespace Alliance_Air_Desk.Controllers
{
    public class KnowledgeMgntController : Controller
    {

        string BriefingDate;
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: KnowledgeMgnt


        public ActionResult Index()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 4)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, KnowledgeMgntModel mod)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                DBHandler _dbcontext = new DBHandler();

                if (file.ContentLength > 0)
                {
                    string _FName = string.Format(@"{0}.pdf", Guid.NewGuid() + "_" + DateTime.Now.ToString("yyyy-dd-M"));
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Inputfile"), _FName);
                    string _Extension = Path.GetExtension(_FileName);

                    mod.FileName = _FName.ToString();
                    mod.FilePath = "~/Inputfile/" + _FName.ToString();
                    mod.FileExtension = _Extension.ToString();
                    if (mod.FileExtension == ".pdf")
                    {

                        file.SaveAs(_path);
                        dt = _dbcontext.Add_File(mod.FileName, mod.FileExtension, mod.FilePath, _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                        if (dt.Rows.Count > 0)
                        {
                            ModelState.Clear();
                            TempData["Message"] = "File Added Successfully";
                        }
                        else
                        {
                            ModelState.Clear();
                            TempData["ErrorMessage"] = "File Not Added";

                        }

                    }
                    else
                    {
                        ModelState.Clear();
                        TempData["ErrorMessage"] = "Please choose a pdf file ";
                    }

                }
                return View();
            }
            catch
            {
                TempData["ErrorMessage"] = "File upload failed!!";
                return View();
            }

        }

        public ActionResult Document()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            System.Data.DataTable dt = new System.Data.DataTable();
            DBHandler _dbcontext = new DBHandler();


            dt = _dbcontext.Get_UI_Element("FileUpload", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
            if (dt.Rows.Count > 0)
            {
                string FileName = dt.Rows[0]["FileName"].ToString();
                string FilePath = dt.Rows[0]["Filepath"].ToString();
                string fullPath = Path.Combine(Server.MapPath("~/Inputfile"), FileName);
                byte[] FileBytes = System.IO.File.ReadAllBytes(fullPath);
                return File(FileBytes, "application/pdf");

            }
            //string ReportURL = "637736104866561956.pdf";
            //string fullPath = Path.Combine(Server.MapPath("~/Inputfile"), ReportURL);
            //byte[] FileBytes = System.IO.File.ReadAllBytes(fullPath);

            //return File(FileBytes, "application/pdf");

            return View();
        }



        public ActionResult Displayer()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);

            return View();
        }


        public ActionResult Briefing()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            System.Data.DataTable dt = new System.Data.DataTable();
            DBHandler _dbcontext = new DBHandler();
            try
            {
                if (_userdetails.userName != null)
                {
                    Classes.SessionHandler.ValidateSession(ref _userdetails);
                    //DBContext _dbcontext = new DBContext();

                    //DataTable dt = _dbcontext.Get_UI_Element("Add_Briefing_Details", "", "", "", _userdetails.userId, _userdetails.privilege.ToString(), _userdetails.region.ToString(), _userdetails.userType);
                    dt = _dbcontext.Get_UI_Element("Add_Briefing_Details", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());

                    string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
                    string filePath = Server.MapPath("~/Input/" + currentDate + ".txt");
                    // Read the saved text file content


                    // Pass the file content to the view
                    if (System.IO.File.Exists(filePath))
                    {
                        string fileContent = System.IO.File.ReadAllText(filePath);
                        ViewBag.FileContent = fileContent;
                    }
                    else
                    {
                        ViewBag.FileContent = null;
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBriefing(KnowledgeMgntModel model)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            System.Data.DataTable dt = new System.Data.DataTable();
            DBHandler _dbcontext = new DBHandler();
            Classes.SessionHandler.ValidateSession(ref _userdetails);

            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            string filePath = Server.MapPath("~/Input/" + currentDate + ".txt");
            System.IO.File.WriteAllText(filePath, model.BriefingText, Encoding.UTF8);

            // Read the saved text file content
            string fileContent = System.IO.File.ReadAllText(filePath);
            string fileContent2 = fileContent.Replace("'", "''");

            //DBContext _dbcontext = new DBContext();
            //DataTable dt = _dbcontext.Get_UI_Elements_Data("Add_Briefing_Upload", fileContent2 ?? "", "", "", _userdetails.userId, _userdetails.privilege.ToString(), _userdetails.region.ToString(), _userdetails.userType);
            dt = _dbcontext.Get_UI_Element("Add_Briefing_Upload", fileContent2 ?? "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());

            // Clear the BriefingText in the model
            model.BriefingText = "";

            // Pass the file content to the view
            ViewBag.FileContent = fileContent;

            return View("Briefing", model);
        }


        [HttpPost]
        public ActionResult OpenFile(KnowledgeMgntModel _mod)

        {

            try
            {
                if (!string.IsNullOrEmpty(_mod.BriefingDate))
                {
                    BriefingDate = DateTime.Parse(_mod.BriefingDate).ToString("dd-MM-yyyy");
                }

                string filePath = Server.MapPath("~/Input/" + BriefingDate + ".txt");

                // Log the file path for debugging purposes
                System.Diagnostics.Debug.WriteLine("File path: " + filePath);

                if (System.IO.File.Exists(filePath))
                {
                    // Read the file content if it exists
                    string fileContent = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
                    // Pass the file content to the view
                    var response = new { success = true, fileContent };
                    return Json(response);
                }
                else
                {
                    return Json(new { success = false, errorMessage = "File does not exist." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                return Json(new { success = false });
            }

        }
    }
}
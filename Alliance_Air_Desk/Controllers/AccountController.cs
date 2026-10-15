using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        Classes.UserDetails _userdetails = new Classes.UserDetails();

        // GET: Account
        public ActionResult Index()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 4)
                {
                    string UserName = _userdetails.userID;
                    DBHandler _dbcontext = new DBHandler();
                    var list = _dbcontext.GetAddedUser("UserList", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    if (ModelState.IsValid)
                    {
                        return View(list);
                    }
                    else
                    {
                        return View();
                    }
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


        public void Export_User_List()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                Classes.ListToDataTable listDt = new Classes.ListToDataTable();
                Classes.Export Exp = new Classes.Export();
                DataTable dt = new DataTable();

                string UserName = _userdetails.userID;
                DBHandler _dbcontext = new DBHandler();
                var list = _dbcontext.GetAddedUser("UserList", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                dt = listDt.ToDataTable(list);
                dt.Columns.Remove("GUID");
                if (dt.Rows.Count > 0)
                {
                    Exp.ExportExcel(dt, "User_List" + DateTime.Now.ToString("mm_ss"));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        public ActionResult UserMaster(string id)
        {

            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 4)
                {
                    DataTable dt = new DataTable();
                    DBHandler _dbcontext = new DBHandler();
                    AccountModel _model = new AccountModel();                   
                    ViewBag.Privilege_List = _dbcontext.Get_UI_Element_List("Privilege", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();                    
                    ViewBag.Region_List = _dbcontext.Get_UI_Element_List("Region", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.Status_List = _dbcontext.Get_UI_Element_List("User_Status", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                    if (id != null)
                    {
                        if (id.Length > 0)
                        {
                            dt = _dbcontext.Get_UI_Element("Get_User_Details", id??"", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                            if (dt.Rows.Count > 0)
                            {
                                _model.userId = dt.Rows[0]["userId"].ToString();
                                _model.password = dt.Rows[0]["password"].ToString();
                                _model.empCode = dt.Rows[0]["empCode"].ToString();
                                _model.empName = dt.Rows[0]["empName"].ToString();
                                _model.privilege = dt.Rows[0]["privilege"].ToString();
                                _model.region = dt.Rows[0]["region"].ToString();
                                _model.status = dt.Rows[0]["status"].ToString();
                                _model.guid = dt.Rows[0]["guid"].ToString();
                            }
                        }
                    }
                    return View(_model);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        
        [HttpPost]
        public ActionResult UserMaster(AccountModel mod)
        {

            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 4)
                {
                    DBHandler _dbcontext = new DBHandler();
                    AccountModel _model = new AccountModel();

                    DataTable dt = new DataTable();

                    dt = _dbcontext.Manage_User_Master(
                        mod.guid??"",
                        mod.userId??"",
                        mod.password??"",
                        mod.empCode??"",
                        mod.empName??"",
                        mod.privilege??"",
                        mod.region??"",
                        mod.status??"",
                        _userdetails.userID,
                        _userdetails.privilege.ToString()
                        );
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("ADDED"))
                        {
                            ModelState.Clear();
                            TempData["Message"] = "User Added Successfully";

                            return RedirectToAction("UserMaster", "Account", new { id = "" });
                        }
                        else if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("UPDATED"))
                        {
                            ModelState.Clear();
                            TempData["Message"] = "User Modified Successfully";
                            return RedirectToAction("UserMaster", "Account", new { id = "" });
                        }
                        else
                        {
                            TempData["ErrorMessage"] = dt.Rows[0]["MSG"].ToString();
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong";
                    }
                    

                    ViewBag.Privilege_List = _dbcontext.Get_UI_Element_List("Privilege", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.Region_List = _dbcontext.Get_UI_Element_List("Region", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.Status_List = _dbcontext.Get_UI_Element_List("Status", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                    return View(_model);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



    }
}
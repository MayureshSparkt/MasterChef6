using MC.BusinessAccess.Interface;
using MC.Entities;
using MC.Logging;
using MC.Web.Areas.TWFzdGVyQ2hlZg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.Web.Areas.TWFzdGVyQ2hlZg.Controllers
{
    public class AuditionController : Controller
    {
        private readonly IAuditionBusinessAccess _AuditionBusinessAccess;
        private readonly ICityBusinessAccess _cityBusinessAccess;

        public AuditionController(IAuditionBusinessAccess AuditionDataAccess, ICityBusinessAccess cityDataAccess)
        {
            _AuditionBusinessAccess = AuditionDataAccess;
            _cityBusinessAccess = cityDataAccess;
        }


        // GET: TWFzdGVyQ2hlZg/Audition
        public ActionResult Index()
        {
            try
            {
                ViewBag.City = _cityBusinessAccess.GetCity();
                return View();
            }
            catch (Exception ex)
            {

                LogService.Log("Exception Message: "+ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        [HttpPost]
        public JsonResult GetAudditionContent(string FilterData, int currentPage, int pageSize)
        {

            string[] Parameters;
            if (FilterData != string.Empty)
            {
                Parameters = FilterData.Split(',');
                FilterData = string.Empty;
                if (Parameters[0] != string.Empty)
                {
                    FilterData += " AND c.City LIKE '%" + Parameters[0] + "%' ";

                }
                if ((Parameters[1] != string.Empty) && (Parameters[1] != "undefined"))
                {
                    FilterData += " AND Ad.Date  LIKE '%" + Parameters[1] + "%' ";
                }

                if (Parameters[2] != string.Empty)
                {
                    FilterData += " AND Ad.Venue = '" + Parameters[2] + "' ";
                }

                if (Parameters[3] != string.Empty)
                    FilterData += " AND Ad.Day = '" + Parameters[3] + "' ";

                if (Parameters[4] != string.Empty)
                    FilterData += " AND Ad.IsActive = '" + Parameters[4] + "' ";
            }
            else
            {
                FilterData = string.Empty;
            }


            var adminUserContents = _AuditionBusinessAccess.GetAudition(FilterData, currentPage, pageSize).ToList();//.OrderBy(s => s.SortOrder).
            return new JsonResult()
            {
                Data = adminUserContents,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult Modify(AuditionViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new AuditionModel()
                    {
                        CityId = viewModel.CityId,
                        Venue = viewModel.Venue,
                        CreatedBy = new Guid(),
                        CreatedDate = DateTime.UtcNow,
                        AuditionId = viewModel.AuditionId,
                        IsActive = viewModel.IsActive,
                        PlaceId = viewModel.PlaceId,
                        Day = viewModel.Day,
                        Date = viewModel.Date,
                        MaxDate = viewModel.MaxDate
                    };

                    var response = _AuditionBusinessAccess.InsertUpdateAudition(entity);

                    return Json(new { Status = response, Message = response ? "Audition Content Saved Successfully." : "Something went wrong. Please try after sometime." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { Status = false, Message = "Something went wrong. Please try after sometime." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogService.Log(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }


        [HttpPost]
        public ActionResult GetAuditionById(int auditionId)
        {
            bool status = false;
            AuditionModel auditionEntity = new AuditionModel();
            try
            {
                auditionEntity = _AuditionBusinessAccess.GetAuditionById(auditionId);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(new { Status = status, Audition = auditionEntity }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]

        public ActionResult DeleteAudition(int auditionId)
        {
            if (auditionId != 0)
            {
                var result = _AuditionBusinessAccess.DeleteAudition(auditionId);
                return Json(new { Status = result, Message = result ? $"Audition deleted successfully." : $"Something went wrong while deleting audition." });
            }
            else
            {
                return Json(new { Status = false, Message = "It seems audition does not exist." });
            }
        }
    }
}
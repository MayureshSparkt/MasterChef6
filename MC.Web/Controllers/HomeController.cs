using MC.BusinessAccess.Interface;
using MC.Entities;
using MC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICityBusinessAccess _cityBusinessAccess;

        private readonly IAuditionBusinessAccess _auditionBusinessAccess;
        public HomeController(ICityBusinessAccess cityBusinessAccess, IAuditionBusinessAccess auditionBusinessAccess)
        {
            _auditionBusinessAccess = auditionBusinessAccess;
            _cityBusinessAccess = cityBusinessAccess;
        }
        public ActionResult Index()
        {
            try
            {

                HomeViewModel homeViewModel = new HomeViewModel();
                List<CityModel> city = _cityBusinessAccess.GetAuditionCity().OrderBy(c => c.City).ToList();
                if (city.Count > 0)
                {
                    homeViewModel = GetViewModel(city.FirstOrDefault().CityId);
                }
                ViewBag.City = city;
                return View(homeViewModel);
            }
            catch (Exception ex)
            {

                //LogService.Log(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public HomeViewModel GetViewModel(int cityId)
        {
            try
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                if (cityId != 0)
                {
                    homeViewModel.CityId = cityId;
                    homeViewModel.AuditionList = _auditionBusinessAccess.GetAuditionByCityId(cityId);
                }
                return homeViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]

        public ActionResult GetLocationVenue(int cityId)
        {
            try
            {
                List<AuditionModel> auditionModels = _auditionBusinessAccess.GetAuditionByCityId(cityId);
                return PartialView("_AuditionDayLocation", auditionModels);
            }
            catch (Exception ex)
            {

                //LogService.Log(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

    }
}
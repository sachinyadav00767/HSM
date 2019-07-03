﻿using HMS.Services;
using HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class AccomodationsController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        AccomodationPackagesService accomodationPackagesService = new AccomodationPackagesService();
        AccomodationsService accomodationsService = new AccomodationsService();

        public ActionResult Index(int accomodationTypeID, int? accomodationPackageID)
        {
            AccomodationsViewModel model = new AccomodationsViewModel();

            model.AccomodationType = accomodationTypesService.GetAccomodationTypeByID(accomodationTypeID);

            model.AccomodationPackages = accomodationPackagesService.GetAllAccomodationPackagesByAccomodationType(accomodationTypeID);

            model.SelectedAccomodationPackageID = accomodationPackageID.HasValue ? accomodationPackageID.Value : model.AccomodationPackages.First().ID;

            model.Accomodations = accomodationsService.GetAllAccomodationsByAccomodationPackage(model.SelectedAccomodationPackageID);

            return View(model);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using Momntz.Data.Commands.Momentos;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Api;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class MomentoController : BaseController
    {
        private readonly ICommandProcessor _processor;
        private readonly IProjectionProcessor _projection;

        public MomentoController(ICommandProcessor processor, IProjectionProcessor projection)
        {
            _processor = processor;
            _projection = projection;
        }

        [HttpPost]
        public ActionResult Save(int id, string title, string story, int? day, int? month, int? year, string albums, string location)
        {
            _processor.Process(new SaveMomentoDetailsCommand(id, title, story, day, month, year, albums, location, GetUsername()));
            return Content("1");
        }

        public ActionResult LocationSearch(string term)
        {
            string username = GetUsername();
            var results =
                _projection.Process<LocationAutoCompleteParameters, List<LocationAutoComplete>>(
                    new LocationAutoCompleteParameters() {Term = term, Username = username});
            
            return Json(results.Select(a=> new AutoComplete(a.Location)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ById(int id)
        {
            MomentoDetail detail = _projection.Process<int, MomentoDetail>(id) ?? new MomentoDetail();

            Func<string, string> convertNullToEmptyString = (s => s ?? string.Empty); 

                return Json(new
                                {
                                    Added = detail.Added.HasValue ? detail.Added.Value.ToString("MMMM dd, yyyy") : string.Empty,
                                    AddedUrl = detail.Added.HasValue ? string.Format("{0}/{1}/{2}", detail.Added.Value.Year, detail.Added.Value.Month, detail.Added.Value.Day) : string.Empty,
                                    detail.AddedUsername,
                                    Albums = detail.Albums.Select(a=> a.Name).ToArray(),
                                    detail.Day,
                                    DisplayName = convertNullToEmptyString(detail.DisplayName),
                                    Location = convertNullToEmptyString(detail.Location),
                                    Month = convertNullToEmptyString(detail.Month),
                                    People = detail.People.Select(p=>new {p.Username, p.Name}),
                                    Story = convertNullToEmptyString(detail.Story),
                                    Username = convertNullToEmptyString(detail.Username),
                                    Title = convertNullToEmptyString(detail.Title), 
                                    Year = convertNullToEmptyString(detail.Year) 
                                });

        }
    }
}

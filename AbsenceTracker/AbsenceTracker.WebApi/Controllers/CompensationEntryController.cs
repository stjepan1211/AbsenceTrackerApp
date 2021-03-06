﻿using AbsenceTracker.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AbsenceTracker.WebApi.ViewModels;
using System.Threading.Tasks;
using AbsenceTracker.Model.DomainModels;

namespace AbsenceTracker.WebApi.Controllers
{
    [RoutePrefix("api/compensationentry")]
    public class CompensationEntryController : ApiController
    {
        protected ICompensationEntryService CompensationEntryService;

        public CompensationEntryController(ICompensationEntryService service)
        {
            this.CompensationEntryService = service;
        }
     
        [HttpGet]
        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<CompensationEntryView>>(await CompensationEntryService.ReadAll());

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                var response = AutoMapper.Mapper.Map<CompensationEntryView>(await CompensationEntryService.Read(id));

                if (response == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bad id.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(CompensationEntryView compensationEntryView)
        {
            try
            {
                if (compensationEntryView.Date == null || compensationEntryView.SpentTime == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Krivi unos.");

                compensationEntryView.Id = Guid.NewGuid();

                var response = await CompensationEntryService.Add(Mapper.Map<CompensationEntryDomain>(compensationEntryView));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = await CompensationEntryService.Delete(id);

                if (response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't delete entry.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<HttpResponseMessage> Update(CompensationEntryView compensationEntryView)
        {
            try
            {
                var toBeUpdated = await CompensationEntryService.Read(compensationEntryView.Id);

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entry not found");

                if (compensationEntryView.Date != null)
                    toBeUpdated.Date = compensationEntryView.Date;
                if (compensationEntryView.SpentTime != 0)
                    toBeUpdated.SpentTime = compensationEntryView.SpentTime;

                var response = await CompensationEntryService.Update(Mapper.Map<CompensationEntryDomain>(toBeUpdated));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

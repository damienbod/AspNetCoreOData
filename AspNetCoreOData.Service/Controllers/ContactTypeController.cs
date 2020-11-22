﻿using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

using  AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace  AspNetCoreOData.Service.Controllers
{
    [Authorize(Policy = "ODataServiceApiPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ODataRoutePrefix("ContactType")]
    public class ContactTypeController : ODataController
    {
        private AdventureWorks2016Context _db;

        public ContactTypeController(AdventureWorks2016Context AdventureWorks2016Context)
        {
            _db = AdventureWorks2016Context;
        }

        [ODataRoute()]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get()
        {
            return Ok(_db.ContactTypes.AsQueryable());
        }

        [ODataRoute()]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.ContactTypes.Find(key));
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Post(ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.ContactTypes.AddOrUpdate(contactType);
            _db.SaveChanges();
            return Created(contactType);
        }


        [ODataRoute("({key})")]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Put([FromODataUri] int key, ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != contactType.ContactTypeId)
            {
                return BadRequest();
            }

            _db.ContactTypes.AddOrUpdate(contactType);
            _db.SaveChanges();

            return Updated(contactType);
        }

        [ODataRoute("")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Delete([FromODataUri] int key)
        {
            var entityInDb = _db.ContactTypes.SingleOrDefault(t => t.ContactTypeId == key);
            _db.ContactTypes.Remove(entityInDb);
            _db.SaveChanges();

            return NoContent();
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Patch([FromODataUri] int key, Delta<ContactType> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactType = _db.ContactTypes.Single(t => t.ContactTypeId == key);
            delta.Patch(contactType);
            _db.SaveChanges();
            return Updated(contactType);
        }

        /// <summary>
        /// This is a Odata Action for complex data changes...
        /// </summary>
        [HttpPost]
        [ODataRoute("Default.ChangePersonStatus")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult ChangePersonStatus(ODataActionParameters parameters)
        {
            if (ModelState.IsValid)
            {
                var level = parameters["Level"];
                // SAVE THIS TO THE DATABASE OR WHATEVER....
            }

            return Ok(true);
        }
    }
}


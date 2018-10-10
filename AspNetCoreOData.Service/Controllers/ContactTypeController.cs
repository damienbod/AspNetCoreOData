using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

using  AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;

namespace  AspNetCoreOData.Service.Controllers
{
    [ODataRoutePrefix("ContactType")]
    public class ContactTypeController : ODataController
    {
        private DomainModelContext _db;

        public ContactTypeController(DomainModelContext domainModelContext)
        {
            _db = domainModelContext;
        }

        [ODataRoute()]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get()
        {
            return Ok(_db.ContactType.AsQueryable());
        }

        [ODataRoute()]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.ContactType.Find(key));
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

            _db.ContactType.AddOrUpdate(contactType);
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

            if (key != contactType.ContactTypeID)
            {
                return BadRequest();
            }

            _db.ContactType.AddOrUpdate(contactType);
            _db.SaveChanges();

            return Updated(contactType);
        }

        [ODataRoute("")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Delete([FromODataUri] int key)
        {
            var entityInDb = _db.ContactType.SingleOrDefault(t => t.ContactTypeID == key);
            _db.ContactType.Remove(entityInDb);
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

            var contactType = _db.ContactType.Single(t => t.ContactTypeID == key);
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


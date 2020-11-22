using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AspNetCoreOData.Service.Controllers
{
    // This is removed so that the demo service works in the browser without authorization. Not recommended
    //[Authorize(Policy = "ODataServiceApiPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[ODataRoutePrefix("Person")]
    public class PersonController : ODataController
    {
        private AdventureWorks2016Context _db;

        public PersonController(AdventureWorks2016Context AdventureWorks2016Context)
        {
            _db = AdventureWorks2016Context;
        }

        [HttpGet("odata/Person")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions= AllowedQueryOptions.All)]
        public IActionResult Get()
        {  
            return Ok(_db.People.AsQueryable());
        }

        [HttpGet("odata/Person({key})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.People.Find(key));
        }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [ODataRoute("Default.MyFirstFunction")]
        [HttpGet]
        public IActionResult MyFirstFunction()
        {
            return Ok(_db.People.Where(t => t.FirstName.StartsWith("K")));
        }

 

        //[HttpGet]
        //[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[ODataRoute("Default.PersonSearchPerPhoneType(PhoneNumberTypeEnum={phoneNumberTypeEnum})")]
        //public IActionResult PersonSearchPerPhoneType([FromODataUri] PhoneNumberTypeEnum phoneNumberTypeEnum)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return Ok("");
        //}
    }
}

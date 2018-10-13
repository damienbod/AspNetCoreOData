using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using  AspNetCoreOData.Service.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace  AspNetCoreOData.Service.Controllers
{
    [Authorize(Policy = "ODataServiceApiPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ODataRoutePrefix("EntityWithEnum")]
    public class EntityWithEnumController : ODataController
    {
        private List<EntityWithEnum> someData = new List<EntityWithEnum>();

        public EntityWithEnumController()
        {
            someData.Add(new EntityWithEnum { Description = "test1", Name = "Van", PhoneNumberType = PhoneNumberTypeEnum.Home});
            someData.Add(new EntityWithEnum { Description = "test2", Name = "Bill", PhoneNumberType = PhoneNumberTypeEnum.Work });
            someData.Add(new EntityWithEnum { Description = "test3", Name = "Rob", PhoneNumberType = PhoneNumberTypeEnum.Cell });
        }

        [ODataRoute]
        [EnableQuery(PageSize = 20)]
        public IActionResult Get()
        {
            return Ok(someData);
        }

        [ODataRoute]
        [EnableQuery(PageSize = 20)]
        public IActionResult Get([FromODataUri] string key)
        {
            if (someData.Exists(t => t.Name == key))
            {
                return Ok(someData.FirstOrDefault(t => t.Name == key));
            }

            return BadRequest("key does not key");
        }

        [HttpPost]
        [ODataRoute]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Post(EntityWithEnum entityWithEnum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Created(entityWithEnum);
        }

        [HttpGet]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [ODataRoute("Default.PersonSearchPerPhoneType(PhoneNumberTypeEnum={phoneNumberTypeEnum})")]
        public IActionResult PersonSearchPerPhoneType([FromODataUri] PhoneNumberTypeEnum phoneNumberTypeEnum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(someData.Where(t => t.PhoneNumberType.Equals(phoneNumberTypeEnum)));
        }

    }
}

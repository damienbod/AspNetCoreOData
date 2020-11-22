using System.Linq;
using Microsoft.AspNetCore.Mvc;
using  AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace  AspNetCoreOData.Service.Controllers
{
    [Authorize(Policy = "ODataServiceApiPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BusinessEntityController : ODataController
    {
        private AdventureWorks2016Context _db;

        public BusinessEntityController(AdventureWorks2016Context AdventureWorks2016Context)
        {
            _db = AdventureWorks2016Context;
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get()
        {
            return Ok(_db.BusinessEntities.AsQueryable());
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.BusinessEntities.Find(key));
        }
    }
}

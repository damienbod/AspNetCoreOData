using System.Linq;
using Microsoft.AspNetCore.Mvc;
using  AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;

namespace  AspNetCoreOData.Service.Controllers
{
    public class BusinessEntityAddressController : ODataController
    {
        private DomainModelContext _db;

        public BusinessEntityAddressController(DomainModelContext domainModelContext)
        {
            _db = domainModelContext;
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get()
        {
            return Ok(_db.BusinessEntityAddress.AsQueryable());
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.BusinessEntityAddress.Find(key));
        }
    }
}

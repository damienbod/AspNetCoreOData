using System.Linq;
using AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreOData.Service.Controllers
{
    public class AddressController : ODataController
    {
        private DomainModelContext _db;

        public AddressController(DomainModelContext domainModelContext)
        {
            _db = domainModelContext;
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get()
        {
            return Ok(_db.Address.AsQueryable());
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.Address.Find(key));
        }
    }
}

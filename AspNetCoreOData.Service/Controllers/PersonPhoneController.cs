
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using  AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;

namespace  AspNetCoreOData.Service.Controllers
{
    public class PersonPhoneController : ODataController
    {
        private DomainModelContext _db;

        public PersonPhoneController(DomainModelContext domainModelContext)
        {
            _db = domainModelContext;
        }

        private static readonly ODataValidationSettings _validationSettings = new ODataValidationSettings();

        [EnableQuery(PageSize = 20)]
        public IActionResult Get()
        {
            return Ok(_db.PersonPhone.AsQueryable());
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.PersonPhone.Find(key));
        }
    }
}

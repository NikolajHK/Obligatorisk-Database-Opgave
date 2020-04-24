using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelKlasser;
using DBContext;

namespace Obligatorisk_database_opgave.Controllers
{
    public class FaciliteterController : ApiController
    {
        // GET: api/Faciliteter
        public IEnumerable<ModelKlasser.Faciliteter> Get()
        {
            return new DBContext.ManageFaciliteter().GetAllFaciliteter();
        }

        // GET: api/Faciliteter/5
        public Faciliteter Get(int id)
        {
            return new ManageFaciliteter().GetFaciliteterFromId(id);
        }

        // POST: api/Faciliteter
        public void Post([FromBody]Faciliteter value)
        {
            new ManageFaciliteter().CreateFacilitetet(value);
        }

        // PUT: api/Faciliteter/5
        public void Put(int id, [FromBody]Faciliteter value)
        {
            new ManageFaciliteter().UpdateFacilitet(id, value);
        }

        // DELETE: api/Faciliteter/5
        public void Delete(int id)
        {
            new ManageFaciliteter().DeleteFacilitet(id);
        }
    }
}

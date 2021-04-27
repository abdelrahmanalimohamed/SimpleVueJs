using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Database;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private MyDBContexts MyDBContexts;

        public CountryController(MyDBContexts myDBContexts)
        {
            this.MyDBContexts = myDBContexts;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var value = (from a in MyDBContexts.Countries
                         join b in MyDBContexts.Regions
                         on a.region_id equals b.region_id
                         select new
                        {
                            a.Country_id,
                            a.Country_name,
                            b.region_name
                        }).ToList();



            return Ok(value);
        }


        [HttpGet]
        [Route("singlecountry/{id}")]

        public ActionResult GetCountry(string id)
        {
            var country = (from a in MyDBContexts.Countries
                           join b in MyDBContexts.Regions
                           on a.region_id equals b.region_id
                           where a.Country_id == id
                           select new
                           {   a.Country_id , 
                               a.Country_name , 
                               b.region_name
                           }).FirstOrDefault();

            return Ok(country);
        }

        [HttpDelete]
        [Route("deletecountry/{id}")]
        public ActionResult DeleteCountry(string id)
        {
            try
            {
                var SelectQuery = (from a in MyDBContexts.Countries
                               where a.Country_id == id
                               select a).FirstOrDefault();

               var deleted = MyDBContexts.Countries.Remove(SelectQuery);

                var check = MyDBContexts.SaveChanges();

                if (check > 0)
                {
                    return Ok("Deleted");
                }
                else
                {
                    return Ok("Not Deleted");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("regions")]
        public ActionResult GetRegions()
        {
            try
            {
                var regions = (from a in MyDBContexts.Regions
                               select a).ToList();

                return Ok(regions);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("insertcountry")]

        public ActionResult InsertCountry([FromBody] Country country)
        {
            try
            {
                country.region_id = 3;

                var insert = MyDBContexts.Countries.Add(country);

                var check = MyDBContexts.SaveChanges();

                if (check > 0)
                {
                    return Ok("Inserted");
                }
                else
                {
                    return Ok("Not Inserted");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

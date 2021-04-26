using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Country
    {
        [Key]
        public string Country_id { get; set; }

        public string Country_name { get; set; }

        public int region_id { get; set; }


    }
}

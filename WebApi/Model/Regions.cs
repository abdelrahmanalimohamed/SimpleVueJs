using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Regions
    {
        [Key]
        public int region_id { get; set; }

        public string region_namee { get; set; }

    }
}

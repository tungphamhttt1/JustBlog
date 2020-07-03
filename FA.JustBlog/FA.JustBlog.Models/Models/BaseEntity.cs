using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        //[ScaffoldColumn(false)]
        //public DateTime CreatedDate { get; set; } = DateTime.Now;

        //[MaxLength(256)]
        //[ScaffoldColumn(false)]
        //public string CreatedBy { get; set; }

        //[ScaffoldColumn(false)]
        //public DateTime UpdatedDate { get; set; } = DateTime.Now;

        //[MaxLength(256)]
        //[ScaffoldColumn(false)]
        //public string UpdatedBy { get; set; }
    }
}

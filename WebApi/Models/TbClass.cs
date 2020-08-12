using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class TbClass
    {
        public TbClass()
        {
            TbStu = new HashSet<TbStu>();
        }

        public string ClassId { get; set; }
        public string ClassName { get; set; }

        public virtual ICollection<TbStu> TbStu { get; set; }
    }
}

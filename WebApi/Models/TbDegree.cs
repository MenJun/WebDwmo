using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class TbDegree
    {
        public TbDegree()
        {
            TbStu = new HashSet<TbStu>();
        }

        public int DegreeId { get; set; }
        public string DegreeName { get; set; }

        public virtual ICollection<TbStu> TbStu { get; set; }
    }
}

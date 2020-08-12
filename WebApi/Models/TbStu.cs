using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class TbStu
    {
        public string StuId { get; set; }
        public string StuName { get; set; }
        public bool? StuSex { get; set; }
        public string StuImage { get; set; }
        public DateTime StuBirthday { get; set; }
        public string StuHobby { get; set; }
        public string StuPhone { get; set; }
        public string StuAddress { get; set; }
        public string ClassId { get; set; }
        public int DegreeId { get; set; }

        public virtual TbClass Class { get; set; }
        public virtual TbDegree Degree { get; set; }
    }
}

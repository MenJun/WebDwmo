using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private ShopContext _db;
        public DefaultController(ShopContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetStu()
        {
            return new JsonResult(new { stu = _db.TbStu.ToList() });
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JsonResult GetStuByID(string Id)
        {
            return new JsonResult(new { stu = _db.TbStu.Where(t=>t.StuId ==Id).FirstOrDefault() });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public JsonResult DelStuByID(string Id)
        {
            var stu = _db.TbStu.Where(t => t.StuId == Id).FirstOrDefault();
            _db.TbStu.Remove(stu);
            return new JsonResult(new { code = _db.SaveChanges()>0 });
        }


        [HttpPost]
        public JsonResult Add(TbClass tbClass)
        {
            _db.TbClass.Add(tbClass);
            return new JsonResult(new { code = _db.SaveChanges() > 0 });
        }
        //public async Task<JsonResult> GetStuS()
        //{
        //    return  await _db.TbStu.ToListAsync();
        //}
    }
}

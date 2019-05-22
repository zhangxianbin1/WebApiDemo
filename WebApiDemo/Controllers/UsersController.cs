using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private Users[] users = new Users[] { new Users { id = 1, name = "Haleemah Redfern", email = "email1@mail.com", phone = "01111111", role = 1 }, new Users { id = 2, name = "Aya Bostock", email = "email2@mail.com", phone = "01111111", role = 1 }, new Users { id = 3, name = "Sohail Perez", email = "email3@mail.com", phone = "01111111", role = 1 }, new Users { id = 4, name = "Merryn Peck", email = "email4@mail.com", phone = "01111111", role = 2 }, new Users { id = 5, name = "Cairon Reynolds", email = "email5@mail.com", phone = "01111111", role = 3 } };
        /// <summary>
        /// 获取所有数据
        /// </summary>
        [HttpPost]
        public async Task<IEnumerable<Users>> GetAllUser()
        {
            return await Task.Run(() =>
            {
                return users;
            });
        }
        /// <summary>
        /// 根据id获取特别的数据
        /// </summary>
        [HttpGet]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            return await Task.Run(() =>
            {
                var user = users.FirstOrDefault((p) => p.id == id);
                return Ok(user);
            });
        }
        /// <summary>
        /// 通过实体方法获取mysql数据库中的数据
        /// </summary>
        [HttpGet]
        public async Task<IHttpActionResult>  GetDataInMysql()
        {
            return await Task.Run(() =>
            {
                test1Entities test = new Models.test1Entities();
                var user = test.user.ToList();
                return Ok(user);
            });
        }
        /// <summary>
        /// 根据id获取数据库中特别的数据
        /// </summary>
        [HttpGet]
        public async Task<IHttpActionResult> GetSpecialUser(int id)
        {
            return await Task.Run(() =>
            {
                test1Entities test = new Models.test1Entities();
                var user = test.user.Where((p) => p.ID == id).FirstOrDefault();
                return Ok(user);
            });
        }
    }
}

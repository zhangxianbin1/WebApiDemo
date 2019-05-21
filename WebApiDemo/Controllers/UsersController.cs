using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<Users> Get()
        {
            return users;
        }
        /// <summary>
        /// GET: api/Users/5
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            test1Entities test = new Models.test1Entities();
            var user = test.user.ToList();// users.FirstOrDefault((p) => p.id == id); if (user == null) { return NotFound(); }
            return Ok(user);
        }
        /// <summary>
        /// POST: api/Users
        /// </summary>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// PUT: api/Users/5
        /// </summary>
        public void Put(int id, [FromBody]string value)
        {
        }
        /// <summary>
        /// DELETE: api/Users/5
        /// </summary>
        public void Delete(int id)
        {
        }
    }
}

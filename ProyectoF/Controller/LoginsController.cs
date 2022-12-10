using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoF.Models;

namespace ProyectoF.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ProyectFinal1Context _context;

        public LoginsController(ProyectFinal1Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IEnumerable<Login> Get()
        {

            using (var context = new ProyectFinal1Context())
            {
                return context.Logins.ToList();
            }

        }
        [HttpPost]
        [Route("LoginPost")]
        public List<Login> Userloginvalues()
        {
            List<Login> objModel = new List<Login>();
            objModel.Add(new Login { Username = "admin", Password = "admin" });
            objModel.Add(new Login { Username = "user2", Password = "password2" });
            objModel.Add(new Login { Username = "user3", Password = "password3" });
            objModel.Add(new Login { Username = "user4", Password = "password4" });
            objModel.Add(new Login { Username = "user5", Password = "password5" });
            return objModel;

        }
    }
}
    


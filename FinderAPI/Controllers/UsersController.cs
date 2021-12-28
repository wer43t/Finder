using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderCore;
using System.Collections.ObjectModel;

namespace FinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        FinderCoreApp core = new FinderCoreApp();
        [HttpGet]
        public ObservableCollection<User> Get()
        {
            return core.GetUsers();
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return core.GetUsers(id);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            core.CreateNewAccount(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = core.GetUsers(id);
            if (result == null)
                return NotFound();

            core.DeleteUser(id);
            return NoContent();
        }

    }
}

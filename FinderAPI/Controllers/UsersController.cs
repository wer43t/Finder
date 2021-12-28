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
        public ObservableCollection<Country> Get()
        {
            return core.GetCountries();
        }
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return core.GetCountries( id);
        }

    }
}

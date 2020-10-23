using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApiModels;

namespace UserApiWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetDetails(string iin)
        {
            User user = _userRepository.Get(iin);
            return Json(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(user);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400); //ValidationProblem(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(User user)
        { 
            if (ModelState.IsValid)
            {
                _userRepository.Update(user);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string iin)
        {
            _userRepository.Delete(iin);
            return StatusCode(200);
        }
    }
}
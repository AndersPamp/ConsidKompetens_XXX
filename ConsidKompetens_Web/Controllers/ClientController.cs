using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Communications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger _logger;
        //private readonly IDataProvider _data;
        private readonly IGetUserDataService _userDataService;

        public ClientController(ILogger logger, IGetUserDataService userDataService)
        {
            _logger = logger;
            _userDataService = userDataService;
        }

        // GET: api/Client
        
        [HttpGet]
        public IEnumerable<string> SpaPage()
        {
            return new string[] { "Logged in" };
        }

        // GET: api/Client/5
        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(new JsonResponse {Data =  _userDataService.GetUserByIdAsync(id).Result});
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse{Error = true, Message = e.Message});
            }

            ;
        }

        // POST: api/Client
        [Authorize]
        [HttpPost]
        public ActionResult<JsonResponse> Post([FromBody] EmployeeUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userDataService.CreateNewUserAsync(userModel);
                    return Created("", new JsonResponse{Data = userModel});
                }
                catch (Exception e)
                {
                    return BadRequest(new JsonResponse {Error = true, Message = e.Message});
                }
            }
            else if (userModel == null)
            {
                try
                {
                    _userDataService.CreateNewUserAsync(new EmployeeUserModel());
                    return new JsonResponse{Message = "An empty profile has been created"};
                }
                catch (Exception e)
                {
                    return BadRequest(new JsonResponse { Error = true, Message = e.Message });
                }
            }

            return BadRequest(new JsonResponse{Error = true, Message = "Something went wrong"});
        }

        // PUT: api/Client/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

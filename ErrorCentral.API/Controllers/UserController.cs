using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _app;

        public UserController(IUserService app)
        {
            _app = app;
        }

        [Authorize]
        [HttpGet("{email}")]
        public ActionResult<UserIdDTO> Get(string email)
        {
            if (_app.FindByEmail(email) != null)
            {
                return Ok(_app.FindByEmail(email));
            }
            else
            {
                return NoContent();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> Post([FromBody] UserDTO user)
        {
            return await _app.Add(user);
        }

        [HttpPost("Login")]
        public async Task<string> Login(LoginDTO login)
        {
            return await _app.Login(login);
        }

        // PUT api/<UserController>/5
        [Authorize]
        [HttpPut] //O Id do objeto é suficiente para o EF
        public ActionResult<IEnumerable<UserIdDTO>> Put([FromBody] UserIdDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updateProccess = _app.Update(user).Result;

                if (updateProccess == true)
                {
                    return Ok("User update successfully");
                }
                else
                {
                    throw new Exception("falha ao atualizar o usuário");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<IngredienteController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var deleteProccess = _app.Delete(id);
            if (deleteProccess.Result == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"Log with id {id} not found");
            }
        }
    }
}
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

        [HttpPost("Login")]
        public async Task<string> Login(LoginDTO login)
        {
            return await _app.Login(login);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            if (_app.SelectAll().Count > 0)
            {
                return Ok(_app.SelectAll());
            }
            else
            {
                return NoContent();
            }
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

        // PUT api/<UserController>/5
        [Authorize]
        [HttpPut] //O Id do objeto é suficiente para o EF
        public ActionResult<IEnumerable<UserIdDTO>> Put([FromBody] UserIdDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updateProccess = _app.Update(user);

                if (updateProccess.Succeeded == true)
                {
                    return Ok("User updated successfully");
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
            try
            {
                var deleteProccess = _app.Delete(id);
                if (deleteProccess.Result == true)
                {
                    return NoContent();
                }
                else
                {
                    throw new Exception($"Log with id {id} not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _app;
        private readonly IErrorService _err;

        public UserController(IUserService app, IErrorService err)
        {
            _app = app;
            _err = err;
        }

        [HttpPost("Login")]
        public async Task<string> Login(LoginDTO login)
        {
            try
            {
                return await _app.Login(login);
            }
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return ex.Message;
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            try
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
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{email}")]
        public ActionResult<UserIdDTO> Get(string email)
        {
            try
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
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] UserDTO user)
        {
            try
            {
                return await _app.Add(user);
            }
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public ActionResult<IEnumerable<UserIdDTO>> Put([FromBody] UserIdDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Model State is invalid");

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
                _err.Add(ex, HttpContext.User.Identity.Name);
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
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }
    }
}
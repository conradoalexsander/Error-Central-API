using System;
using System.Collections.Generic;
using System.Security.Claims;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentral.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        //underline utilizado porque a classe e privada (padrão da comunidade)
        private readonly ILogService _app;

        private readonly IErrorService _err;

        private readonly UserManager<IdentityUser> _userManager;

        public LogController(ILogService app, IErrorService err, UserManager<IdentityUser> userManager)
        {
            _app = app;
            _err = err;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogDTO>> Get()
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
                Error exceptionError = new Error()
                {
                    CreatedAt = new DateTime(),
                    StackTrace = ex.StackTrace,
                    UserName = HttpContext.User.Identity.Name,
                    Message = ex.Message
                };

                _err.Add(exceptionError);
                return BadRequest(ex.Message);
            }
        }

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public ActionResult<LogDTO> Get(int id)
        {
            try
            {
                if (_app.SelectById(id) != null)
                {
                    return Ok(_app.SelectById(id));
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                Error exceptionError = new Error()
                {
                    CreatedAt = new DateTime(),
                    StackTrace = ex.StackTrace,
                    UserName = HttpContext.User.Identity.Name,
                    Message = ex.Message
                };

                _err.Add(exceptionError);
                return BadRequest(ex.Message);
            }
        }

        // POST api/<IngredienteController>
        [HttpPost]
        public ActionResult<IEnumerable<LogDTO>> Post([FromBody] LogAddDTO log)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Fail on model validation");

                _app.Add(log);
                return _app.SelectAll();
            }
            catch (Exception ex)
            {
                Error exceptionError = new Error()
                {
                    CreatedAt = new DateTime(),
                    StackTrace = ex.StackTrace,
                    UserName = HttpContext.User.Identity.Name,
                    Message = ex.Message
                };

                _err.Add(exceptionError);
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<IngredienteController>/5
        [HttpPut] //O Id do objeto é suficiente para o EF
        public ActionResult<IEnumerable<LogDTO>> Put([FromBody] LogUpdateDTO log)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Fail on model validation");

                _app.Update(log);
                return Ok(_app.SelectAll());
            }
            catch (Exception ex)
            {
                Error exceptionError = new Error()
                {
                    CreatedAt = new DateTime(),
                    StackTrace = ex.StackTrace,
                    UserName = HttpContext.User.Identity.Name,
                    Message = ex.Message
                };

                _err.Add(exceptionError);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<IngredienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_app.SelectById(id) != null)
                {
                    _app.Delete(id);
                    return NoContent();
                }
                else
                {
                    return BadRequest($"Log with id {id} not found");
                }
            }
            catch (Exception ex)
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;

                Error exceptionError = new Error()
                {
                    CreatedAt = new DateTime(),
                    StackTrace = ex.StackTrace,
                    UserName = user.UserName,
                    Message = ex.Message
                };

                _err.Add(exceptionError);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<IngredienteController>/5
        [HttpDelete]
        public ActionResult<IEnumerable<LogDTO>> DeleteMany([FromBody] List<int> ids)
        {
            try
            {
                _app.DeleteMany(ids);
                return Ok(_app.SelectAll());
            }
            catch (Exception ex)
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;

                Error exceptionError = new Error()
                {
                    CreatedAt = new DateTime(),
                    StackTrace = ex.StackTrace,
                    UserName = user.UserName,
                    Message = ex.Message
                };

                _err.Add(exceptionError);
                return BadRequest(ex.Message);
            }
        }
    }
}
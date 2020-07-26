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

        public LogController(ILogService app, IErrorService err)
        {
            _app = app;
            _err = err;
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
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

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
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

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
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/[action]")]
        public ActionResult<IEnumerable<LogDTO>> DeleteMany([FromBody] List<int> ids)
        {
            try
            {
                _app.DeleteMany(ids);
                return Ok(_app.SelectAll());
            }
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
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
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

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
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }
    }
}
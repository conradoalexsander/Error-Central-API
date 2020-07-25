using System;
using System.Collections.Generic;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentral.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        //underline utilizado porque a classe e privada (padrão da comunidade)
        private readonly IOrganizationService _app;

        private readonly IErrorService _err;

        public OrganizationController(IOrganizationService app, IErrorService err)
        {
            _app = app;
            _err = err;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrganizationDTO>> Get()
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
        public ActionResult<OrganizationDTO> Get(int id)
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
        public ActionResult<IEnumerable<OrganizationDTO>> Post([FromBody] OrganizationAddDTO organization)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Fail on model validation");

                _app.Add(organization);
                return _app.SelectAll();
            }
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrganizationController>/5
        [HttpPut] //O Id do objeto é suficiente para o EF
        public ActionResult<IEnumerable<OrganizationDTO>> Put([FromBody] OrganizationDTO organization)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Fail on model validation");

                _app.Update(organization);
                return Ok(_app.SelectAll());
            }
            catch (Exception ex)
            {
                _err.Add(ex, HttpContext.User.Identity.Name);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OrganizationController>/5
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
                    return BadRequest($"Organization with id {id} not found");
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
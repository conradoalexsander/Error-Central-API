using System.Collections.Generic;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        //underline utilizado porque a classe e privada (padrão da comunidade)
        private readonly IOrganizationService _app;

        public OrganizationController(IOrganizationService app)
        {
            _app = app;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrganizationDTO>> Get()
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

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public ActionResult<OrganizationDTO> Get(int id)
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

        // POST api/<OrganizationController>
        [HttpPost]
        public ActionResult<IEnumerable<OrganizationDTO>> Post([FromBody] OrganizationAddDTO organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _app.Add(organization);
            return _app.SelectAll();
        }

        // PUT api/<OrganizationController>/5
        [HttpPut] //O Id do objeto é suficiente para o EF
        public ActionResult<IEnumerable<OrganizationDTO>> Put([FromBody] OrganizationDTO organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _app.Update(organization);
            return Ok(_app.SelectAll());
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
    }
}
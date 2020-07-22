using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        //underline utilizado porque a classe e privada (padrão da comunidade)
        private readonly IOrganizationRepository _repo;

        public OrganizationController(IOrganizationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return _repo.SelectAll();
        }

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public Organization Get(int id)
        {
            return _repo.SelectById(id);
        }

        // POST api/<OrganizationController>
        [HttpPost]
        public IEnumerable<Organization> Post([FromBody] Organization organization)
        {
            _repo.Add(organization);
            return _repo.SelectAll();
        }

        // PUT api/<OrganizationController>/5
        [HttpPut] //O Id do objeto é suficiente para o EF
        public IEnumerable<Organization> Put([FromBody] Organization organization)
        {
            _repo.Update(organization);
            return _repo.SelectAll();
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Organization> Delete(int id)
        {
            _repo.Delete(id);
            return _repo.SelectAll();
        }
    }
}
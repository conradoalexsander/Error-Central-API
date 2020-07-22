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
    public class LogController : ControllerBase
    {
        //underline utilizado porque a classe e privada (padrão da comunidade)
        private readonly ILogRepository _repo;

        public LogController(ILogRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Log> Get()
        {
            return _repo.SelectAll();
        }

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public Log Get(int id)
        {
            return _repo.SelectById(id);
        }

        // POST api/<IngredienteController>
        [HttpPost]
        public IEnumerable<Log> Post([FromBody] Log log)
        {
            _repo.Add(log);
            return _repo.SelectAll();
        }

        // PUT api/<IngredienteController>/5
        [HttpPut] //O Id do objeto é suficiente para o EF
        public IEnumerable<Log> Put([FromBody] Log log)
        {
            _repo.Update(log);
            return _repo.SelectAll();
        }

        // DELETE api/<IngredienteController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Log> Delete(int id)
        {
            _repo.Delete(id);
            return _repo.SelectAll();
        }
    }
}
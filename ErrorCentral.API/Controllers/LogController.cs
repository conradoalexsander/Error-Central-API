using System.Collections.Generic;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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

        public LogController(ILogService app)
        {
            _app = app;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogDTO>> Get()
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

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public ActionResult<LogDTO> Get(int id)
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

        // POST api/<IngredienteController>
        [HttpPost]
        public ActionResult<IEnumerable<LogDTO>> Post([FromBody] LogAddDTO log)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _app.Add(log);
            return _app.SelectAll();
        }

        // PUT api/<IngredienteController>/5
        [HttpPut] //O Id do objeto é suficiente para o EF
        public ActionResult<IEnumerable<LogDTO>> Put([FromBody] LogUpdateDTO log)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _app.Update(log);
            return Ok(_app.SelectAll());
        }

        // DELETE api/<IngredienteController>/5
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
                return BadRequest($"Log with id {id} not found");
            }
        }

        // DELETE api/<IngredienteController>/5
        [HttpDelete]
        public IEnumerable<LogDTO> DeleteMany([FromBody] List<int> ids)
        {
            _app.DeleteMany(ids);
            return _app.SelectAll();
        }
    }
}
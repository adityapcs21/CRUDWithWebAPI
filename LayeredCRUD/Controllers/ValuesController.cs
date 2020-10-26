using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentDTO;
using StudentRepository;

namespace LayeredCRUD.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepository _repository;

        public ValuesController(IValuesRepository repository)
        {
            _repository = repository ;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _repository.GetAll();
        }

        //GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Student>> Get(int id)
        //{
        //    var response = await _repository.GetById(id);
        //    if (response == null)
        //    { return NotFound(); }
        //    return response;
        //}

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Student value)
        {
            await _repository.Insert(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteById(id);
        }
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Student smodel)
        {
            await _repository.Update(id, smodel);


        }

    }
}

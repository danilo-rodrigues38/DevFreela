using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            // Buscar todos ou filtrar

            return Ok ( );
        }

        // api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Buscar o projeto

            // return NotFound(); // se não achar

            return Ok ( );
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if(createProject.Title.Length > 50)
            {
                return BadRequest ( );
            }

            // Cadastrar o projeto

            return CreatedAtRoute ( nameof ( GetById ), new { id = createProject.Id }, createProject );
        }

        // api/project/2
        [HttpPut ( "{id}" )]
        public IActionResult Put ( int id, [FromBody] UpdateProjectModel updateProject )
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest ( );
            }

            // Atualizo o objeto

            return NoContent ( );
        }

        // api/project/3
        [HttpDelete("{id}")]
        public IActionResult Delete( int id )
        {
            // Buscar, se não existir, retorna NotFound

            // Remover

            return NoContent ( );
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment( int id, [FromBody] CreateCommentModel createCommentModel )
        {
            return NoContent ( );
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start( int id )
        {
            return NoContent ( );
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish( int id )
        {
            return NoContent ( );
        }
    }
}

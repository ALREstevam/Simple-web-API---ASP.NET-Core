using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiDotNetCore.Models;

/*
 # Dicas
 
    * Use `CTRL+F5` para testar o código no navegador
    * No navegador use o `inspecionar elemento` para fazer o debug (normalmente `F12` ou `CTRL+SHIFT+C`)
    
 */


namespace WebApiDotNetCore.Controllers
{
    //Note que esta classe herda de controller
    [Route("api/[controller]")]
    public class EmployeeController : Controller 
    {

        private readonly NorthwindDbContext _db;


        /*Controller com injeção de dependência garente o desacoplamento do controller com o dbcontext 
         * (mas _db deveria ser do tipo interface de NorthwindDbContext (INorthwindDbContext))
         * https://www.devmedia.com.br/padrao-de-injecao-de-dependencia/18506
        
        */
        public EmployeeController(NorthwindDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public List<Employee> Get()
        {
            return _db.Employees.ToList();
        }

        // GET api/employee/id
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _db.Employees.Find(id);
        }

        // POST api/employee/...
        [HttpPost]
        public IActionResult Post([FromBody]Employee obj)
        {
            _db.Employees.Add(obj);
            _db.SaveChanges();
            return new ObjectResult("Colaborador adicionado com sucesso!");

        }

        // PUT api/employee/...
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Employee obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
            return new ObjectResult("Colaborador alterado com sucesso!");
        }


        // DELETE api/employee/...
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _db.Employees.Remove(_db.Employees.Find(id));
            _db.SaveChanges();
            return new ObjectResult("Colaborador excluido com sucesso!");
        }



    }
}


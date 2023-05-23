using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using model.UserDto;
using NEWAPI.Dto.Todo;

namespace NEWAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserTodoController : ControllerBase
{
   private readonly AppDbContext _ccontext;
   public UserTodoController(AppDbContext ccontext)
   {
      _ccontext = ccontext;
   }

   [HttpGet("[action]")]
   public ActionResult<TodoDto> Gettodo()
   {
      var todo = _ccontext.Todos.ToList();
      return Ok(todo);
   }

   [HttpGet("[action]/{id:int}")]
   public ActionResult<TodoDto> Gettodo(int id)
   {
      if (id == 0)
      {
         return Ok(BadRequest());
      }
      var todo = _ccontext.Todos.Find(id);

      if (todo == null)
      {
         return NotFound();
      }
      return Ok(todo);
   }
   
}
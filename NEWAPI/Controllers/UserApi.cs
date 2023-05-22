using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using model.UserDto;

namespace NEWAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserApiController : ControllerBase
{
    // DbContext ---> AppDbContext
    private readonly AppDbContext _context; // GET

    public UserApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("[action]")]
    public ActionResult GetUsers()
    {
        var user = _context.Users.ToList();
        return Ok(user);
    }
//     [HttpGet("id:int",Name = "GetUser")] --- >     [HttpGet("[action]/{id:int}")]

    [HttpGet("[action]/{id:int}")]
    public ActionResult<UserDto> GetUser(int id)
    {
        if (id == 0)
        {
            return Ok(BadRequest());
        }

        // _context.FindAsync<User>(); --- >_context.Users.Find(id);
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

// User --- > user
        return Ok(user);
    }

    //
    [HttpPost("[action]")]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] User userDto)
    {
        // TIP::NO need to check for id ;


        // if (userDto.Id > 0)
        // {
        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        //Tip :: first we need to bind dto to entity 
        var model = new User()
        {
            cardid = userDto.cardid,
            lastname = userDto.lastname,
            Name = userDto.Name,
            ImageUrl = userDto.ImageUrl
        };


        _context.Users.Add(model);
        await _context.SaveChangesAsync();
        // TIP:: return must be ok and just an object
        // return CreatedAtRoute("GetUser", new { id = userDto.Id }, userDto);

        return Ok(model);
    }

    //
    [HttpDelete("[action]/{id:int}")]
    public ActionResult DeleteUser(int id)
    {
        //Tip No need
        // if (id == 0)
        // {
        // return BadRequest();
        // }
        //Tip :: should search for user
        // var user = _context.ContextId;

        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

//TIP :: should call user context and pass the model
        // _context.Remove(id);
        _context.Users.Remove(user);
        _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("[action]/{id:int}")]
    public IActionResult UpdateUser(int id, [FromBody] User userDto)
    {
        if (userDto == null || userDto.Id != id)
        {
            return BadRequest();
        }
        var todo = _context.Users.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.Name = userDto.Name;
        todo.lastname = userDto.lastname;
        todo.cardid = userDto.cardid;
        todo.ImageUrl = userDto.ImageUrl;
        _context.Users.Update(todo);
        _context.SaveChanges();
        return NoContent();
    }
}
﻿using Data;
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

    [HttpGet]
    public ActionResult GetUsers()
    {
        return Ok(User);
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
    // [HttpPost]
    // public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
    // {
    //     var entity = new User()
    //     {
    //         cardid = userDto.cardid,
    //         Name = userDto.Name,
    //         lastname = userDto.lastname,
    //         ImageUrl = userDto.ImageUrl
    //     };
    //     //if (UserProoop.UserList.FirstOrDefault(u => u.Name.ToLower() == userDto.Name.ToLower()) != null)
    //     //{ ModelState.AddModelError("CustomError", "user already exists!");
    //     // return BadRequest(ModelState); }
    //
    //     //if (userDto.Id > 0)
    //     //{ return StatusCode(StatusCodes.Status500InternalServerError); }
    //
    //     userDto.Id = _context.Add(userDto);
    //     _context.SaveChangesAsync();
    //     return CreatedAtRoute("GetUser", new { id = userDto.Id }, userDto);
    // }
    //
    // [HttpDelete("id:int", Name = "GetUser")]
    // public ActionResult DeleteUser(int id)
    // {
    //     if (id == 0)
    //     {
    //         return BadRequest();
    //     }
    //
    //     var user = _context.ContextId;
    //     if (user == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     _context.Remove(id);
    //     _context.SaveChangesAsync();
    //     return NoContent();
    // }
    //
    // [HttpPut("id:int", Name = "UpdateUser")]
    // public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
    // {
    //     if (userDto == null)
    //     {
    //         return BadRequest();
    //     }
    //
    //     var entity = new User()
    //     {
    //         cardid = userDto.cardid,
    //         Name = userDto.Name,
    //         lastname = userDto.lastname,
    //         ImageUrl = userDto.ImageUrl
    //     };
    //     var user = _context.Update(id);
    //     _context.SaveChangesAsync();
    //     return NoContent();
    // }
}
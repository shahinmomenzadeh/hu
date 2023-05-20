using Microsoft.AspNetCore.Mvc;
using model;
using model.UserDto;
namespace NEWAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserApiController : ControllerBase
{ // GET
    [HttpGet]
    public ActionResult GetUsers()
    {
        return Ok(UserProoop.UserList);
    }
    [HttpGet("id:int")]
    public ActionResult<UserDto> GetUser(int id)
    {
        if (id == 0)
        {
            return Ok(BadRequest());
        }
        var User = UserProoop.UserList.FirstOrDefault(u => u.Id == id);
        if (User == null)
        {
            return NotFound();
        }
        return Ok(User);
    }
    [HttpPost]
    public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
    {
       // if (UserProoop.UserList.FirstOrDefault(u =>u.Name.ToLower() == userDto.Name.ToLower())!=null)
         // {ModelState.AddModelError("CustomError","user already exists!"); 
           // return BadRequest(ModelState);}
        if (userDto.Id > 0)
        { return StatusCode(StatusCodes.Status500InternalServerError); }

        userDto.Id = UserProoop.UserList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
        UserProoop.UserList.Add(userDto);
        return Ok(userDto);

    }
}
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quanbin.TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            var users = await _userService.ListUsers();
            return Ok(users);
        }

        [Route("{userid:int}/taskhistories")]
        [HttpGet]
        public async Task<IActionResult> GetTaskHistories(int userid)
        {
            var taskHisotries = await _userService.GetTasksHishtoryById(userid);
            var tasks = await _userService.GetTasksById(userid);
            return Ok(taskHisotries);
        }

        [Route("{userid:int}/tasks")]
        [HttpGet]
        public async Task<IActionResult> GetTasks(int userid)
        {
            
            var tasks = await _userService.GetTasksById(userid);
            return Ok(tasks);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestModel model)
        {
            var user = await _userService.AddUser(model);
            return Ok(user);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestModel model)
        {
            var user = await _userService.UpdateUser(model);
            return Ok(user);
        }

        [Route("Delete/{userid:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userid)
        {
            var user = await _userService.DeleteUser(userid);
            return Ok(user);
        }
    }
}

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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;

        }


        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var tasks = await _taskService.ListTasks();
            return Ok(tasks);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskRequestModel model)
        {
            var task = await _taskService.CreateTask(model);
            return Ok(task);
        }

        [Route("Complete/{taskid:int}")]
        [HttpGet]
        public async Task<IActionResult> FinishTask(int taskid)
        {
            var task = await _taskService.FinishTask(taskid);
            return Ok(task);
        }

        [Route("Delete/{taskid:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int taskid)
        {
            var task = await _taskService.DeleteTask(taskid);
            return Ok(task);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestModel model)
        {
            var task = await _taskService.UpdateTask(model);
            return Ok(task);
        }


    }
}

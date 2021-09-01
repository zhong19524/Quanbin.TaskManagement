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
    public class TasksHistoryController : ControllerBase
    {

        private readonly ITasksHistoryService _tasksHistoryService;
        public TasksHistoryController(ITasksHistoryService tasksHistoryService)
        {
            _tasksHistoryService = tasksHistoryService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllTaskHistories()
        {
            var tasks = await _tasksHistoryService.ListTasksHistories();
            return Ok(tasks);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateTaskHistory([FromBody] TasksHistoryRequestModel model)
        {
            var taskhistory = await _tasksHistoryService.CreateTaskHistory(model);
            return Ok(taskhistory);
        }


        [Route("Delete/{taskid:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTaskHisotry(int taskid)
        {
            var taskhistory = await _tasksHistoryService.DeleteTaskHistory(taskid);
            return Ok(taskhistory);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateTaskHistory([FromBody] TasksHistoryUpdateRequestModel model)
        {
            var task = await _tasksHistoryService.UpdateTaskHistory(model);
            return Ok(task);
        }
    }

}

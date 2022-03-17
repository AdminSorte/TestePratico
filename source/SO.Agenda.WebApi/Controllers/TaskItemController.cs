using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SO.Agenda.Application.AppServices.Interfaces;
using SO.Agenda.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SO.Agenda.WebApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemAppService _taskItemAppService;
        public TaskItemController(ITaskItemAppService taskItemAppService)
        {
            _taskItemAppService = taskItemAppService;
        }
        // GET: api/<TaskItemController>
        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {           
            try
            {
                var result = await _taskItemAppService.GetAllAsNoTrackingAsync();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TaskItemController>/5
        [HttpGet("{id}")]
        public virtual  async Task<IActionResult> GetById(Int32 id)
        {
            try
            {
                var result = await _taskItemAppService.FindAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // GET api/<TaskItemController>/5
        [HttpGet("{title}")]
        public virtual async Task<IActionResult> GetByTitle(string title)
        {
            try
            {
                var result = await _taskItemAppService.GetTaskItemByTitle(title);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // POST api/<TaskItemController>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]JObject json)
        {
            try
            {
                var taskItemViewModel = JsonConvert.DeserializeObject<TaskItemViewModel>(json.Root.ToString());
                var result = await _taskItemAppService.AddAsync(taskItemViewModel);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TaskItemController>/5
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromBody]JObject json)
        {
            try
            {
                var taskItemViewModel = JsonConvert.DeserializeObject<TaskItemViewModel>(json.Root.ToString());
                var result =  _taskItemAppService.Update(taskItemViewModel);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TaskItemController>/5
        public virtual async Task<IActionResult> Delete(Int32 id)
        {
            try
            {
                await _taskItemAppService.RemoveAsync(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.Models;

namespace TaskTracker.API.Features.Tasks
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Returns all the tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTasks", Name = "GetTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TaskItem>>> GetTasksAsync()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        /// <summary>
        /// Adds a new task
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("AddTask", Name = "AddTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskItem>> AddTaskAsync([FromBody] AddTask.AddTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            return Ok(taskItem);
        }

        /// <summary>
        /// Updates a task
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateTask", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskItem>> UpdateTaskAsync([FromBody] UpdateTask.UpdateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            return Ok(taskItem);
        }

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteTask/{taskId}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteTaskAsync(Guid taskId)
        {
            var result = await _mediator.Send(new DeleteTask(taskId));
            return Ok(result);
        }
    }
}

using MediatR;
using TaskTracker.API.Models;
using TaskTracker.API.Services;

namespace TaskTracker.API.Features.Tasks
{
    public class AddTask
    {
        public class AddTaskCommand : TaskItem, IRequest<TaskItem>
        { 
        
        }

        public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, TaskItem>
        {
            private readonly ITaskService _taskService;
            public AddTaskCommandHandler(ITaskService taskService) => _taskService = taskService;

            public async Task<TaskItem> Handle(AddTaskCommand request, CancellationToken cancellationToken)
            {
                return _taskService.AddTask(request);
            }
        }
    }
}

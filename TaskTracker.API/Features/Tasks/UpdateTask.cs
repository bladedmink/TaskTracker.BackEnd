using MediatR;
using TaskTracker.API.Models;
using TaskTracker.API.Services;

namespace TaskTracker.API.Features.Tasks
{
    public class UpdateTask
    {
        public class UpdateTaskCommand : TaskItem, IRequest<TaskItem>
        {

        }

        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskItem>
        {
            private readonly ITaskService _taskService;
            public UpdateTaskCommandHandler(ITaskService taskService) => _taskService = taskService;

            public async Task<TaskItem> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
            {
                return _taskService.UpdateTask(request);
            }
        }
    }
}

using MediatR;
using TaskTracker.API.Services;

namespace TaskTracker.API.Features.Tasks
{
    public class DeleteTask : IRequest<bool>
    {

        public DeleteTask(Guid taskId)
        {
            TaskId = taskId;
        }

        public Guid TaskId { get; private set; }

        public class DeleteTaskHandler : IRequestHandler<DeleteTask, bool>
        {
            private readonly ITaskService _taskService;
            public DeleteTaskHandler(ITaskService taskService) => _taskService = taskService;

            public async Task<bool> Handle(DeleteTask request, CancellationToken cancellationToken)
            {
                return _taskService.DeleteTask(request.TaskId);
            }
        }
    }
}

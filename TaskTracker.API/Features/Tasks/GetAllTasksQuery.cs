using MediatR;
using TaskTracker.API.Models;
using TaskTracker.API.Services;

namespace TaskTracker.API.Features.Tasks
{
    public class GetAllTasksQuery : IRequest<ICollection<TaskItem>>
    {
    }

    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, ICollection<TaskItem>>
    {
        private readonly ITaskService _taskService;
        public GetAllTasksQueryHandler(ITaskService taskService) => _taskService = taskService;

        public async Task<ICollection<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return _taskService.GetTaskItems();
        }
    }
}

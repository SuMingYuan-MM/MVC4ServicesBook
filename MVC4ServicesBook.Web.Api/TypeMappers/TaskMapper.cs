using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4ServicesBook.Web.Api.Models;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public class TaskMapper:ITaskMapper
    {
        private readonly ICategoryMapper _categoryMapper;
        private readonly IStatusMapper _statusMapper;
        private readonly IPriorityMapper _prioritmMapper;
        private readonly IUserMapper _userMapper;

        public TaskMapper(
            IUserMapper userMapper,
            IPriorityMapper priorityMapper,
            IStatusMapper statusMapper,
            ICategoryMapper categoryMapper)
        {
            _userMapper = userMapper;
            _prioritmMapper = priorityMapper;
            _statusMapper = statusMapper;
            _categoryMapper = categoryMapper;
        }

        public Task CreateTask(Data.Model.Task modelTask)
        {
            var task = new Task
                {
                    TaskId = modelTask.TaskId,
                    Subject = modelTask.Subject,
                    StartDate = modelTask.StartDate,
                    DueDate = modelTask.DueDate,
                    DateCompleted = modelTask.DateCompleted,
                    CreatedDate = modelTask.CreatedDate,
                    Status = _statusMapper.CreatedStatus(modelTask.Status),
                    Priority = _prioritmMapper.CreatePriority(modelTask.Priority),
                    Categories = modelTask
                        .Categories
                        .Select(_categoryMapper.CreateCategory)
                        .ToList(),
                    Assignees = modelTask
                        .Users
                        .Select(_userMapper.CreateUser)
                        .ToList(),
                    Links = new List<Link>
                    {
                        new Link
                        {
                            Title = "self",
                            Rel = "self",
                            Href = "/api/tasks/" + modelTask.TaskId
                        },
                        new Link
                        {
                            Title = "self",
                            Rel = "self",
                            Href = "/api/tasks/" + modelTask.TaskId + "/categories"
                        },
                        new Link
                        {
                            Title = "self",
                            Rel = "self",
                            Href = "/api/tasks/" + modelTask.TaskId + "/users"
                        }
                    }
                };

            return task;
        }
    }
}
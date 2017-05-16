using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Todo.Domain.Identity;
using Todo.WebUI.Models;
using Todo.Domain.Repository.Abstract;
using System.Web.Routing;
using System.Threading;
using System.Globalization;
using Todo.Domain.Entities;

namespace Todo.WebUI.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IRepositoryFactory _factory;
        private int _itemPerPage = 6;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session["CurrentCulture"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
            }
        }

        public TaskController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public ApplicationUserManager UserManager
            => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return View(user.Tasks != null && user.Tasks.Count > 0);
        }

        public async Task<ActionResult> Create()
        {
            List<UserFriend> friends = _factory.UserFriendsRepository.GetUsersFriends(User.Identity.GetUserId()).ToList();

            EditTaskViewModel task = new EditTaskViewModel
            {
                UserId = User.Identity.GetUserId(),
                TaskParticipants = friends.Select(x => new AddTaskParticipantViewModel()
                {
                    FullName = _factory.UserRepository.FindById(x.FriendId.ToString()).UserName,
                    UserId = x.FriendId.ToString(),
                    IsChecked = false
                }).ToList()
            };

            return View("Edit", task);
        }

        public ActionResult Edit(string taskId)
        {
            List<UserFriend> friends = _factory.UserFriendsRepository.GetUsersFriends(User.Identity.GetUserId()).ToList();

            UserTask task = _factory.UserTaskRepository.FindById(taskId);
            EditTaskViewModel editTaskViewModel = new EditTaskViewModel();
            editTaskViewModel.Latitude = task.Latitude;
            editTaskViewModel.Longitude = task.Longitude;
            editTaskViewModel.Place = task.Place;
            editTaskViewModel.TaskDescription = task.TaskDescription;
            editTaskViewModel.TaskName = task.TaskName;
            editTaskViewModel.TaskParticipants = friends.Select(x => new AddTaskParticipantViewModel()
            {
                FullName = _factory.UserRepository.FindById(x.FriendId.ToString()).UserName,
                UserId = x.FriendId.ToString(),
                IsChecked = false
            }).ToList();
            foreach (AddTaskParticipantViewModel addTaskParticipantViewModel in editTaskViewModel.TaskParticipants)
            {
                foreach (TaskParticipant participant in task.TaskParticipants)
                {
                    if (participant.ParticipantId.ToString() == addTaskParticipantViewModel.UserId)
                        addTaskParticipantViewModel.IsChecked = true;
                }
            }
            editTaskViewModel.TaskState = task.TaskState;
            editTaskViewModel.Time = task.Time;
            editTaskViewModel.TaskId = task.TaskId;
            editTaskViewModel.UserId = task.UserId;

            return View(editTaskViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditTaskViewModel editedTask)
        {
            UserTask task = new UserTask();
            task.TaskParticipants = _factory.UserFriendsRepository.GetUsersFriends(User.Identity.GetUserId()).Select(x => new TaskParticipant
            {
                UserTask = task,
                ParticipantId = x.FriendId.ToString()
            }).ToList();
            task.Latitude = editedTask.Latitude;
            task.Longitude = editedTask.Longitude;
            task.Place = editedTask.Place;
            task.TaskDescription = editedTask.TaskDescription;
            task.TaskName = editedTask.TaskName;
            task.TaskState = editedTask.TaskState;
            task.Time = editedTask.Time;
            task.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                _factory.UserTaskRepository.Add(task);
                foreach (TaskParticipant participant in task.TaskParticipants)
                {
                    _factory.TaskParticipantrepository.Add(participant);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(task);
        }

        public async Task<PartialViewResult> List(int page = 1)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<UserTask> tasks = user.Tasks;
            TaskListViewModel model = new TaskListViewModel
            {
                Tasks = tasks.Skip(_itemPerPage * (page - 1)).Take(_itemPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = _itemPerPage,
                    TotalItems = tasks.Count()
                }
            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<PartialViewResult> List(FilterViewModel filterModel, int page = 1)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<UserTask> tasks = user.Tasks;
            if (!string.IsNullOrEmpty(filterModel.Place))
            {
                tasks = tasks.Where(m => (m.Place == filterModel.Place));
            }

            if (filterModel.TaskState != null)
            {
                tasks = tasks.Where(m => m.TaskState == filterModel.TaskState);
            }

            if (filterModel.MinTime != default(DateTime) && filterModel.MaxTime != default(DateTime))
            {
                tasks = tasks.Where(m => (m.Time >= filterModel.MinTime && m.Time <= filterModel.MaxTime));
            }
            else if (filterModel.MinTime != default(DateTime))
            {
                tasks = tasks.Where(m => (m.Time >= filterModel.MinTime));
            }
            else if (filterModel.MaxTime != default(DateTime))
            {
                tasks = tasks.Where(m => (m.Time <= filterModel.MaxTime));
            }

            tasks = tasks.Skip(_itemPerPage * (page - 1)).Take(_itemPerPage);
            TaskListViewModel model = new TaskListViewModel
            {
                Tasks = tasks.Skip(_itemPerPage * (page - 1)).Take(_itemPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = _itemPerPage,
                    TotalItems = tasks.Count()
                }
            };
            return PartialView(model);
        }

        public async Task<PartialViewResult> Filter()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<UserTask> tasks = user.Tasks;
            FilterViewModel model = new FilterViewModel
            {
                MinTime = tasks.Min(m => m.Time) ?? DateTime.MinValue,
                MaxTime = tasks.Max(m => m.Time) ?? DateTime.MaxValue,
                Place = null
            };
            return PartialView(model);
        }

        public PartialViewResult Delete(string taskId)
        {
            UserTask task = _factory.UserTaskRepository.Delete(taskId);
            //if (task != null) {
            //    TempData["message"] = $"Задача {task.TaskName} была удалена.";
            //}
            return PartialView((object) task.TaskName);
        }

        public async Task<ActionResult> Show(string taskId)
        {
            UserTask task = _factory.UserTaskRepository.FindById(taskId);
            return View(task);
        }
    }
}
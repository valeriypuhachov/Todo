using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Todo.WebUI.Infrastructure;

namespace Todo.WebUI.Models {
    public class TaskListViewModel {
        public IEnumerable<UserTask> Tasks { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class FilterViewModel {
        public string Place { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime MinTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime MaxTime { get; set; }
        public State? TaskState { get; set; }
    }

    public class EditTaskViewModel {

        public Guid TaskId { get; set; }
        [Required(ErrorMessageResourceName = "DescriptionIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }

        [Required(ErrorMessageResourceName = "TaskNameIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "TaskName", ResourceType = typeof(Resources.Resource))]
        public string TaskName { get; set; }

        [FutureDate(ErrorMessageResourceName = "DateOutOfRange",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "TaskTime", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.DateTime)]
        public DateTime? Time { get; set; }

        [Display(Name = "TaskState", ResourceType = typeof(Resources.Resource))]
        public State TaskState { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public string Place { get; set; }
    }
}
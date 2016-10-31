using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.Models {
    public class UserTask {
        [Key]
        public Guid TaskId { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        public string TaskDescription { get; set; }

        [Display(Name = "TaskName", ResourceType = typeof(Resources.Resource))]
        public string TaskName { get; set; }

        [Display(Name = "TaskTime", ResourceType = typeof(Resources.Resource))]
        public DateTime? Time { get; set; }

        [Display(Name = "TaskState", ResourceType = typeof(Resources.Resource))]
        public State TaskState { get; set; }

        public string UserId { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public string Place { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

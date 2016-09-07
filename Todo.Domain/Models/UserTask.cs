using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Models {
    public class UserTask {
        [Key]
        public Guid TaskId { get; set; }
        public string TaskDescription { get; set; }
        public string TaskName { get; set; }
        public DbGeography Location { get; set; }
        public DateTime Time { get; set; }
        public State TaskState { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

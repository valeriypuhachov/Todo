using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Models {
    public enum State {
        [Display(Name = "Waiting", ResourceType = typeof(Resources.Resource))]
        WAITING,
        [Display(Name = "Completed", ResourceType = typeof(Resources.Resource))]
        COMPLETED,
        [Display(Name = "NotCompleted", ResourceType = typeof(Resources.Resource))]
        NOT_COMPLETED,
        [Display(Name = "Canceled", ResourceType = typeof(Resources.Resource))]
        CANCELED
    }
}

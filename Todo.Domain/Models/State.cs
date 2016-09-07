using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Models {
    public enum State {
        WAITING,
        COMPLETED,
        NOT_COMPLETED,
        CANCELED
    }
}

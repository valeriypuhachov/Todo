using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Models;

namespace Todo.Domain.Entities
{
    public class TaskParticipant
    {
        [Key]
        public Guid TaskParticipantId { get; set; }

        [ForeignKey(nameof(UserTask))]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(User))]
        public string ParticipantId { get; set; }

        public ApplicationUser User { get; set; }

        public UserTask UserTask { get; set; }
    }
}

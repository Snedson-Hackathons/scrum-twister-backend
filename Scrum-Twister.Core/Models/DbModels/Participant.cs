using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Models.DbModels
{
    public partial class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? AvatarId { get; set; }
        public int? ActivityId { get; set; }
        public Guid? SessionId { get; set; }
        public bool? ActivityAnswered { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Avatar Avatar { get; set; }
        public virtual Session Session { get; set; }
    }
}

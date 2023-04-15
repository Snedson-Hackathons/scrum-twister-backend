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
        public string ActivityAnswer { get; set; }
        public Guid? SessionId { get; set; }

        public virtual Avatar Avatar { get; set; }
        public virtual Session Session { get; set; }
    }
}

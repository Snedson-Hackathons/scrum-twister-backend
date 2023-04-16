using System;
using System.Collections.Generic;

namespace Scrum_Twister.Core.Models.DbModels
{
    public partial class Session
    {
        public Session()
        {
            Participants = new HashSet<Participant>();
        }

        public Guid Id { get; set; }
        public int? StatusId { get; set; }
        public string InviteCode { get; set; }

        public virtual SessionStatus Status { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

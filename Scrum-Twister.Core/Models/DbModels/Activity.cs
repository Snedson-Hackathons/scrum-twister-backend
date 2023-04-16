using System.Collections.Generic;

namespace Scrum_Twister.Core.Models.DbModels
{
    public partial class Activity
    {
        public Activity()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int? ActivityType { get; set; }
        public string ActivityBlob { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}

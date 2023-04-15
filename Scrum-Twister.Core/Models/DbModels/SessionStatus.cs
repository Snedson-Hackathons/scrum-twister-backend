using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Models.DbModels
{
    public partial class SessionStatus
    {
        public SessionStatus()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string StatusTitle { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}

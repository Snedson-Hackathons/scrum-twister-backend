﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Models.DbModels
{
    public partial class Avatar
    {
        public Avatar()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}

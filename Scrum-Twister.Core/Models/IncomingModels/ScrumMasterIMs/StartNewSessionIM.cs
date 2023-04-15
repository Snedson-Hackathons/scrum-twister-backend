using Scrum_Twister.Core.Models.Dtos;
using System.Collections.Generic;

namespace Scrum_Twister.Core.Models.IncomingModels.ScrumMasterIMs
{
    public record StartNewSessionIM
    {
        public List<ParticipantDto> Participants { get; set; }
        public bool IsOnline { get; set; }
    }

}

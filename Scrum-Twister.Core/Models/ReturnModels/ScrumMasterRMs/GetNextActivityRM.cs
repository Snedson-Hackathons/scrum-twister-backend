using Scrum_Twister.Core.Enums;
using Scrum_Twister.Core.Models.Dtos;
using Scrum_Twister.Core.Models.ReturnModels.CommonRMs;
using System.Collections.Generic;

namespace Scrum_Twister.Core.Models.ReturnModels.ScrumMasterRMs
{
    public record GetNextActivityRM
    {
        public bool IsFinished { get; set; }
        public ActivityTypeEnum ActivityType { get; set; }
        public ParticipantDto Participant { get; set; }
        public string Title { get; set; }
        public string Subtitle{ get; set; }
        public string ActivityBlob { get; set; }
        public List<AvatarDto> Avatars { get; set; }
    }
}

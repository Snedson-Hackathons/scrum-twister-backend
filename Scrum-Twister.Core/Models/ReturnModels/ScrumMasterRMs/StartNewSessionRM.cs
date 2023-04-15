using System;

namespace Scrum_Twister.Core.Models.ReturnModels.ScrumMasterRMs
{
    public class StartNewSessionRM
    {
        public Guid SessionId { get; set; }
        public string InviteCode { get; set; }
    }
}

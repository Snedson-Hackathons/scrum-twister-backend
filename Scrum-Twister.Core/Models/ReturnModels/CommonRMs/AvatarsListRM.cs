using System.Collections.Generic;

namespace Scrum_Twister.Core.Models.ReturnModels.CommonRMs
{
    public record AvatarsListRM
    {
        public List<AvatarDto> Avatars { get; set; }
    }

    public record AvatarDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

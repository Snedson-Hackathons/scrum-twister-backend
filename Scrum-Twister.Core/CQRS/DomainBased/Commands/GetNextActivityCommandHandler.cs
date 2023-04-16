using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrum_Twister.Core.Enums;
using Scrum_Twister.Core.Interfaces;
using Scrum_Twister.Core.Models.ReturnModels.ScrumMasterRMs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.CQRS.DomainBased.Commands
{
    public class GetNextActivityCommand : IRequest<GetNextActivityRM>
    {
        public Guid SessionId { get; set; }
    }

    public class GetNextActivityCommandHandler
        : AbstractCQRSHandler, IRequestHandler<GetNextActivityCommand, GetNextActivityRM>
    {
        public GetNextActivityCommandHandler(IScrumTwisterContext context) : base(context)
        { }

        public async Task<GetNextActivityRM> Handle(GetNextActivityCommand request, CancellationToken cancellationToken)
        {
            var nextParticipant = await db.Participants.FirstOrDefaultAsync(
                p =>
                    (p.SessionId == request.SessionId) && (!p.ActivityAnswered.Value));

            if (nextParticipant == null)
                return null;

            var toReturn = new GetNextActivityRM();

            toReturn.Participant = new Models.Dtos.ParticipantDto
            {
                AvatarId = nextParticipant.AvatarId.Value,
                Name = nextParticipant.Name
            };

            toReturn.Title = nextParticipant.Activity.Title;
            toReturn.Subtitle = nextParticipant.Activity.Subtitle;
            toReturn.ActivityType = (ActivityTypeEnum)Enum.Parse(typeof(ActivityTypeEnum), nextParticipant.Activity.ActivityType.Value.ToString());
            toReturn.ActivityBlob = nextParticipant.Activity.ActivityBlob;

            nextParticipant.ActivityAnswered = true;
            await db.SaveChangesAsync();

            return toReturn;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrum_Twister.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.CQRS.DomainBased.Commands
{
    public class AddActivityForSessionsParticipantsCommand : IRequest<Unit>
    {
        public Guid SessionId { get; set; }
    }

    public class AddActivityForSessionsParticipantsCommandHandler
        : AbstractCQRSHandler, IRequestHandler<AddActivityForSessionsParticipantsCommand, Unit>
    {
        public AddActivityForSessionsParticipantsCommandHandler(IScrumTwisterContext context) 
            : base(context)
        { }

        public async Task<Unit> Handle(AddActivityForSessionsParticipantsCommand request, CancellationToken cancellationToken)
        {
            var random = new Random();
            var activityIds = await db.Activities.AsNoTracking().Select(a => a.Id).ToListAsync();
            var participants = db.Participants.Where(p => p.SessionId == request.SessionId).Select(p => p);

            if (IsItPossibleToUseUniqueActivities(request.SessionId))
            {
                foreach (var participant in participants)
                {
                    var randomIndex = random.Next(activityIds.Count);
                    var randomActivityId = activityIds[randomIndex];
                    participant.ActivityId = randomActivityId;
                    activityIds.RemoveAt(randomIndex);
                }
            }
            else
            {
                foreach (var participant in participants)
                {
                    var randomIndex = random.Next(activityIds.Count);
                    var randomActivityId = activityIds[randomIndex];
                    participant.ActivityId = randomActivityId;
                }

            }
            await db.SaveChangesAsync();

            return new Unit();
        }

        public bool IsItPossibleToUseUniqueActivities(Guid sessionId)
        {
            var activitiesCount = db.Activities.Count();
            var participantsCount = db.Participants.Count(p => p.SessionId == sessionId);

            return activitiesCount >= participantsCount;
        }
    }
}

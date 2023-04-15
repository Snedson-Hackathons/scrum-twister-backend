using MediatR;
using Scrum_Twister.Core.Interfaces;
using Scrum_Twister.Core.Models.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.CQRS.DomainBased.Commands
{
    public class AddParticipantCommand: IRequest<bool>
    {
        public ParticipantDto Participant { get; set; }
        public Guid SessionGuid { get; set; }
    }

    public class AddParticipantCommandHandler
        : AbstractCQRSHandler, IRequestHandler<AddParticipantCommand, bool>
    {
        public AddParticipantCommandHandler(IScrumTwisterContext context) : base(context)
        { }

        public async Task<bool> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
        {
            db.Participants.Add(new Models.DbModels.Participant
            {
                Id = Guid.NewGuid(),
                AvatarId = request.Participant.AvatarId,
                Name = request.Participant.Name,
                SessionId = request.SessionGuid,
                //ActivityId = 
            });

            await db.SaveChangesAsync();

            return true;
        }
    }
}

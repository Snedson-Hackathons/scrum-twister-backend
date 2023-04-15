using MediatR;
using Scrum_Twister.Core.Enums;
using Scrum_Twister.Core.Interfaces;
using Scrum_Twister.Core.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.CQRS.DomainBased.Commands
{
    public class CreateSessionCommand: IRequest<(Guid sessionGuid, string inviteCode)>
    {
        public SessionKindEnum SessionKind { get; set; }
    }

    public class CreateSessionCommandHandler
        : AbstractCQRSHandler, IRequestHandler<CreateSessionCommand, (Guid sessionGuid, string inviteCode)>
    {
        private readonly HeximalNumbersGeneratorService _heximalNumbersGenerator;

        public CreateSessionCommandHandler(IScrumTwisterContext context, HeximalNumbersGeneratorService heximalNumbersGenerator) 
            : base(context)
        {
            _heximalNumbersGenerator = heximalNumbersGenerator;
        }

        public async Task<(Guid sessionGuid, string inviteCode)> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            var sessionGuid = Guid.NewGuid();
            var inviteCode = request.SessionKind == SessionKindEnum.Offline ? _heximalNumbersGenerator.GenerateNextNumber(10) : null;

            db.Sessions.Add(new Models.DbModels.Session
            {
                Id = sessionGuid,
                StatusId = (int) SessionStatusEnum.WaitingForParticipants,
                InviteCode = inviteCode
            });
            await db.SaveChangesAsync();

            return (sessionGuid, inviteCode);
        }
    }
}

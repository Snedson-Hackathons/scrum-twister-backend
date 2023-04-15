using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrum_Twister.Core.Enums;
using Scrum_Twister.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.CQRS.DomainBased.Commands
{
    public class SetSessionStatusCommand : IRequest<Unit>
    {
        public Guid SessionId { get; set; }
        public SessionStatusEnum StatusToSet { get; set; }
    }

    public class SetSessionStatusCommandHandler
        : AbstractCQRSHandler, IRequestHandler<SetSessionStatusCommand, Unit>
    {
        public SetSessionStatusCommandHandler(IScrumTwisterContext context) : base(context)
        { }

        public async Task<Unit> Handle(SetSessionStatusCommand request, CancellationToken cancellationToken)
        {
            var session = await db.Sessions.SingleOrDefaultAsync(s => s.Id == request.SessionId);
            session.StatusId = (int)request.StatusToSet;
            await db.SaveChangesAsync();

            return new Unit();
        }
    }
}

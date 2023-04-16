using MediatR;
using Scrum_Twister.Core.CQRS.DomainBased.Commands;
using Scrum_Twister.Core.Models.IncomingModels.ScrumMasterIMs;
using Scrum_Twister.Core.Models.ReturnModels.ScrumMasterRMs;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Services.ReturnModelFillers.ScrumMasterRMFs
{
    public class StartNewSessionRMF : AbstractRMF
    {
        public StartNewSessionRMF(IMediator mediator) : base(mediator)
        { }

        public async Task<StartNewSessionRM> FillModel(StartNewSessionIM startNewSessionIM)
        {
            var createdSessionData = await _mediator.Send(new CreateSessionCommand());

            if(!startNewSessionIM.IsOnline)
            {
                foreach(var participant in startNewSessionIM.Participants)
                {
                    await _mediator.Send(new AddParticipantCommand
                    {
                        Participant = participant,
                        SessionGuid = createdSessionData.sessionGuid,
                    });
                }

                await _mediator.Send(new AddActivityForSessionsParticipantsCommand
                {
                    SessionId = createdSessionData.sessionGuid
                });

                await _mediator.Send(new SetSessionStatusCommand 
                {
                    SessionId = createdSessionData.sessionGuid,
                    StatusToSet = Enums.SessionStatusEnum.NotStarted,
                });
            }

            return new StartNewSessionRM { SessionId = createdSessionData.sessionGuid, InviteCode = createdSessionData.inviteCode };
        }
    }
}

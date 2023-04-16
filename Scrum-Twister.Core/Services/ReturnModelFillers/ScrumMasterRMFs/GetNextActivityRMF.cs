using MediatR;
using Scrum_Twister.Core.CQRS.DomainBased.Commands;
using Scrum_Twister.Core.CQRS.DomainBased.Queries;
using Scrum_Twister.Core.Models.ReturnModels.ScrumMasterRMs;
using System;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Services.ReturnModelFillers.ScrumMasterRMFs
{
    public class GetNextActivityRMF : AbstractRMF
    {
        public GetNextActivityRMF(IMediator mediator) : base(mediator)
        { }

        public async Task<GetNextActivityRM> FillModel(Guid sessionId)
        {
            var toReturn = await _mediator.Send(new GetNextActivityCommand
            {
                SessionId = sessionId
            });

            if (toReturn == null)
                return new GetNextActivityRM { IsFinished = true };
                
            toReturn.Avatars = await _mediator.Send(new GetAvatarsListQuery());

            return toReturn;
        }
    }
}

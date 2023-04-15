using MediatR;
using Scrum_Twister.Core.CQRS.DomainBased.Queries;
using Scrum_Twister.Core.Models.ReturnModels.CommonRMs;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.Services.ReturnModelFillers.CommonRMFs
{
    public class AvatarsListRMF : AbstractRMF
    {
        public AvatarsListRMF(IMediator mediator) : base(mediator)
        { }

        public async Task<AvatarsListRM> FillModel()
        {
            return new AvatarsListRM
            {
                Avatars = await _mediator.Send(new GetAvatarsListQuery())
            };
        }
    }
}

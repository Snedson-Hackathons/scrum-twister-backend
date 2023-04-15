using MediatR;

namespace Scrum_Twister.Core.Services.ReturnModelFillers
{
    public abstract class AbstractRMF
    {
        protected readonly IMediator _mediator;
        public AbstractRMF(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

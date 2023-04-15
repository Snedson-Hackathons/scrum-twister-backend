using MediatR;
using Scrum_Twister.Core.Interfaces;

namespace Scrum_Twister.Core.CQRS
{
    public abstract class AbstractCQRSHandler
    {
        protected readonly IScrumTwisterContext db;
        public AbstractCQRSHandler(IScrumTwisterContext context)
        {
            db = context;
        }
    }

    public abstract class AbstractCQRSHandlerWithMediator : AbstractCQRSHandler
    {
        protected readonly IMediator _mediator;
        public AbstractCQRSHandlerWithMediator
            (IScrumTwisterContext context, IMediator mediator) : base(context)
        {
            _mediator = mediator;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrum_Twister.Core.Interfaces;
using Scrum_Twister.Core.Models.ReturnModels.CommonRMs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Scrum_Twister.Core.CQRS.DomainBased.Queries
{
    public class GetAvatarsListQuery: IRequest<List<AvatarDto>>
    { }

    public class GetAvatarsListQueryHandler
        : AbstractCQRSHandler, IRequestHandler<GetAvatarsListQuery, List<AvatarDto>>
    {
        public GetAvatarsListQueryHandler(IScrumTwisterContext context) 
            : base(context)
        { }

        public Task<List<AvatarDto>> Handle(GetAvatarsListQuery request, CancellationToken cancellationToken)
        {
            return db.Avatars.AsNoTracking().Select(a => new AvatarDto
            {
                Id = a.Id,
                Title = a.Title,
                ImageUrl = a.ImageUrl,
                Description = a.Description,
            }).ToListAsync();
        }
    }
}

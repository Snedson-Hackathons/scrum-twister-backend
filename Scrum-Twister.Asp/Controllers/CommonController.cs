using Microsoft.AspNetCore.Mvc;
using Scrum_Twister.Core.Services.ReturnModelFillers.CommonRMFs;
using System.Threading.Tasks;

namespace Scrum_Twister.Asp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CommonController : Controller
    {
        public readonly AvatarsListRMF _avatarsListFiller;

        public CommonController
            (AvatarsListRMF avatarsListFiller)
        {
            _avatarsListFiller = avatarsListFiller;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AvatarsList()
        {
            return Ok(await _avatarsListFiller.FillModel());
        }
    }
}

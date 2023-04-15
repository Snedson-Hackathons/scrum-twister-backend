using Microsoft.AspNetCore.Mvc;
using Scrum_Twister.Core.Models.IncomingModels.ScrumMasterIMs;
using Scrum_Twister.Core.Services.ReturnModelFillers.ScrumMasterRMFs;
using System.Threading.Tasks;

namespace Scrum_Twister.Asp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ScrumMasterController : Controller
    {
        public readonly StartNewSessionRMF _startNewSessionFiller;

        public ScrumMasterController(StartNewSessionRMF startNewSessionFiller)
        {
            _startNewSessionFiller = startNewSessionFiller;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> StartNewSesion(StartNewSessionIM startNewSessionIM)
        {
            return Ok(await _startNewSessionFiller.FillModel(startNewSessionIM));
        }
    }
}

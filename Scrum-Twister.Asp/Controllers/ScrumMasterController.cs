using Microsoft.AspNetCore.Mvc;
using Scrum_Twister.Core.Models.IncomingModels.ScrumMasterIMs;
using Scrum_Twister.Core.Services.ReturnModelFillers.ScrumMasterRMFs;
using System;
using System.Threading.Tasks;

namespace Scrum_Twister.Asp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ScrumMasterController : Controller
    {
        public readonly StartNewSessionRMF _startNewSessionFiller;
        public readonly GetNextActivityRMF _getNextActivityRMF;

        public ScrumMasterController(StartNewSessionRMF startNewSessionFiller, GetNextActivityRMF getNextActivityRMF)
        {
            _startNewSessionFiller = startNewSessionFiller;
            _getNextActivityRMF = getNextActivityRMF;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> StartNewSesion(StartNewSessionIM startNewSessionIM)
        {
            return Ok(await _startNewSessionFiller.FillModel(startNewSessionIM));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNextActivity(Guid sessionId)
        {
            return Ok(await _getNextActivityRMF.FillModel(sessionId));
        }
    }
}

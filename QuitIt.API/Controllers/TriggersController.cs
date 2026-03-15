using Microsoft.AspNetCore.Mvc;
using QuitIt.API.Services;
using QuitIt.API.Models;

namespace QuitIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggersController : ControllerBase
    {
        private readonly IFileService<Trigger> _fileService;
        private readonly List<Trigger> Triggers;

        public TriggersController(IFileService<Trigger> fileService)
        {
            _fileService = fileService;
            Triggers = _fileService.LoadData();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTriggers()
        {
            return Ok(Triggers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTriggerById(Guid id)
        {
            Trigger? trigger = Triggers.FirstOrDefault(trigger => trigger.Id == id);

            if (trigger == null || Triggers.Count == 0)
            {
                return BadRequest();
            }

            return Ok(trigger);
        }

        [HttpPost]
        public async Task<ActionResult<Trigger>> CreateNewTrigger(Trigger trigger)
        {
            Trigger newTrigger = new(Guid.NewGuid());

            if (trigger.Reason == null || trigger.Reason == "")
            {
                return BadRequest();
            }

            newTrigger.Reason = trigger.Reason;
            Triggers.Add(newTrigger);
            await _fileService.SaveData(Triggers);

            return Ok(newTrigger);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Trigger>> UpdateTriggerById(Guid id, Trigger t)
        {
            Trigger? trigger = Triggers.FirstOrDefault(trigger => trigger.Id == id);

            if (trigger == null || Triggers.Count == 0)
            {
                return BadRequest();
            }

            trigger.Reason = t.Reason;
            await _fileService.SaveData(Triggers);

            return Ok(trigger);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Trigger>> DeleteTrigger(Guid id)
        {
            Trigger? trigger = Triggers.FirstOrDefault(trigger => trigger.Id == id);

            if (trigger == null || Triggers.Count == 0)
            {
                return BadRequest();
            }
            Triggers.Remove(trigger);
            await _fileService.SaveData(Triggers);

            return Ok(trigger);
        }
    }
}

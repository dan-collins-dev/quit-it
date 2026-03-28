using Microsoft.AspNetCore.Mvc;
using QuitIt.API.Models;
using QuitIt.API.Services;

namespace QuitIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IFileService<Log> _fileService;
        private readonly List<Log> Logs;

        public LogsController(IFileService<Log> fileService)
        {
            _fileService = fileService;
            Logs = _fileService.LoadData();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLogs()
        {
            return Ok(Logs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLogById(Guid id)
        {
            Log? log = Logs.FirstOrDefault(log => log.Id == id);

            if (log == null || Logs.Count == 0)
            {
                return BadRequest();
            }

            return Ok(log);
        }

        [HttpPost]
        public async Task<ActionResult<Log>> CreateNewLog()
        {
            var lastLog = Logs.Last();

            var isNewDay = await IsNewDay(Logs);

            if (isNewDay)
            {
                Log newLog = new(Guid.NewGuid(), DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                Logs.Add(newLog);
                await _fileService.SaveData(Logs);
                return Ok(newLog);
            }
            else
            {
                lastLog.NumOfCigs += 1;
                await _fileService.SaveData(Logs);
                return Ok(lastLog);
            }
        }

        public async Task<bool> IsNewDay(List<Log> logs)
        {

            Log lastLog = logs.Last();

            DateTimeOffset utcNowOffset = DateTime.UtcNow;
            DateTimeOffset lastLogTime = DateTimeOffset.FromUnixTimeMilliseconds(lastLog.Date);

            return (lastLogTime.UtcDateTime.Date < utcNowOffset.UtcDateTime.Date) ? true : false;
        }
    }
}

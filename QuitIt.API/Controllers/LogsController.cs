using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuitIt.API.Models;
using QuitIt.API.Services;

namespace QuitIt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetAllLogs()
        {
            var logs = await FileService.LoadLogs();
            return Ok(logs);
        }

        [HttpPost]
        public async Task<ActionResult<Log>> CreateNewLog()
        {
            // load all logs
            var logs = await FileService.LoadLogs();
            var lastLog = logs.Last();

            var isNewDay = await IsNewDay();

            if (isNewDay)
            {
                Log newLog = new(Guid.NewGuid(), DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                logs.Add(newLog);
                await FileService.SaveLogs(logs);
                return Ok(newLog);
            }
            else
            {
                lastLog.NumOfCigs += 1;
                await FileService.SaveLogs(logs);
                return Ok(lastLog);
            }
        }

        public static async Task<bool> IsNewDay()
        {

            List<Log> logs = await FileService.LoadLogs();

            Log lastLog = logs.Last();

            DateTimeOffset utcNowOffset = DateTime.UtcNow;
            DateTimeOffset lastLogTime = DateTimeOffset.FromUnixTimeMilliseconds(lastLog.Date);

            return (lastLogTime.AddDays(1) < utcNowOffset) ? true : false;
        }
    }
}

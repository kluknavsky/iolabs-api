using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly ApiService _apiService;

    public MessagesController(ApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpPost("saveMessage")]
    public IActionResult SaveMessage([FromBody] ApiCall apiCall)
    {
        _apiService.SaveMessage(apiCall);
        return Ok(new { message = $"You send: {apiCall.Request}" });
    }

    [HttpGet("getMessages")]
    public IActionResult GetMessages()
    {
        var messages = _apiService.GetMessages();
        return Ok(messages);
    }

    [HttpGet("getMessagesWithPagination")]
    public IActionResult GetMessages([FromQuery] int page, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
    {
        var allMessages = _apiService.GetMessages();

        if (!string.IsNullOrEmpty(search))
        {
            allMessages = allMessages.Where(m => m.Request.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var skip = (page - 1) * pageSize;
        var paginatedMessages = allMessages.Skip(skip).Take(pageSize).ToList();

        var response = new
        {
            TotalCount = allMessages.Count,
            PageSize = pageSize,
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(allMessages.Count / (double)pageSize),
            Messages = paginatedMessages
        };

        return Ok(response);
    }
}

using ioLabsApi.Data;

public class ApiService
{
    private readonly ApiDbContext _context;

    public ApiService(ApiDbContext context)
    {
        _context = context;
    }

    public void SaveMessage(ApiCall apiCall)
    {
        _context.ApiCalls.Add(apiCall);
        _context.SaveChanges();
    }

    public List<ApiCall> GetMessages()
    {
        return _context.ApiCalls.ToList();
    }
}

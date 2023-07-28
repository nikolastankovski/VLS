namespace VLS.Infrastructure.Services
{
    public class LoggingService
    {
        private readonly VLSDbContext _context;

        public LoggingService(VLSDbContext context)
        {
            _context = context;
        }

        public void Log(ApplicationLog log)
        {
            _context.ApplicationLogs.Add(log);
            _context.SaveChanges();
        }

        public async Task LogAsync(ApplicationLog log)
        {
            await _context.ApplicationLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}

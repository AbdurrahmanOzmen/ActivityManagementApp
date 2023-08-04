using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities.Entities
{
    public class AppContext : DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;
        public IConfiguration Configuration { get; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class AppContext:DbContext
    {
       // private IHttpContextAccessor _httpContextAccessor;
        public IConfiguration Configuration { get; }
    }
}

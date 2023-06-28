using System.Security.Claims;
using VegApp.Areas.Identity.Data;
using VegApp.Data;
using static VegApp.UserProvider;

namespace VegApp
{
    public class UserProvider
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly VegAppContext _vegAppContext;

        public UserProvider(IHttpContextAccessor httpContextAccessor, VegAppContext vegAppContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _vegAppContext = vegAppContext;
        }

        public Guid GetCurrentUserId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public VegAppUser GetCurrenttUser() 
        {
            return _vegAppContext.Users.FirstOrDefault(o => o.Id == GetCurrentUserId());
        }

    }
}

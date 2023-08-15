using System.Security.Claims;
using VegApp.Areas.Identity.Data;
using VegApp.Data;


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

        public VegAppUser GetCurrentUser() 
        {
            return _vegAppContext.Users.FirstOrDefault(o => o.Id == GetCurrentUserId());
        }

    }
}

using controller.Areas.Admin.Code;

namespace controller.Areas.Admin.Controllers
{
    internal class UserController : UserSessions
    {
        public string emailAdmin { get; set; }
        public string password { get; set; }
    }
}
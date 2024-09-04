using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Controllers
{
    public class PaginationBaseController : Controller
    {
        public int page;
        private HttpContext _httpContext => new HttpContextAccessor().HttpContext;

        public PaginationBaseController()
        {
            page = _httpContext.Request.Query["page"].Count > 0 ? int.Parse(_httpContext.Request.Query["page"]) : 1;
        }

    }
}

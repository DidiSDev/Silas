using Microsoft.AspNetCore.Mvc;

namespace Silas.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }

    }
}

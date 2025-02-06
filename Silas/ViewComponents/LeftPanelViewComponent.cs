using Microsoft.AspNetCore.Mvc;
using Silas.Models;
using Silas.Models.Companies;
using Silas.Models.Offers;

namespace Silas.ViewComponents
{
    public class LeftPanelViewComponent : ViewComponent
    {
        private readonly OfferService _offerService;

        public LeftPanelViewComponent(OfferService offerService)
        {
            _offerService = offerService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string userRole, int userId)
        {
        
            List<Offer> offers = await _offerService.GetOffersByCompanyIdAsync(11);
            var model = new LeftPanelViewModel
            {
                userRole = userRole,
                datalist = offers
            };

            return View("LeftPanel", model);
        
        }
    }
}

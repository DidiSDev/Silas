using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Silas.Models;
using Silas.Models.Companies;
using Silas.Models.Offers;
using System.Reflection;

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
        
            List<Offer> offers = await _offerService.GetOffersByCompanyIdAsync(userId);
            if (userRole == "company")
            {
                var model = new LeftPanelViewModel
                {
                    userRole = userRole,
                    datalist = offers
                   
                };
                return View("LeftPanel", model);

            }
            else if (userRole == "student")
            {
                //OTRA COSA
            }
            else
            {
                //EL ADMIN, OTRA COSA
            }

            return View("LeftPanel", OTRACOSA);
        }
    }
}

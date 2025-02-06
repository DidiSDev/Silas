using Microsoft.AspNetCore.Mvc;
using Silas.Models.Companies;
using Silas.Models.Offers;

namespace Silas.Controllers
{
    public class CompanyController : Controller
    {


        //SERVICIO DE LAS COMPAÑIAS
        private readonly CompanyService _companyService;

        //CONSTRUCTOR PARA EL CONTROLADOR
        public CompanyController (CompanyService companyService)
        {
            _companyService = companyService;
        }





        public IActionResult Index()
        {
            return View();
        }


        //LO QUE DECÍAS DIEGO, ESTO LO LLAMAMOS DESDE AccountController
        public async Task<List<Offer>> LoadOffersForCompany(int userId)
        {
            //userId = id en la tabla users, que coincide con id_company en 'offers'
            //y ya cargamos el listado q está en el servicio
            var offers = await _companyService.ListOffersByCompanyIdAsync(userId);
            return offers;
        }

        //LA LISTA DE OFERTAS
        public async Task<IActionResult> _LeftPanelPartial(int userId)
        {
            var offers = await _companyService.ListOffersByCompanyIdAsync(userId);
            //Retornamos la vista parcial _LeftPanelPartial.cshtml pasándole la lista
            return PartialView(offers);
        }
    }
}

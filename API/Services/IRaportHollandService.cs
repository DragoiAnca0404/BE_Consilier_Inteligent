using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.Application.Services
{
    public interface IRaportHollandService
    {
        Task<IActionResult> GetRaportHolland(string denumire_solutie);

    }
}

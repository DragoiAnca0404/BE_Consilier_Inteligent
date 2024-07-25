using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.Application.Services
{
    public interface ITestHollandAntrenareService
    {
        Task<IActionResult> Predict(float[] raspunsuri);
        //Task<IActionResult> ViewEleviTeste(int id_utilizator);
    }
}

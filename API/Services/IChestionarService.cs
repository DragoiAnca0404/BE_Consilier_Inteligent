using BE_ConsilierInteligent.BLL.Utils;
using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.Application.Services
{
    public interface IChestionarService
    {
        Task<IActionResult> GetAllTests();
        Task<IActionResult> GetIntrebari(int id_chestionar);
        Task<IActionResult> GetAllPasiuni();
        Task<IActionResult> CreateChestionar(AddChestionarBLL chestionarDTO);

    }

}

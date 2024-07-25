using BE_ConsilierInteligent.Application.Services.Impl;
using BE_ConsilierInteligent.BLL.Utils;
using BE_ConsilierInteligent.Controller.Utils;
using BE_ConsilierInteligent.DataAccess.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChestionarController : ControllerBase
    {
        private ChestionarBLL _BLL;
        private readonly ConsilierContext _context;


        public ChestionarController()
        {
            _BLL = new BE_ConsilierInteligent.Application.Services.Impl.ChestionarBLL();

        }


        [HttpGet("ViewTests")]
        public async Task<IActionResult> GetAllTests()
        {
            var result = await _BLL.GetAllTests();
            return result;
        }


        [HttpGet("ReturnIntrebari")]
        public async Task<IActionResult> GetIntrebari(int id_chestionar)
        {
            var result = await _BLL.GetIntrebari(id_chestionar);
            return result;

        }


        [HttpGet("ViewPasiuni")]
        public async Task<IActionResult> GetAllPasiuni()
        {
            var result = await _BLL.GetAllPasiuni();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChestionar(AddChestionar addChestionar)
        {

            // Convertirea lui addChestionar la tipul AddChestionarBLL
            var addChestionarBLL = ConvertToBLLType(addChestionar);

            var createdChestionarTask = _BLL.CreateChestionar(addChestionarBLL);

            var createdChestionar = Task.FromResult(createdChestionarTask.Result);

            return CreatedAtAction(nameof(CreateChestionar), new { id = createdChestionar.Id }, createdChestionar);


        }

        private AddChestionarBLL ConvertToBLLType(AddChestionar addChestionar)
        {
            return new AddChestionarBLL
            {
                DenumireTest = addChestionar.DenumireTest,
                username = addChestionar.username,
                Intrebari = addChestionar.Intrebari
            };
        }

    }
}

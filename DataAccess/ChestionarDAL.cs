using BE_ConsilierInteligent.DataAccess.Entities;
using BE_ConsilierInteligent.DataAccess.Persistence;
using ConsilierBackUP.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Newtonsoft.Json;


namespace BE_ConsilierInteligent.DataAccess
{
    public class ChestionarDAL : ControllerBase
    {
        public async Task<ActionResult<Chestionar>> GetChestionar()
        {
            var db = new ConsilierContext();
            return Ok(await db.Chestionar.ToListAsync());
        }

        public async Task<IActionResult> GetAllTests()
        {
            var _context = new ConsilierContext();

            var tests = _context.Chestionar
                  .Select(z => new { denumire_test = z.denumire_test });

            return Ok(tests); 

        }

        public async Task<IActionResult> GetIntrebari(int id_chestionar)
        {
            var _context = new ConsilierContext();

            var intrebari = _context.Intrebare.Where(w => w.id_chestionar.Equals(id_chestionar))
                          .Select(e => new { Formulare_intrebare = e.Formulare_intrebare }).ToList();

            return Ok(intrebari);

        }

        [HttpGet("ViewPasiuni")]
        public async Task<IActionResult> GetAllPasiuni()
        {
            var _context = new ConsilierContext();

            string csvFilePath = "C:\\Users\\anca_\\Desktop\\disertatie\\ml_net\\SubjectPrediction\\SubjectPrediction\\Data\\stud_training.csv";
            string[] passions;
            using (var reader = new StreamReader(csvFilePath))
            {
                var line = reader.ReadLine(); // citirea primului rand din CSV
                passions = line.Split(','); 
            }

            var filteredPassions = passions.Where(p => p.Trim() != "Courses");

            var passionObjects = filteredPassions.Select(p => new { pasiune = p.Trim() });

            var json = JsonConvert.SerializeObject(passionObjects);

            return Ok(json);
        }



        // POST: api/AddNewChestionar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public async Task<IActionResult> PostChestionar(AddChestionar chestionarDTO)
        {
            var _context = new ConsilierContext();

            /*  if (chestionarDTO == null || chestionarDTO.Intrebari == null || !chestionarDTO.Intrebari.Any())
              {
                  return BadRequest("Chestionarul trebuie să conțină cel puțin o întrebare.");
              }*/

            var IdConsilier = _context.Utilizator.Where(w => w.username.Equals(chestionarDTO.username))
                            .Join(_context.Consilier,
                          a => a.id_utilizator,
                          b => b.id_utilizator,
                         (a, b) => new { a, b })
                         .Select(e => new { id_consilier = e.b.id_consilier });


            var chestionar = new Chestionar
            {
                denumire_test = chestionarDTO.DenumireTest,
                id_consilier = IdConsilier.First().id_consilier,
            };

            _context.Chestionar.Add(chestionar);
            await _context.SaveChangesAsync();

            foreach (var intrebareText in chestionarDTO.Intrebari)
            {
                var intrebare = new Intrebare
                {
                    Formulare_intrebare = intrebareText,
                    id_chestionar = chestionar.id_chestionar
                };
                _context.Intrebare.Add(intrebare);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChestionar), new { id = chestionar.id_chestionar }, chestionar);
        }


    }
}

using BE_ConsilierInteligent.DataAccess.Entities;
using BE_ConsilierInteligent.DataAccess.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.DataAccess
{
    public class RaportPersonalitateHollandDAL: ControllerBase
    {
        public async Task<IActionResult> GetRaportHolland(string denumire_solutie)
        {
            var _context = new ConsilierContext();


            var id_solutie = _context.Solutie.Where(w => w.denumire_solutie.Equals(denumire_solutie))
                .Select(e => new { id_solutie = e.id_solutie }).ToList();

            var raport_info = _context.Raport.Where(w => w.id_solutie.Equals(id_solutie.First().id_solutie))
                .Join(_context.Sectiuni_Raport,
                          a => a.id_raport,
                          b => b.id_raport,
                         (a, b) => new { a, b })
                 .Join(_context.Sectiuni_Tip_Raport,
                          x => x.b.id_sectiune_tip_Raport,
                          y => y.id_sectiune_tip_Raport,
                         (x, y) => new { x, y })
                 .Select(e => new { denumire_sectiune = e.x.b.Sectiuni_Tip_Raport.denumire_sectiune, scurta_descriere = e.x.b.Sectiuni_Tip_Raport.scurta_descriere }).ToList();

            return Ok(raport_info);

        }
    }
}

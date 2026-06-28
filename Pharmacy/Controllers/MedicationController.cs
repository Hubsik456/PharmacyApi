using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Database;

namespace Pharmacy.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : ControllerBase
{
    private readonly PharmacyDbContext _context;

    public MedicationController(PharmacyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medication>>> Get()
    {
        var medications = await _context.Medication.ToListAsync();
        return Ok(medications);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Medication>> GetById(int id)
    {
        var medication = await _context.Medication.FindAsync(id);

        if (medication == null)
        {
            return NotFound(new { Message = $"Lek o Id {id} nie zosta³ znaleziony." });
        }

        return Ok(medication);
    }
}
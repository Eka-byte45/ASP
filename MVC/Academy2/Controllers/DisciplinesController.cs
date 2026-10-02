
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy2.Models;

public class DisciplinesController : Controller
{
    private readonly Academy2Context _context;

    public DisciplinesController(Academy2Context context)
    {
        _context = context;
    }

    // GET: DISCIPLINES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Disciplines.ToListAsync());
    }

    // GET: DISCIPLINES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines
            .FirstOrDefaultAsync(m => m.DisciplineID == id);
        if (discipline == null)
        {
            return NotFound();
        }

        return View(discipline);
    }

    // GET: DISCIPLINES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DISCIPLINES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DisciplineID,discipline_name,number_of_lessons")] Discipline discipline)
    {
        if (ModelState.IsValid)
        {
            _context.Add(discipline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(discipline);
    }

    // GET: DISCIPLINES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines.FindAsync(id);
        if (discipline == null)
        {
            return NotFound();
        }
        return View(discipline);
    }

    // POST: DISCIPLINES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? disciplineid, [Bind("DisciplineID,discipline_name,number_of_lessons")] Discipline discipline)
    {
        if (disciplineid != discipline.DisciplineID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(discipline);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(discipline.DisciplineID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(discipline);
    }

    // GET: DISCIPLINES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines
            .FirstOrDefaultAsync(m => m.DisciplineID == id);
        if (discipline == null)
        {
            return NotFound();
        }

        return View(discipline);
    }

    // POST: DISCIPLINES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var discipline = await _context.Disciplines.FindAsync(id);
        if (discipline != null)
        {
            _context.Disciplines.Remove(discipline);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DisciplineExists(int? id)
    {
        return _context.Disciplines.Any(e => e.DisciplineID == id);
    }
}

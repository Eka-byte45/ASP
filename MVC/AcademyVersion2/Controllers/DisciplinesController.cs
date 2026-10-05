
using AcademyVersion2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class DisciplinesController : Controller
{
    private readonly AcademyVersion2Context _context;

    public DisciplinesController(AcademyVersion2Context context)
    {
        _context = context;
    }

    // GET: DISCIPLINES
    public async Task<IActionResult> Index(string sortOrder, string searchString)    
    {
        ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;
        IQueryable<Discipline> disciplines = from discipline in _context.Disciplines select discipline;
        if (!String.IsNullOrEmpty(searchString))
        {
            disciplines = disciplines.Where
                (
                    d =>
                    d.discipline_name.Contains(searchString) 
                );
        }
        switch (sortOrder)
        {
            case "name_desc": disciplines = disciplines.OrderByDescending(d => d.discipline_name); break;
            default: disciplines = disciplines.OrderBy(d => d.discipline_name); break;
        }
        return View(await disciplines.AsNoTracking().ToListAsync());
       // return View(await _context.Disciplines.ToListAsync());
    }

    // GET: DISCIPLINES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines
            .FirstOrDefaultAsync(m => m.discipline_id == id);
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
    public async Task<IActionResult> Create([Bind("discipline_id,discipline_name,number_of_lessons,TeachersRelations")] Discipline discipline)
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
    public async Task<IActionResult> Edit(int? id, [Bind("discipline_id,discipline_name,number_of_lessons,TeachersRelations")] Discipline discipline)
    {
        if (id != discipline.discipline_id)
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
                if (!DisciplineExists(discipline.discipline_id))
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
            .FirstOrDefaultAsync(m => m.discipline_id == id);
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
        return _context.Disciplines.Any(e => e.discipline_id == id);
    }
}


using AcademyVersion2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class TeachersController : Controller
{
    private readonly AcademyVersion2Context _context;

    public TeachersController(AcademyVersion2Context context)
    {
        _context = context;
    }

    // GET: TEACHERS
    public async Task<IActionResult> Index(string sortOrder,string searchString)    
    {
        ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
        ViewData["WorkSinceSortParam"] = sortOrder == "WorkSince" ? "worksince_desc" : "WorkSince";
        ViewData["CurrentFilter"] = searchString;
        IQueryable<Teacher> teachers = from teacher in _context.Teachers select teacher;
        if (!String.IsNullOrEmpty(searchString))
        {
             teachers = teachers.Where
                (
                    t =>
                    t.last_name.Contains(searchString) ||
                    t.first_name.Contains(searchString)
                );
        }
        switch (sortOrder)
        {
            case "name_desc": teachers = teachers.OrderByDescending(s => s.last_name); break;
            case "date_desc": teachers = teachers.OrderByDescending(s => s.birth_date); break;
            case "Date": teachers = teachers.OrderBy(s => s.birth_date); break;
            case "worksince_desc": teachers = teachers.OrderByDescending(t => t.work_since);break;
            case "WorkSince": teachers =teachers.OrderBy(t => t.work_since);break;

            default: teachers = teachers.OrderBy(s => s.last_name); break;
        }
        return View(await teachers.AsNoTracking().ToListAsync());
        //return View(await _context.Teachers.ToListAsync());
    }

    // GET: TEACHERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers
            .FirstOrDefaultAsync(m => m.teacher_id == id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    // GET: TEACHERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TEACHERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("teacher_id,work_since,rate,DisciplinesRelations,Experience,last_name,first_name,middle_name,birth_date,email,phone,photo,FullName,Age")] Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            _context.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // GET: TEACHERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);
    }

    // POST: TEACHERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("teacher_id,work_since,rate,DisciplinesRelations,Experience,last_name,first_name,middle_name,birth_date,email,phone,photo,FullName,Age")] Teacher teacher)
    {
        if (id != teacher.teacher_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(teacher.teacher_id))
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
        return View(teacher);
    }

    // GET: TEACHERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers
            .FirstOrDefaultAsync(m => m.teacher_id == id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    // POST: TEACHERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TeacherExists(int? id)
    {
        return _context.Teachers.Any(e => e.teacher_id == id);
    }
}

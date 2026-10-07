
using AcademyVersion2;
using AcademyVersion2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class GroupsController : Controller
{
    private readonly AcademyVersion2Context _context;

    public GroupsController(AcademyVersion2Context context)
    {
        _context = context;
    }

    // GET: GROUPS
    public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber)    
    {
        ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
        ViewData["DirectionSortParam"] =sortOrder=="direction"?"direction_desc":"direction";
        if (searchString != null) pageNumber = 1;
        ViewData["CurrentFilter"] = searchString;
        IQueryable<Group> groups = _context.Groups.Include(g=>g.Direction);
        if (!String.IsNullOrEmpty(searchString))
        {
            groups = groups.Where
                (
                    g =>
                    g.group_name.Contains(searchString) ||
                    g.Direction.direction_name.Contains(searchString)
                    
                );
        }
        switch (sortOrder)
        {
            case "name_desc": groups = groups.OrderByDescending(g => g.group_name); break;
            case "direction_desc": groups = groups.OrderByDescending(g => g.Direction.direction_name); break;
            case "date_desc": groups = groups.OrderByDescending(g => g.start_date); break;
            case "direction": groups = groups.OrderBy(g => g.Direction.direction_name); break;
            case "Date": groups = groups.OrderBy(g => g.start_date); break;
            default: groups = groups.OrderBy(g => g.group_name); break;
        }
        int pageSize = 5;

        return View
        (
            await PaginatedList<Group>.CreateAsync
            (
                groups.AsNoTracking(),
                pageNumber ?? 1,
                pageSize
            )
        );
        //return View(await groups.AsNoTracking().ToListAsync());
       // return View(await _context.Groups.ToListAsync());
    }

    // GET: GROUPS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var group = await _context.Groups
            .FirstOrDefaultAsync(m => m.group_id == id);
        if (group == null)
        {
            return NotFound();
        }

        return View(group);
    }

    // GET: GROUPS/Create
    public IActionResult Create()
    {
        ViewBag.DirectionId = new SelectList(_context.Directions, "direction_id", "direction_name");
        return View();
    }

    // POST: GROUPS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("group_id,group_name,direction,learning_days,start_time,start_date")] Group group)
    {
        if (ModelState.IsValid)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.DirectionId = new SelectList(_context.Directions, "direction_id", "direction_name", group.direction);
        return View(group);
    }

    // GET: GROUPS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var group = await _context.Groups.FindAsync(id);
        if (group == null)
        {
            return NotFound();
        }
        return View(group);
    }

    // POST: GROUPS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("group_id,group_name,direction,learning_days,start_time,start_date,Direction,Students")] Group group)
    {
        if (id != group.group_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(group);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(group.group_id))
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
        return View(group);
    }

    // GET: GROUPS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var group = await _context.Groups
            .FirstOrDefaultAsync(m => m.group_id == id);
        if (group == null)
        {
            return NotFound();
        }

        return View(group);
    }

    // POST: GROUPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var group = await _context.Groups.FindAsync(id);
        if (group != null)
        {
            _context.Groups.Remove(group);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GroupExists(int? id)
    {
        return _context.Groups.Any(e => e.group_id == id);
    }
}

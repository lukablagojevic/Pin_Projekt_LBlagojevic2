using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pin_Projekt_LBlagojevic2.Data;

public class ViewerController : Controller
{
    private readonly ApplicationDbContext _context;

    public ViewerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Viewers.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var viewer = await _context.Viewers
            .FirstOrDefaultAsync(m => m.ViewerId == id);
        if (viewer == null)
        {
            return NotFound();
        }

        return View(viewer);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Email,Subscriber,Follower")] Viewer viewer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(viewer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(viewer);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var viewer = await _context.Viewers.FindAsync(id);
        if (viewer == null)
        {
            return NotFound();
        }
        return View(viewer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ViewerId,Name,Email,Subscriber,Follower")] Viewer viewer)
    {
        if (id != viewer.ViewerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(viewer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewerExists(viewer.ViewerId))
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
        return View(viewer);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var viewer = await _context.Viewers
            .FirstOrDefaultAsync(m => m.ViewerId == id);
        if (viewer == null)
        {
            return NotFound();
        }

        return View(viewer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var viewer = await _context.Viewers.FindAsync(id);
        _context.Viewers.Remove(viewer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ViewerExists(int id)
    {
        return _context.Viewers.Any(e => e.ViewerId == id);
    }
}

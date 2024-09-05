using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pin_Projekt_LBlagojevic2.Data;
using Pin_Projekt_LBlagojevic2.Models;

public class StreamersController : Controller
{
    private readonly ApplicationDbContext _context;

    public StreamersController(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await _context.Streamers.ToListAsync());
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,ChannelUrl,Description")] Streamer streamer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(streamer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(streamer);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var streamer = await _context.Streamers.FindAsync(id);
        if (streamer == null)
        {
            return NotFound();
        }
        return View(streamer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("StreamerId,Name,ChannelUrl,Description")] Streamer streamer)
    {
        if (id != streamer.StreamerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(streamer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreamerExists(streamer.StreamerId))
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
        return View(streamer);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var streamer = await _context.Streamers
            .FirstOrDefaultAsync(m => m.StreamerId == id);
        if (streamer == null)
        {
            return NotFound();
        }

        return View(streamer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var streamer = await _context.Streamers.FindAsync(id);
        _context.Streamers.Remove(streamer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StreamerExists(int id)
    {
        return _context.Streamers.Any(e => e.StreamerId == id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureApp;

namespace AzureApp.Controllers
{
    public class DescriptionConsumerController : Controller
    {
        private readonly ChallengeDatabaseContext _context;

        public DescriptionConsumerController(ChallengeDatabaseContext context)
        {
            _context = context;
        }

        // GET: DescriptionConsumers
        public async Task<IActionResult> Index()
        {
            var challengeDatabaseContext = _context.DescriptionConsumers.Include(d => d.IdUserNavigation);
            return View(await challengeDatabaseContext.ToListAsync());
        }

        // GET: DescriptionConsumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descriptionConsumer = await _context.DescriptionConsumers
                .Include(d => d.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.DescriptionId == id);
            if (descriptionConsumer == null)
            {
                return NotFound();
            }

            return View(descriptionConsumer);
        }

        // GET: DescriptionConsumers/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Consumers, "UserId", "FirstName");
            return View();
        }

        // POST: DescriptionConsumers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescriptionId,IdUser,ChallengesFinished,ChallengesCreated,ChallengesInUse")] DescriptionConsumer descriptionConsumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descriptionConsumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Consumers, "UserId", "FirstName", descriptionConsumer.IdUser);
            return View(descriptionConsumer);
        }

        // GET: DescriptionConsumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descriptionConsumer = await _context.DescriptionConsumers.FindAsync(id);
            if (descriptionConsumer == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Consumers, "UserId", "FirstName", descriptionConsumer.IdUser);
            return View(descriptionConsumer);
        }

        // POST: DescriptionConsumers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescriptionId,IdUser,ChallengesFinished,ChallengesCreated,ChallengesInUse")] DescriptionConsumer descriptionConsumer)
        {
            if (id != descriptionConsumer.DescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descriptionConsumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescriptionConsumerExists(descriptionConsumer.DescriptionId))
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
            ViewData["IdUser"] = new SelectList(_context.Consumers, "UserId", "FirstName", descriptionConsumer.IdUser);
            return View(descriptionConsumer);
        }

        // GET: DescriptionConsumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descriptionConsumer = await _context.DescriptionConsumers
                .Include(d => d.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.DescriptionId == id);
            if (descriptionConsumer == null)
            {
                return NotFound();
            }

            return View(descriptionConsumer);
        }

        // POST: DescriptionConsumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descriptionConsumer = await _context.DescriptionConsumers.FindAsync(id);
            _context.DescriptionConsumers.Remove(descriptionConsumer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescriptionConsumerExists(int id)
        {
            return _context.DescriptionConsumers.Any(e => e.DescriptionId == id);
        }
    }
}

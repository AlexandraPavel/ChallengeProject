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
    public class EnrolledInChallengeController : Controller
    {
        private readonly ChallengeDatabaseContext _context;

        public EnrolledInChallengeController(ChallengeDatabaseContext context)
        {
            _context = context;
        }

        // GET: EnrolledInChallenges
        public async Task<IActionResult> Index()
        {
            var challengeDatabaseContext = _context.EnrolledInChallenges.Include(e => e.Challenge).Include(e => e.Status).Include(e => e.User);
            return View(await challengeDatabaseContext.ToListAsync());
        }

        // GET: EnrolledInChallenges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolledInChallenge = await _context.EnrolledInChallenges
                .Include(e => e.Challenge)
                .Include(e => e.Status)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EnrollingId == id);
            if (enrolledInChallenge == null)
            {
                return NotFound();
            }

            return View(enrolledInChallenge);
        }

        // GET: EnrolledInChallenges/Create
        public IActionResult Create()
        {
            ViewData["ChallengeId"] = new SelectList(_context.Challenges, "ChallengeId", "Description");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Value");
            ViewData["UserId"] = new SelectList(_context.Consumers, "UserId", "FirstName");
            return View();
        }

        // POST: EnrolledInChallenges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollingId,ChallengeId,UserId,StatusId,NumberDays")] EnrolledInChallenge enrolledInChallenge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolledInChallenge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChallengeId"] = new SelectList(_context.Challenges, "ChallengeId", "Description", enrolledInChallenge.ChallengeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Value", enrolledInChallenge.StatusId);
            ViewData["UserId"] = new SelectList(_context.Consumers, "UserId", "FirstName", enrolledInChallenge.UserId);
            return View(enrolledInChallenge);
        }

        // GET: EnrolledInChallenges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolledInChallenge = await _context.EnrolledInChallenges.FindAsync(id);
            if (enrolledInChallenge == null)
            {
                return NotFound();
            }
            ViewData["ChallengeId"] = new SelectList(_context.Challenges, "ChallengeId", "Description", enrolledInChallenge.ChallengeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Value", enrolledInChallenge.StatusId);
            ViewData["UserId"] = new SelectList(_context.Consumers, "UserId", "FirstName", enrolledInChallenge.UserId);
            return View(enrolledInChallenge);
        }

        // POST: EnrolledInChallenges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollingId,ChallengeId,UserId,StatusId,NumberDays")] EnrolledInChallenge enrolledInChallenge)
        {
            if (id != enrolledInChallenge.EnrollingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolledInChallenge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolledInChallengeExists(enrolledInChallenge.EnrollingId))
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
            ViewData["ChallengeId"] = new SelectList(_context.Challenges, "ChallengeId", "Description", enrolledInChallenge.ChallengeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Value", enrolledInChallenge.StatusId);
            ViewData["UserId"] = new SelectList(_context.Consumers, "UserId", "FirstName", enrolledInChallenge.UserId);
            return View(enrolledInChallenge);
        }

        // GET: EnrolledInChallenges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolledInChallenge = await _context.EnrolledInChallenges
                .Include(e => e.Challenge)
                .Include(e => e.Status)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EnrollingId == id);
            if (enrolledInChallenge == null)
            {
                return NotFound();
            }

            return View(enrolledInChallenge);
        }

        // POST: EnrolledInChallenges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolledInChallenge = await _context.EnrolledInChallenges.FindAsync(id);
            _context.EnrolledInChallenges.Remove(enrolledInChallenge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolledInChallengeExists(int id)
        {
            return _context.EnrolledInChallenges.Any(e => e.EnrollingId == id);
        }
    }
}

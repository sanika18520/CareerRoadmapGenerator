using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerRoadmapGenerator.Models;

namespace CareerRoadmapGenerator.Controllers
{
    public class UserProgressesController : Controller
    {
        private readonly AppDbContext _context;

        public UserProgressesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserProgresses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserProgresses.Include(u => u.Career).Include(u => u.Skill);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserProgresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProgress = await _context.UserProgresses
                .Include(u => u.Career)
                .Include(u => u.Skill)
                .FirstOrDefaultAsync(m => m.UserProgressId == id);
            if (userProgress == null)
            {
                return NotFound();
            }

            return View(userProgress);
        }

        // GET: UserProgresses/Create
        public IActionResult Create()
        {
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId");
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId");
            return View();
        }

        // POST: UserProgresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserProgressId,UserId,CareerId,SkillId,ProgressPercentage")] UserProgress userProgress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProgress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId", userProgress.CareerId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId", userProgress.SkillId);
            return View(userProgress);
        }

        // GET: UserProgresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProgress = await _context.UserProgresses.FindAsync(id);
            if (userProgress == null)
            {
                return NotFound();
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId", userProgress.CareerId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId", userProgress.SkillId);
            return View(userProgress);
        }

        // POST: UserProgresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserProgressId,UserId,CareerId,SkillId,ProgressPercentage")] UserProgress userProgress)
        {
            if (id != userProgress.UserProgressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProgress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProgressExists(userProgress.UserProgressId))
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
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId", userProgress.CareerId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId", userProgress.SkillId);
            return View(userProgress);
        }

        // GET: UserProgresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProgress = await _context.UserProgresses
                .Include(u => u.Career)
                .Include(u => u.Skill)
                .FirstOrDefaultAsync(m => m.UserProgressId == id);
            if (userProgress == null)
            {
                return NotFound();
            }

            return View(userProgress);
        }

        // POST: UserProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProgress = await _context.UserProgresses.FindAsync(id);
            if (userProgress != null)
            {
                _context.UserProgresses.Remove(userProgress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProgressExists(int id)
        {
            return _context.UserProgresses.Any(e => e.UserProgressId == id);
        }
    }
}

using CareerRoadmapGenerator.Data;
using CareerRoadmapGenerator.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CareerRoadmapGenerator.Controllers
{
    public class ProjectIdeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectIdeasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectIdeas
        public async Task<IActionResult> Index()
        {
            var ProjectIdeas = _context.ProjectIdeas.Include(p => p.Career).Include(p => p.Skill);
            return View(await ProjectIdeas.ToListAsync());
        }

        // GET: ProjectIdeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectIdea = await _context.ProjectIdeas
                .Include(p => p.Career)
                .Include(p => p.Skill)
                .FirstOrDefaultAsync(m => m.ProjectIdeaId == id);
            if (projectIdea == null)
            {
                return NotFound();
            }

            return View(projectIdea);
        }

        // GET: ProjectIdeas/Create
        public IActionResult Create()
        {
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId");
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId");
            return View();
        }

        // POST: ProjectIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectIdeaId,Title,Description,Difficulty,CareerId,SkillId")] ProjectIdea projectIdea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId", projectIdea.CareerId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId", projectIdea.SkillId);
            return View(projectIdea);
        }

        // GET: ProjectIdeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectIdea = await _context.ProjectIdeas.FindAsync(id);
            if (projectIdea == null)
            {
                return NotFound();
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId", projectIdea.CareerId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId", projectIdea.SkillId);
            return View(projectIdea);
        }

        // POST: ProjectIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectIdeaId,Title,Description,Difficulty,CareerId,SkillId")] ProjectIdea projectIdea)
        {
            if (id != projectIdea.ProjectIdeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectIdeaExists(projectIdea.ProjectIdeaId))
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
            ViewData["CareerId"] = new SelectList(_context.Careers, "CareerId", "CareerId", projectIdea.CareerId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "SkillId", projectIdea.SkillId);
            return View(projectIdea);
        }

        // GET: ProjectIdeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectIdea = await _context.ProjectIdeas
                .Include(p => p.Career)
                .Include(p => p.Skill)
                .FirstOrDefaultAsync(m => m.ProjectIdeaId == id);
            if (projectIdea == null)
            {
                return NotFound();
            }

            return View(projectIdea);
        }

        // POST: ProjectIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectIdea = await _context.ProjectIdeas.FindAsync(id);
            if (projectIdea != null)
            {
                _context.ProjectIdeas.Remove(projectIdea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectIdeaExists(int id)
        {
            return _context.ProjectIdeas.Any(e => e.ProjectIdeaId == id);
        }
    }
}

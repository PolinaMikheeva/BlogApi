using BlogApi.DataAccess;
using BlogApi.DataAccess.Entities;
using BlogMVC.Areas.Admin.Models.Section;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionController : Controller
    {
        private readonly AppDbContext _context;

        public SectionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SectionController
        public async Task<ActionResult> Index()
        {
            var data = await _context.Sections.Select(p => new SectionFetchVM()
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code
            }).ToListAsync();

            return View(data);
        }

        // POST: SectionController
        [HttpPost]
        public async Task<ActionResult> Add(SectionAddVM sectionVM)
        {
            var newSection = new Section()
            {
                Name = sectionVM.Name,
                Code = sectionVM.Code
            };

            _context.Sections.Add(newSection);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: SectionController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var section = await _context.Sections.FindAsync(id);
        
            return View(section);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SectionFetchVM sectionVM)
        {
            var currentSection = await _context.Sections.FindAsync(sectionVM.Id);

            if (currentSection is not null)
            {
                currentSection.Name = sectionVM.Name;
                currentSection.Code = sectionVM.Code;

                await _context.SaveChangesAsync();
            }
            

            return RedirectToAction("Index");
        }

        // POST: SectionController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(SectionFetchVM sectionVM)
        {
            var sectionDelete = await _context.Sections.FirstOrDefaultAsync(s => s.Id == sectionVM.Id);

            if (sectionDelete is not null)
            {
                _context.Sections.Remove(sectionDelete);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index");
        }
    }
}

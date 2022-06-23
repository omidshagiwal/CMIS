using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMIS.Data;
using CMIS.Models;

namespace CMIS.Controllers
{
    public class Class_SectionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public Class_SectionController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: Class_Sections
        public async Task<IActionResult> Index()
        {
            return View(await _db.ClassSections.ToListAsync());
        }

        // GET: Class_Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class_Sections = await _db.ClassSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (class_Sections == null)
            {
                return NotFound();
            }

            return View(class_Sections);
        }

        // GET: Class_Sections/Create
        public IActionResult Create()
        {
            ViewBag.SchoolId = _db.LookupSchools.Select(p => new SelectListItem
            {
                Text = p.NameDari,
                Value = p.Id.ToString(),
            });
            return View();
        }

        // POST: Class_Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassId,Id,Id,Year")] ClassSection class_Sections)
        {
            if (ModelState.IsValid)
            {
                _db.Add(class_Sections);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(class_Sections);
        }

        // GET: Class_Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class_Sections = await _db.ClassSections.FindAsync(id);
            if (class_Sections == null)
            {
                return NotFound();
            }
            return View(class_Sections);
        }

        // POST: Class_Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassId,Id,Id,Year")] ClassSection class_Sections)
        {
            if (id != class_Sections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(class_Sections);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Class_SectionsExists(class_Sections.Id))
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
            return View(class_Sections);
        }

        // GET: Class_Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class_Sections = await _db.ClassSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (class_Sections == null)
            {
                return NotFound();
            }

            return View(class_Sections);
        }

        // POST: Class_Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var class_Sections = await _db.ClassSections.FindAsync(id);
            _db.ClassSections.Remove(class_Sections);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Class_SectionsExists(int id)
        {
            return _db.ClassSections.Any(e => e.Id == id);
        }
    }
}

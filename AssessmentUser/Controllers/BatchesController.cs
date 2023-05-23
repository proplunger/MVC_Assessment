using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentUser.Context;
using AssessmentUser.Models;

namespace AssessmentUser.Controllers
{
    public class BatchesController : Controller
    {
        private readonly DContext _context;

        public BatchesController(DContext context)
        {
            _context = context;
        }

        // GET: Batches
        public async Task<IActionResult> Index()
        {
            var dContext = _context.Batch.Include(b => b.Course);
            return View(await dContext.ToListAsync());
        }

        // GET: Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Batch == null)
            {
                return NotFound();
            }

            var batch = await _context.Batch
                .Include(b => b.Course)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // GET: Batches/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseName");
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("BatchId,BatchName,Trainer,StartDate,CourseId")] Batch batch)
        {
            
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseName", batch.CourseId);
            return View(batch);
        }

        // GET: Batches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Batch == null)
            {
                return NotFound();
            }

            var batch = await _context.Batch.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseName", batch.CourseId);
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,BatchName,Trainer,StartDate,CourseId")] Batch batch)
        {
            if (id != batch.BatchId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.BatchId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseName", batch.CourseId);
            return View(batch);
        }

        // GET: Batches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Batch == null)
            {
                return NotFound();
            }

            var batch = await _context.Batch
                .Include(b => b.Course)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Batch == null)
            {
                return Problem("Entity set 'DContext.Batch'  is null.");
            }
            var batch = await _context.Batch.FindAsync(id);
            if (batch != null)
            {
                _context.Batch.Remove(batch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
          return (_context.Batch?.Any(e => e.BatchId == id)).GetValueOrDefault();
        }
    }
}

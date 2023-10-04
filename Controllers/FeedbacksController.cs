using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using multiple_choice.Data;
using multiple_choice.Models;

namespace multiple_choice.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly Multiple_choiceDbContext _context;

        public FeedbacksController(Multiple_choiceDbContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            var multiple_choiceDbContext = _context.Feedback.Include(f => f.Option).Include(f => f.Question).Include(f => f.User);
            return View(await multiple_choiceDbContext.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback
                .Include(f => f.Option)
                .Include(f => f.Question)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Feedback_Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            ViewData["OptionId"] = new SelectList(_context.Options, "OptionId", "OptionId");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "InterviewDesc");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,UserId,QuestionId,OptionId")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OptionId"] = new SelectList(_context.Options, "OptionId", "OptionId", feedback.Option_Id);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", feedback.Question_Id);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "InterviewDesc", feedback.User);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["OptionId"] = new SelectList(_context.Options, "OptionId", "OptionId", feedback.Option_Id);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", feedback.Question_Id);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "InterviewDesc", feedback.User);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("FeedbackId,UserId,QuestionId,OptionId")] Feedback feedback)
        {
            if (id != feedback.Feedback_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Feedback_Id))
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
            ViewData["OptionId"] = new SelectList(_context.Options, "OptionId", "OptionId", feedback.Option_Id);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", feedback.Question_Id);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "InterviewDesc", feedback.User);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback
                .Include(f => f.Option)
                .Include(f => f.Question)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Feedback_Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Feedback == null)
            {
                return Problem("Entity set 'Multiple_choiceDbContext.Feedbacks'  is null.");
            }
            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedback.Remove(feedback);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int? id)
        {
            return (_context.Feedback?.Any(e => e.Feedback_Id == id)).GetValueOrDefault();
        }
    }
}

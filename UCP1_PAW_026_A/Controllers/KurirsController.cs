using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_026_A.Models;

namespace UCP1_PAW_026_A.Controllers
{
    public class KurirsController : Controller
    {
        private readonly PesanMakananContext _context;

        public KurirsController(PesanMakananContext context)
        {
            _context = context;
        }

        // GET: Kurirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurir.ToListAsync());
        }

        // GET: Kurirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurir = await _context.Kurir
                .FirstOrDefaultAsync(m => m.IdKurir == id);
            if (kurir == null)
            {
                return NotFound();
            }

            return View(kurir);
        }

        // GET: Kurirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kurirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKurir,NamaKurir,NoHp")] Kurir kurir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurir);
        }

        // GET: Kurirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurir = await _context.Kurir.FindAsync(id);
            if (kurir == null)
            {
                return NotFound();
            }
            return View(kurir);
        }

        // POST: Kurirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKurir,NamaKurir,NoHp")] Kurir kurir)
        {
            if (id != kurir.IdKurir)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurirExists(kurir.IdKurir))
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
            return View(kurir);
        }

        // GET: Kurirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurir = await _context.Kurir
                .FirstOrDefaultAsync(m => m.IdKurir == id);
            if (kurir == null)
            {
                return NotFound();
            }

            return View(kurir);
        }

        // POST: Kurirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurir = await _context.Kurir.FindAsync(id);
            _context.Kurir.Remove(kurir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurirExists(int id)
        {
            return _context.Kurir.Any(e => e.IdKurir == id);
        }
    }
}

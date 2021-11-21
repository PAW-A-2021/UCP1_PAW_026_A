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
    public class PesanansController : Controller
    {
        private readonly PesanMakananContext _context;

        public PesanansController(PesanMakananContext context)
        {
            _context = context;
        }

        // GET: Pesanans
        public async Task<IActionResult> Index()
        {
            var pesanMakananContext = _context.Pesanan.Include(p => p.IdAdminNavigation).Include(p => p.IdKurirNavigation).Include(p => p.IdMakananNavigation).Include(p => p.IdPelangganNavigation);
            return View(await pesanMakananContext.ToListAsync());
        }

        // GET: Pesanans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan
                .Include(p => p.IdAdminNavigation)
                .Include(p => p.IdKurirNavigation)
                .Include(p => p.IdMakananNavigation)
                .Include(p => p.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // GET: Pesanans/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin");
            ViewData["IdKurir"] = new SelectList(_context.Kurir, "IdKurir", "IdKurir");
            ViewData["IdMakanan"] = new SelectList(_context.Makanan, "IdMakanan", "IdMakanan");
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan");
            return View();
        }

        // POST: Pesanans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPesanan,IdAdmin,IdKurir,IdMakanan,IdPelanggan,TotalHarga,TglPemesanan")] Pesanan pesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", pesanan.IdAdmin);
            ViewData["IdKurir"] = new SelectList(_context.Kurir, "IdKurir", "IdKurir", pesanan.IdKurir);
            ViewData["IdMakanan"] = new SelectList(_context.Makanan, "IdMakanan", "IdMakanan", pesanan.IdMakanan);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", pesanan.IdPelanggan);
            return View(pesanan);
        }

        // GET: Pesanans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan.FindAsync(id);
            if (pesanan == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", pesanan.IdAdmin);
            ViewData["IdKurir"] = new SelectList(_context.Kurir, "IdKurir", "IdKurir", pesanan.IdKurir);
            ViewData["IdMakanan"] = new SelectList(_context.Makanan, "IdMakanan", "IdMakanan", pesanan.IdMakanan);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", pesanan.IdPelanggan);
            return View(pesanan);
        }

        // POST: Pesanans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPesanan,IdAdmin,IdKurir,IdMakanan,IdPelanggan,TotalHarga,TglPemesanan")] Pesanan pesanan)
        {
            if (id != pesanan.IdPesanan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesananExists(pesanan.IdPesanan))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", pesanan.IdAdmin);
            ViewData["IdKurir"] = new SelectList(_context.Kurir, "IdKurir", "IdKurir", pesanan.IdKurir);
            ViewData["IdMakanan"] = new SelectList(_context.Makanan, "IdMakanan", "IdMakanan", pesanan.IdMakanan);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggan, "IdPelanggan", "IdPelanggan", pesanan.IdPelanggan);
            return View(pesanan);
        }

        // GET: Pesanans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan
                .Include(p => p.IdAdminNavigation)
                .Include(p => p.IdKurirNavigation)
                .Include(p => p.IdMakananNavigation)
                .Include(p => p.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // POST: Pesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesanan = await _context.Pesanan.FindAsync(id);
            _context.Pesanan.Remove(pesanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesananExists(int id)
        {
            return _context.Pesanan.Any(e => e.IdPesanan == id);
        }
    }
}

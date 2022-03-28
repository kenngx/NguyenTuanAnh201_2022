using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenVanCuong2022560;

namespace NguyenTuanAnh2022201.Controllers
{
    public class NTA2022201Controller : Controller
    {
        private readonly ApplicationDBContext _context;
        StringProcessNTA2022201 StringProcess = new StringProcessNTA2022201(); 


        public NTA2022201Controller(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: nTA0201
        public async Task<IActionResult> Index()
        {
            return View(await _context.NTA0201.ToListAsync());
        }

        // GET: nTA0201/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nTA0201 = await _context.NTA0201
                .FirstOrDefaultAsync(m => m.NTAID == id);
            if (nTA0201 == null)
            {
                return NotFound();
            }

            return View(nTA0201);
        }

        // GET: nTA0201/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: nTA0201/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NTAID,NTAName,NTAGender")] NTA0201 nTA0201nTA0201)
        {
           nTA0201.NTAID = StringProcess.UpperToLower(nTA0201.NTAID);
            nTA0201.NTAName = StringProcess.UpperToLower(nTA0201.NTAName);
            if (ModelState.IsValid)
            {
                _context.Add(nTA0201);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nTA0201);
        }

        // GET: nTA0201/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nTA0201 = await _context.nTA0201.FindAsync(id);
            if (nTA0201 == null)
            {
                return NotFound();
            }
            return View(nTA0201);
        }

        // POST: nTA0201/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NTAID,NTAName,NTAGender")] NTA0560 nTA0201)
        {
            nTA0201.NTAID = StringProcess.UpperToLower(nTA0201.NTANTAID);
            nTA0201.NTAName = StringProcess.UpperToLower(nTA0201.NTANTAName);
            if (id != nTA0201.NTAID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nTA0201);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nTA0201Exists(nTA0201.NTAID))
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
            return View(nTA0201);
        }

        // GET: nTA0201/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nTA0560 = await _context.NTA201
                .FirstOrDefaultAsync(m => m.NTAID == id);
            if (nTA201 == null)
            {
                return NotFound();
            }

            return View(nTA0560);
        }

        // POST: nTA0201/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nTA0201 = await _context.nTA0201.FindAsync(id);
            _context.nTA0201.Remove(nTA0201);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nTA0201Exists(string id)
        {
            return _context.nTA0201.Any(e => e.NTAID == id);
        }
    }
}
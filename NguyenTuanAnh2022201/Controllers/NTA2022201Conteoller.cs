using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StringProcessNTA2022201;

namespace StringProcessNTA2022201.Controllers
{
    public class PersonNTA2022201Controller : Controller
    {
        private readonly ApplicationDBContext _context;
        StringProcessNTA2022201 StringProcess = new StringProcessNTA2022201(); 

        public PersonNTA2022201Controller(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PersonNTA2022201
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonNTA2022201.ToListAsync());
        }

        // GET: PersonNTA2022201/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PersonNTA2022201 = await _context.PersonNTA2022201
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (PersonNTA2022201 == null)
            {
                return NotFound();
            }

            return View(PersonNTA2022201);
        }

        // GET: PersonNTA2022201/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonNTA2022201/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonName")] PersonNTA2022201 personNTA2022201)
        {
            personNTA2022201.PersonID = StringProcess.UpperToLower(personNTA2022201.PersonID);
             personNTA2022201.PersonName = StringProcess.UpperToLower(personNTA2022201.PersonName);
            if (ModelState.IsValid)
            {
                _context.Add(personNTA2022201);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personNTA2022201);
        }

        // GET: PersonNTA2022201/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personNTA2022201 = await _context.PersonNTA2022201.FindAsync(id);
            if (personNTA2022201 == null)
            {
                return NotFound();
            }
            return View(personNTA2022201);
        }

        // POST: PersonNTA2022201/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName")] PersonNTA2022201 personNTA2022201)
        {
            if (id != personNTA2022201.PersonID)
            {
                return NotFound();
            }
            personNTA2022201.PersonID = StringProcess.UpperToLower(personNTA2022201.PersonID);
            personNTA2022201.PersonName = StringProcess.UpperToLower(personNTA2022201.PersonName);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personNTA2022201);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonNTA2022201Exists(personNTA2022201.PersonID))
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
            return View(personNTA2022201);
        }

        // GET: PersonNTA2022201/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personNTA2022201 = await _context.PersonNTA2022201
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (personNTA2022201 == null)
            {
                return NotFound();
            }

            return View(personNTA2022201);
        }

        // POST: PersonNTA2022201/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personNTA2022201 = await _context.PersonNTA2022201.FindAsync(id);
            _context.PersonNTA2022201.Remove(personNTA2022201);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonNTA2022201Exists(string id)
        {
            return _context.PersonNTA2022201.Any(e => e.PersonID == id);
        }
    }
}
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModeleASPNET.Data;
using ModeleASPNET.Models;

namespace ModeleASPNET.Controllers
{
    public class LibrariesController : Controller
    {
        private readonly ModeleASPNETContext _context;

        public LibrariesController(ModeleASPNETContext context)
        {
            _context = context;
        }

        // GET: Libraries
        public async Task<IActionResult> Index()
        {
            Array array;
            List<Librarie> libraries = new List<Librarie>();
            libraries.Add(new Librarie
            {

                ID = 1,
                Denumire = "Nothing Else Matters",
                Durata = 6.25,
                Autor = "Metallica",
            });
            libraries.Add(new Librarie
            {

                ID = 2,
                Denumire = "Bohemian Rhapsody",
                Durata = 5.59,
                Autor = "Queen",
            }); 
            libraries.Add(new Librarie
            {

                ID = 3,
                Denumire = "Smooth Criminal",
                Durata = 9.26,
                Autor = "Michael Jackson",
            });
            libraries.Add(new Librarie
            {

                ID = 4,
                Denumire = "Beat It",
                Durata = 4.59,
                Autor = "Michael Jackson",
            });
            libraries.Add(new Librarie
            {

                ID = 5,
                Denumire = "My Way",
                Durata = 3.47,
                Autor = "Elvis Presley",
            });

            array = libraries.ToArray();
            ViewBag.Libraries = array;
            return View();
        }

        // GET: Libraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarie = await _context.Librarie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (librarie == null)
            {
                return NotFound();
            }

            return View(librarie);
        }

        // GET: Libraries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Denumire,Durata,Autor")] Librarie librarie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librarie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(librarie);
        }

        // GET: Libraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarie = await _context.Librarie.FindAsync(id);
            if (librarie == null)
            {
                return NotFound();
            }
            return View(librarie);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Denumire,Durata,Autor")] Librarie librarie)
        {
            if (id != librarie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librarie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrarieExists(librarie.ID))
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
            return View(librarie);
        }

        // GET: Libraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarie = await _context.Librarie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (librarie == null)
            {
                return NotFound();
            }

            return View(librarie);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librarie = await _context.Librarie.FindAsync(id);
            _context.Librarie.Remove(librarie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrarieExists(int id)
        {
            return _context.Librarie.Any(e => e.ID == id);
        }
    }
}

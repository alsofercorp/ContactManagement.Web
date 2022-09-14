using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contact.Management.Web.Data;
using Contact.Management.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Contact.Management.Web.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return _context.Contacts != null ? View(await _context.Contacts.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);

            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmailAddress,Name,Contact")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacts);
        }

        public async Task<IActionResult> Edit([Bind("Id")] int id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }
            return View(contacts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmailAddress,Name,Contact")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contactsobj = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
                    contactsobj.Contact = contacts.Contact;
                    contactsobj.Name = contacts.Name;
                    contactsobj.EmailAddress = contacts.EmailAddress;
                    
                    _context.Update(contactsobj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsExists(contacts.Id))
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
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
            }
            var contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == int.Parse(id));
            if (contacts != null)
            {
                _context.Contacts.Remove(contacts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactsExists(int id)
        {
          return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

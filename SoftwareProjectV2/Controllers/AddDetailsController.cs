using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwareProjectV2.Data;
using SoftwareProjectV2.Models;

namespace SoftwareProjectV2.Controllers
{
    public class AddDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: AddDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddDetail.ToListAsync());
        }
        [Authorize]
        // GET: AddDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addDetail = await _context.AddDetail
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (addDetail == null)
            {
                return NotFound();
            }

            return View(addDetail);
        }
        [Authorize]
        // GET: AddDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddDetails/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailId,EmployeeName,EmployeeSecondName,EmployeeNumber,EmployeePPS,Email,Mobile,EmployeeStartDate")] AddDetail addDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addDetail);
        }

        // GET: AddDetails/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addDetail = await _context.AddDetail.FindAsync(id);
            if (addDetail == null)
            {
                return NotFound();
            }
            return View(addDetail);
        }

        // POST: AddDetails/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailId,EmployeeName,EmployeeSecondName,EmployeeNumber,EmployeePPS,Email,Mobile,EmployeeStartDate")] AddDetail addDetail)
        {
            if (id != addDetail.DetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddDetailExists(addDetail.DetailId))
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
            return View(addDetail);
        }
        [Authorize]
        // GET: AddDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addDetail = await _context.AddDetail
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (addDetail == null)
            {
                return NotFound();
            }

            return View(addDetail);
        }

        // POST: AddDetails/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addDetail = await _context.AddDetail.FindAsync(id);
            _context.AddDetail.Remove(addDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddDetailExists(int id)
        {
            return _context.AddDetail.Any(e => e.DetailId == id);
        }
    }
}

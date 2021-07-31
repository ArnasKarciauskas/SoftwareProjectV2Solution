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
    public class AddEquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddEquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AddEquipments
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddEquipment.ToListAsync());
        }
        // GET: AddEquipments/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addEquipment = await _context.AddEquipment
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (addEquipment == null)
            {
                return NotFound();
            }

            return View(addEquipment);
        }
        // GET: AddEquipments/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddEquipments/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentId,DeviceName,DeviceType,SerialNo,AssignedTo,AssignedDate")] AddEquipment addEquipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addEquipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addEquipment);
        }

        // GET: AddEquipments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addEquipment = await _context.AddEquipment.FindAsync(id);
            if (addEquipment == null)
            {
                return NotFound();
            }
            return View(addEquipment);
        }

        // POST: AddEquipments/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentId,DeviceName,DeviceType,SerialNo,AssignedTo,AssignedDate")] AddEquipment addEquipment)
        {
            if (id != addEquipment.EquipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addEquipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddEquipmentExists(addEquipment.EquipmentId))
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
            return View(addEquipment);
        }
        // GET: AddEquipments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addEquipment = await _context.AddEquipment
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (addEquipment == null)
            {
                return NotFound();
            }

            return View(addEquipment);
        }

        // POST: AddEquipments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addEquipment = await _context.AddEquipment.FindAsync(id);
            _context.AddEquipment.Remove(addEquipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddEquipmentExists(int id)
        {
            return _context.AddEquipment.Any(e => e.EquipmentId == id);
        }
    }
}

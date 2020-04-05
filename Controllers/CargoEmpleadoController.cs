﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models.DAL;
using CRUD.Models.Entities;

namespace CRUD.Controllers
{
    public class CargoEmpleadoController : Controller
    {
        private readonly DbContextPrueba _context;
        /*private CargoEmpleado cargoEmpleado
        */
        public CargoEmpleadoController(DbContextPrueba context)
        {
            _context = context;
        }

        // GET: CargoEmpleado
        public async Task<IActionResult> Index()
        {
            return View(await _context.cargoEmpleados.ToListAsync());
        }

        // GET: CargoEmpleado/Details/5
        /*
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.cargoEmpleados
                .FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }

            return View(cargoEmpleado);
        }
        */

        // GET: CargoEmpleado/Create
        public async Task<IActionResult> CreareditarCargo(int id = 0)
        {
            
            if (id == 0)
                return View(new CargoEmpleado());
            else
                
            return View(_context.cargoEmpleados.Find(id));

        }

        // POST: CargoEmpleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreareditarCargo([Bind("IdCargo,Cargo")] CargoEmpleado cargoEmpleado)
        {
            if (ModelState.IsValid)
            {
                if (cargoEmpleado.IdCargo == 0)
                    _context.Add(cargoEmpleado);
                else
                    _context.Update(cargoEmpleado);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargoEmpleado);
        }

       
        
        /*    
       // POST: CargoEmpleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        */
        
        /*
        public async Task<IActionResult> Edit(int id, [Bind("IdCargo,Cargo")] CargoEmpleado cargoEmpleado)
        {
            if (id != cargoEmpleado.IdCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoEmpleadoExists(cargoEmpleado.IdCargo))
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
            return View(cargoEmpleado);
        }

        // GET: CargoEmpleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.cargoEmpleados
                .FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }

            return View(cargoEmpleado);
        }
        */
        // POST: CargoEmpleado/Delete/5
        /*
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        */
        public async Task<IActionResult> EliminarCargo(int id)
        {
            var cargoEmpleado = await _context.cargoEmpleados.FindAsync(id);
            _context.cargoEmpleados.Remove(cargoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}

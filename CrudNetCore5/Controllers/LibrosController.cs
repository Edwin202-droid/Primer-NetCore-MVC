using CrudNetCore5.Data;

using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        //Primero importamos el applicationdbcontext porque eso nos permite acceder a la base de datos
        private readonly ApplicationDbContext _context;
        //Constructor para inicializar el acceso a la db
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            //Lo lleva a la vista de Libros
            return View(listaLibros);
        }

        //Http Get Crear Libro
        public IActionResult Create()
        {
            //Retorna un formulario
            return View();
        }

        //Http Post Crear Libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            //Validando los modelos
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                //Un mensaje en patalla que nos indique que el libro fue creado
                TempData["mensaje"] = "El libro fue creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Edit: Buscamos el libro y retornamos al view
        public IActionResult Edit(int? id)
        {
            if(id== null|| id == 0)
            {
                return NotFound();
            }

            //Obtener libro
            var libro = _context.Libro.Find(id);

            if(libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        //Http Post Actualizar Libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            //Validando los modelos
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                //Un mensaje en patalla que nos indique que el libro fue actualizado
                TempData["mensaje"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Delete: Buscamos el libro y retornamos al view
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        //Http Post Eliminar Libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            //Obtener el libro por id
            var libro = _context.Libro.Find(id);

            if(libro == null)
            {
                return NotFound();
            }

                _context.Libro.Remove(libro);
                _context.SaveChanges();

                //Un mensaje en patalla que nos indique que el libro fue eliminado
                TempData["mensaje"] = "El libro se ha eliminado correctamente";
                return RedirectToAction("Index");
            
        }
    }
}

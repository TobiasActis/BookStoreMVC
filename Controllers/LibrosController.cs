using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreMVC.Models;
using NPOI.SS.UserModel;
using System.Data;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using BookStoreMVC.Migrations;
using ServiceStack.Text;

namespace BookStoreMVC.Controllers
{
    public class LibrosController : Controller
    {
        private readonly DataBaseContext _context;

        public LibrosController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.Libros.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.Genero);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutorRefId"] = new SelectList(_context.Autores, "Id", "Nombre");
            ViewData["EditorialRefId"] = new SelectList(_context.Editoriales, "Id", "Nombre");
            ViewData["GeneroRefId"] = new SelectList(_context.Generos, "Id", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImagenLibro,Titulo,GeneroRefId,AutorRefId,EditorialRefId,Precio,NroPaginas")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                   // var imageFile = files[0];
                    //if (imageFile.Length > 0)
                    //{
                      //  var pathDestination = Path.Combine(env.WebRootPath, "images\\libros");
                   
                        //var fileDestination = Guid.NewGuid().ToString();
                        //fileDestination = fileDestination.Replace("-", "");
                        //fileDestination += Path.GetExtension(imageFile.FileName);
                        //var DestinationRoute = Path.Combine(pathDestination, fileDestination);
                        //using (var filestream = new FileStream(DestinationRoute, FileMode.Create))
                        //{
                          //  imageFile.CopyTo(filestream);
                          //  libro.ImagenLibro = fileDestination;
                        //}
                    //}
                }
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorRefId"] = new SelectList(_context.Autores, "Id", "Nombre", libro.AutorRefId);
            ViewData["EditorialRefId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialRefId);
            ViewData["GeneroRefId"] = new SelectList(_context.Generos, "Id", "Nombre", libro.GeneroRefId);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutorRefId"] = new SelectList(_context.Autores, "Id", "Nombre", libro.AutorRefId);
            ViewData["EditorialRefId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialRefId);
            ViewData["GeneroRefId"] = new SelectList(_context.Generos, "Id", "Nombre", libro.GeneroRefId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImagenLibro,Titulo,GeneroRefId,AutorRefId,EditorialRefId,Precio,NroPaginas")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["AutorRefId"] = new SelectList(_context.Autores, "Id", "Nombre", libro.AutorRefId);
            ViewData["EditorialRefId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialRefId);
            ViewData["GeneroRefId"] = new SelectList(_context.Generos, "Id", "Nombre", libro.GeneroRefId);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros == null)
            {
                return Problem("Entity set 'DataBaseContext.Libros'  is null.");
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return (_context.Libros?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
        [HttpGet]
        public async Task<FileResult> ExportarLibrosAExcel()
        {
            var libros = await _context.Libros.ToListAsync();
            var nombreArchivo = $"Libros.xlsx";
            return GenerarExcel(nombreArchivo, libros);
        }

        private FileResult GenerarExcel(string nombreArchivo, IEnumerable<Libro> libros)
        {
            DataTable dataTable = new DataTable("Libros");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id"),
                new DataColumn("Titulo"),
                new DataColumn("Genero"),
                new DataColumn("Autor"),
                new DataColumn("Editorial"),
                new DataColumn("Numero de paginas"),
                new DataColumn("Precio")
            });

            foreach (var libro in libros)
            {
                dataTable.Rows.Add(libro.Id,
                libro.Titulo, libro.GeneroRefId, libro.AutorRefId, libro.EditorialRefId, libro.NroPaginas, libro.Precio);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        nombreArchivo);
                }
            }
        }
    }
}

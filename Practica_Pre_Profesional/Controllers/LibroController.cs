using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Practica_Pre_Profesional.Models;
using System.Reflection.Metadata;

namespace Practica_Pre_Profesional.Controllers
{
    public class LibroController : Controller
    {
        private readonly BdpracticaContext _context;

        public LibroController(BdpracticaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListarLibros()
        {
            var asingnatura = _context.TbLibros.Include(R => R.IdAsingNavigation);
         
            return View(await asingnatura.ToListAsync());
        }

        public async Task<IActionResult> FiltrarLibro(string Descripcion)
        {

            if (Descripcion == null)
            {
                var asingnatura = _context.TbLibros.Include(R => R.IdAsingNavigation);

                return View(await asingnatura.ToListAsync());
            }
            var movie = await _context.TbLibros.FirstOrDefaultAsync(m => m.Descripcion == Descripcion);

            if(movie == null)
            {
                var asingnatura = _context.TbLibros.Include(R => R.IdAsingNavigation);

                return View(await asingnatura.ToListAsync());
            }
            var movieList = new List<TbLibro> { movie };
            return View(movieList);

        }

        public IActionResult CreateLibro()
        {
            ViewData["asignatura"] = new SelectList(_context.TbAsignaturas, "IdAsig", "Descripcion");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibro (string Descripcion, int IdAsing, int stock)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName= "@descripcion",
                    SqlDbType= System.Data.SqlDbType.VarChar,
                    Value=Descripcion
                },
                new SqlParameter()
                {
                    ParameterName = "@Id_asing",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = IdAsing
                },
                new SqlParameter()
                {
                    ParameterName="@stock",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = stock
                }
            };
            var InsertLibro = await _context.Database.ExecuteSqlRawAsync($"exec Insert_Libro @descripcion,@Id_asing,@stock", param);
            if(InsertLibro == 1)
            {
                return  RedirectToAction("ListarLibros");
            }
            else
            {
                return View();
            };
        }

        public async Task<IActionResult> EditarLibro(int id)
        {
            if(id == null)
            {
                var asingnatura = _context.TbLibros.Include(R => R.IdAsingNavigation);

                return View(await asingnatura.ToListAsync());
            }
            var editar = await _context.TbLibros.FindAsync(id);
            ViewData["asignatura"] = new SelectList(_context.TbAsignaturas, "IdAsig", "Descripcion");
            return View(editar);
        }

        [HttpPost]
        public async Task<IActionResult> EditarLibro(int id, string descripcion, int IdAsing, int stock)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@IdLibro",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = id
                },
                new SqlParameter()
                {
                    ParameterName = "@descripcion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = descripcion
                },
                new SqlParameter()
                {
                    ParameterName = "@IdAsigna",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value =IdAsing
                },
                new SqlParameter()
                {
                    ParameterName = "@stock",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = stock
                }
            };
            var EditarLibro = await _context.Database.ExecuteSqlRawAsync($"exec Update_Libro @IdLibro,@descripcion,@IdAsigna,@stock ", param);
            if (EditarLibro == 1)
            {
                return RedirectToAction("ListarLibros");
            }
            else
            {
                return View();
            };

        }

        public async Task<IActionResult> DeleteLibro(int id)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = id
                }
            };
            var eliminarLibro = await _context.Database.ExecuteSqlRawAsync($"exec delete_Libro @Id", param);
            return RedirectToAction("ListarLibros");

        }


    }
}

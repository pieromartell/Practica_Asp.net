using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Practica_Pre_Profesional.Models;

namespace Practica_Pre_Profesional.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly BdpracticaContext _context;

        public AsignaturaController(BdpracticaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListarAsignatura()
        {
            return View(await _context.TbAsignaturas.ToListAsync());
        }
        public async Task<IActionResult> CreateAsigna()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsignatura(string descripcion, int estado)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@descripcion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = descripcion
                },
                new SqlParameter()
                {
                    ParameterName= "@estado",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estado
                },

            };
            var InsertAsigna = await _context.Database.ExecuteSqlRawAsync($"exec Insert_Asignatura @descripcion,@estado ", param);
            if(InsertAsigna == 1)
            {
                return View(await _context.TbAsignaturas.ToListAsync());
            }
            else
            {
                return View();
            };
        }


        public async Task<IActionResult> EditarAsig(int? id)
        {
            if(id == null)
            {
                return View(await _context.TbAsignaturas.ToListAsync());
            }
            var editar = await _context.TbAsignaturas.FindAsync(id);
            return View (editar);
        }
        [HttpPost]
        public async Task<IActionResult> EditarAsig(int? id, string descripcion, int estado)
        {
            var param = new SqlParameter[]
            {
               new SqlParameter()
               {
                   ParameterName="@Id",
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
                   ParameterName = "@estado",
                   SqlDbType = System.Data.SqlDbType.Int,
                   Value = estado
                }
            };
            var EditarAsingna =await _context.Database.ExecuteSqlRawAsync($"exec Update_Asignatura @Id, @descripcion, @estado ", param);
            if (EditarAsingna == 1)
            {
                return RedirectToAction("ListarAsignatura");
            }
            else
            {
                return View();
            };
           
        }
            
        
        //public async Task<IActionResult> DeleteAsig(int id)
        //{
        //    var param = new SqlParameter[]
        //    {
        //        new SqlParameter()
        //        {
        //            ParameterName ="@Id",

        //            SqlDbType = System.Data.SqlDbType.Int,
        //            Value = id
        //        },

        //    };
        //    var eliminar = await _context.Database.ExecuteSqlRawAsync($"exec Delete_Asignatura @Id", param);
        //    return RedirectToAction("ListarAsignatura");
        //}
    }
}

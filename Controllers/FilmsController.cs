using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeliMex.Entities;
using PeliMex.Data;

namespace PeliMex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FilmsController:Controller
    {
        private readonly AppDbContext context;
        public FilmsController(AppDbContext context)
        {
            this.context = context;
        }

        //LISTA
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Peliculas.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //AGREGAR
        [HttpPost]
        public ActionResult Create([FromBody]films peliculas)
        {
            if(peliculas == null)
            return NotFound("Llene los datos Porfavor");
            try
            {
                context.Peliculas.Add(peliculas);
                context.SaveChanges();
                return Ok("Pelicula Registrada");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //EDITAR
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] films peliculas)
        {
            try
            {
                if (peliculas.Id == id)
                {
                    context.Entry(peliculas).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok("Exito");
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //ELIMINAR
        [HttpDelete("{Id}")]
        public ActionResult Deleted(int id)
        {
            try
            {
                var peliculas = context.Peliculas.FirstOrDefault(f => f.Id == id);
                if (peliculas != null)
                {
                    context.Peliculas.Remove(peliculas);
                    context.SaveChanges();
                    return Ok("Removido");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
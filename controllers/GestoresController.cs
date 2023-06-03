using apisGestores.Context;
using apisGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apisGestores.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {   
        private readonly AppDbContext context;
            public GestoresController(AppDbContext context)
        {
            this.context = context;
        }
            
        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.gestores_Bd.ToList());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}",Name ="GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestores = context.gestores_Bd.FirstOrDefault(g => g.Id == id);
                return Ok(gestores);
            } catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody] Gestores_Bd gestor)
        {
            try
            {
                context.gestores_Bd.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.Id }, gestor);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Gestores_Bd gestor)
        {
            try
            {
                if (gestor.Id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.Id }, gestor);
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

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)

        {
            try
            {
                var gestor = context.gestores_Bd.FirstOrDefault(g => g.Id == id);
                if (gestor != null)
                {
                    context.gestores_Bd.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

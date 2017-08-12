using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using tincApi.DAL;
using tincApi.Models;

namespace tincApi.Controllers.Api
{
    public class DesportoController : ApiController
    {
        private TincContext _context;

        public DesportoController()
        {
            _context = new TincContext();
        }

        [HttpGet, Route("API/Desporto")]
        public IHttpActionResult GetDesportos()
        {
            var desportoList = _context.Desporto.AsNoTracking().ToList();
            return Ok(desportoList);
        }

        [HttpGet, Route("API/Desporto/{id}")]
        public IHttpActionResult GetDesporto(int id)
        {
            var desporto = _context.Desporto.SingleOrDefault(c => c.ID == id);

            if (desporto == null)
                return NotFound();

            return Ok(desporto);
        }

        [HttpPost, Route("API/Desporto")]
        public IHttpActionResult CreateDesporto(DTO.Desporto desportoToAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var desporto = Mapper.Map<DTO.Desporto, Models.Desporto>(desportoToAdd);

            _context.Desporto.Add(desporto);
            _context.SaveChanges();

            desportoToAdd.ID = desporto.ID;

            return Created(new Uri(Request.RequestUri + "/" + desporto.ID), desportoToAdd);
        }

        [HttpPut, Route("API/Desporto/{id}")]
        public IHttpActionResult UpdateDesporto(int id, DTO.Desporto desportoToUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var desportoInDb = _context.Desporto.SingleOrDefault(c => c.ID == id);

            if (desportoInDb == null)
                return NotFound();

            desportoToUpdate.ID = desportoInDb.ID;
            Mapper.Map(desportoToUpdate, desportoInDb);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("API/Desporto/{id}")]
        public IHttpActionResult DeleteDesporto(int id)
        {

            var desportoInDb = _context.Desporto.SingleOrDefault(c => c.ID == id);

            if (desportoInDb == null)
                return NotFound();

            _context.Desporto.Remove(desportoInDb);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return Ok();
        }
    }
}
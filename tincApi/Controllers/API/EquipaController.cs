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
    public class EquipaController : ApiController
    {
        private TincContext _context;

        public EquipaController()
        {
            _context = new TincContext();
        }

        [HttpGet, Route("API/Equipa")]
        public IHttpActionResult GetEquipas()
        {
            var equipaList = _context.Equipa.AsNoTracking().ToList();
            return Ok(equipaList);
        }

        [HttpGet, Route("API/Equipa/{id}")]
        public IHttpActionResult GetEquipa(int id)
        {
            var equipa = _context.Equipa.SingleOrDefault(c => c.ID == id);

            if (equipa == null)
                return NotFound();

            return Ok(equipa);
        }

        [HttpPost, Route("API/Equipa")]
        public IHttpActionResult CreateEquipa(DTO.Equipa equipaToAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var equipa = Mapper.Map<DTO.Equipa, Models.Equipa>(equipaToAdd);

            _context.Equipa.Add(equipa);
            _context.SaveChanges();

            equipaToAdd.ID = equipa.ID;

            return Created(new Uri(Request.RequestUri + "/" + equipa.ID), equipaToAdd);
        }

        [HttpPut, Route("API/Equipa/{id}")]
        public IHttpActionResult UpdateEquipa(int id, DTO.Equipa equipaToUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var equipaInDb = _context.Equipa.SingleOrDefault(c => c.ID == id);

            if (equipaInDb == null)
                return NotFound();

            equipaToUpdate.ID = equipaInDb.ID;
            Mapper.Map(equipaToUpdate, equipaInDb);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("API/Equipa/{id}")]
        public IHttpActionResult DeleteEquipa(int id)
        {

            var equipaInDb = _context.Equipa.SingleOrDefault(c => c.ID == id);

            if (equipaInDb == null)
                return NotFound();

            _context.Equipa.Remove(equipaInDb);
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
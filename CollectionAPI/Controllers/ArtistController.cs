using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CollectionAPI.Models;

namespace CollectionAPI.Controllers
{
	[Route("api/[controller]")]
	public class ArtistController : Controller
	{

		//  Db handle
		private readonly CollectionContext _context;

		public ArtistController(CollectionContext context)
		{
			_context = context;

			if (_context.Artist.Count() == 0)
			{
				_context.Artist.Add(new Artist { Name = "Exodus" });
				_context.SaveChanges();
			}
		}

		[HttpGet]
		public IEnumerable<Artist> GetAll()
		{
			return _context.Artist.ToList();
		}

		[HttpGet("{id:long}", Name = "GetArtist")]
		public IActionResult GetById(long id)
		{
			var artist = _context.Artist.FirstOrDefault(a => a.Id == id);
			if (artist == null)
			{
				return NotFound();
			}
			return new ObjectResult(artist);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Artist artist)
		{
			if (artist == null)
			{
				return BadRequest();
			}

			//  Set created to now
			artist.Created = DateTime.Now;

			_context.Artist.Add(artist);
			_context.SaveChanges();

			//  Set location in header to the "GetArtist" route. So we return the created object
			return CreatedAtRoute("GetArtist", new { id = artist.Id }, artist);
		}

		//  Patch used for update, because we dont want to update all fields wich http-update require
		[HttpPatch("{id:long}")]
		public IActionResult Update(long id, [FromBody] Artist artist)
		{
			if(artist == null)
			{
				return BadRequest();
			}

			var artistDb = _context.Artist.FirstOrDefault(a => a.Id == id);
			if (artistDb == null)
			{
				return NotFound();
			}

			//  Set new values
			artistDb.Name = artist.Name;
			artistDb.OriginCity = artist.OriginCity;
			artistDb.OriginCountry = artist.OriginCountry;
			artistDb.Updated = DateTime.Now;

			_context.Artist.Update(artistDb);
			_context.SaveChanges();

			return CreatedAtRoute("GetArtist", new { id = artist.Id }, artist);
		}

		[HttpDelete("{id:long}")]
		public IActionResult Delete(long id)
		{
			var artist = _context.Artist.FirstOrDefault(a => a.Id == id);
			if (artist == null)
			{
				return NotFound();
			}

			_context.Artist.Remove(artist);
			_context.SaveChanges();

			return new NoContentResult();
		}

	}
}

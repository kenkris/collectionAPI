using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CollectionAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

		[HttpGet("{id}", Name = "GetArtist")]
		public IActionResult GetById(long id)
		{
			var artist = _context.Artist.FirstOrDefault(t => t.Id == id);
			if (artist == null)
			{
				return NotFound();
			}
			return new ObjectResult(artist);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Artist artist){
			if(artist == null)
			{
				return BadRequest();
			}

			_context.Artist.Add(artist);
			_context.SaveChanges();

			return CreatedAtRoute("GetArtist", new { id = artist.Id }, artist);
		}
	}
}

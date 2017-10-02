using System;
using Microsoft.EntityFrameworkCore;


namespace CollectionAPI.Models
{
	public class CollectionContext : DbContext
	{
		/*
		 * When this constructor is called the options passed to this constructor is passed on to 
		 * "base's" constructor. Here base point to the DbContext class that this class extends.
		 * Known as constructor chaining
		 */
		public CollectionContext(DbContextOptions<CollectionContext> options) : base(options)
		{
		}

		/*
		 * Models handled by this db handler (CollectionManContext)
		 */
		public DbSet<Artist> Artist { get; set; }


	}
}

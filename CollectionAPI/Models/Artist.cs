﻿using System;
namespace CollectionAPI.Models
{
	public class Artist
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime? Formed { get; set; }
		public string OriginCity { get; set; }
		public string OriginCountry { get; set; }
		public DateTime? Created { get; set; }  //  Nullable
		public DateTime? Updated { get; set; }

		public Artist()
		{
		}
	}
}

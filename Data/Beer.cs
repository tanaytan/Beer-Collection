using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Collection.Data
{
    public class Beer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [JsonIgnore]
        public virtual ICollection<Rating> Ratings { get; set; }

        public double Rating { get
            {
                return Ratings?.Average(x => x.RatingNum) ?? 0;
            } }
    }

    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int RatingNum { get; set; }

        public int BeerId { get; set; }

        public virtual Beer Beer { get; set; }
    }
}
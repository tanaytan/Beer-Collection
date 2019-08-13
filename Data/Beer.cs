using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer_Collection.Data
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }

        public bool IsDone { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_book.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Relationships
        public List<Book> Books { get; set; }
    }
}

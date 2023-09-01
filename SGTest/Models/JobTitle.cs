using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace SGTest.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class JobTitle
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}

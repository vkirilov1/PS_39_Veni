using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class DBLogEntry
    {
        [Key]
        public int Id { get; set; }
        public string LogLevel { get; set; }
        public int EventId { get; set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}


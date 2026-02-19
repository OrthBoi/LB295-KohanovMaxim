using System;
using System.ComponentModel.DataAnnotations;

namespace KohanovMaximLB_295.Models
{
    public class EpsteinEntry
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Persons { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

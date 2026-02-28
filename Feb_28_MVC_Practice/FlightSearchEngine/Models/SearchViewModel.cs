using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FlightSearchEngine.Models
{
    public class SearchViewModel
    {
        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [Range(1, 10)]
        public int NumberOfPersons { get; set; }

        [ValidateNever]   // ✅ ADD THIS
        public SelectList SourceList { get; set; }

        [ValidateNever]   // ✅ ADD THIS
        public SelectList DestinationList { get; set; }
    }
}
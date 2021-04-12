using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookClient.Shared.Models
{
    public class Publisherr
    {
        [Key]
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
        public string Location { get; set; }
    }
}

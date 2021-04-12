using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.ViewModels
{
    public class AuthorView
    {
        public int AuthorID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string BirthDateString
        {
            get
            {
                return BirthDate.ToLongDateString();
            }
        }

        public List<BookAuthorView> BookAuthors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Library_Model.Models
{
    public class Library_Book_Model
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required.")]
        [StringLength(50, ErrorMessage = "ISBN cannot exceed 50 characters.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Publish date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string Category { get; set; }
    }
}



//Frontend(View) → Razor Views, Bootstrap, jQuery (validation, UI)

//Backend (Controller) → ASP.NET MVC (C#)

//Data Access Layer → Repository Pattern using ADO.NET (SqlCommand, SqlDataAdapter, DataTable)

//Database → SQL Server (with your Login and Library_Book tables)

//Session Management → ASP.NET Session to store authenticated user data
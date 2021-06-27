using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ReWebApplication.Models
{
    public class Book
    {

        public int Id { get; set; }

      
        public string Title { get; set; }
        [Required(ErrorMessage = "Nhập thiếu tên sách")]
       
        public string Author { get; set; }
        [Required(ErrorMessage = "Nhập thiếu tên tác giả")]
        [StringLength(50, ErrorMessage = "Tên tác giả ít hơn 50 kí tự")]
        public int PublicYear { get; set; }
        public double Price { get; set; }
        public string Cover { get; set; }
    }
}
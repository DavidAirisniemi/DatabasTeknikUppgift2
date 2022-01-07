using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBibliotek.Models
{
    public class Book
    {
        [Key]
        public int _id { get; set; }
        
        [DisplayName("Titel")]
        public string _title { get; set; }
        
        [DisplayName("Författare")]
        public string _author { get; set; }
        
        [DisplayName("Genre")]
        public string _genre { get; set; }
       
        [DisplayName("SEK")]
        public int _price { get; set; }
    }
}

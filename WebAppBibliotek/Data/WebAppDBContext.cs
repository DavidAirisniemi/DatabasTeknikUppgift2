using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBibliotek.Models;

namespace WebAppBibliotek.Data
{
    public class WebAppDBContext :DbContext
    {
        public WebAppDBContext(DbContextOptions<WebAppDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}

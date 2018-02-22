using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.Data
{
    public class AutohandelContext : DbContext
    {
        //Om straks met behulp van Dependency Injection de Context configureerbaar te maken moet je een speciale constructor definiëren.
        public AutohandelContext(DbContextOptions<AutohandelContext> options) : base(options)
        { }

        //Voeg de DbSet<T> collecties van de gewenste Entity klassen toe aan je Context.
        //    Dit worden in essentie de tabellen in de databank.
    }
}

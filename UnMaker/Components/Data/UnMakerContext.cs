using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnMaker.Components.Models;

namespace UnMaker.Components.Data
{
    public class UnMakerContext : DbContext
    {
        public UnMakerContext (DbContextOptions<UnMakerContext> options)
            : base(options)
        {
        }

        public DbSet<Deck> Deck { get; set; } = default!;
        public DbSet<Card> Card { get; set; } = default!;
        public DbSet<HeroCard> HeroCard { get; set; } = default!;
    }
}

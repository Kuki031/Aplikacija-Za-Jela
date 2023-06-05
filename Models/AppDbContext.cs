using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RestoranJelaRPA.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Proizvod> Products { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }

        public DbSet<Recept> Recepti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proizvod>().Property(f => f.Cijena).HasPrecision(10, 2);

            modelBuilder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Pizza" },
                new Kategorija() { Id = 2, Naziv = "Burgeri" },
                new Kategorija() { Id = 3, Naziv = "Tjestenina" },
                new Kategorija() { Id = 4, Naziv = "Jela od piletine" },
                new Kategorija() { Id = 5, Naziv = "Juhe" },
                new Kategorija() { Id = 6, Naziv = "Alkoholna pića" },
                new Kategorija() { Id = 7, Naziv = "Bezalkoholna pića" }
                );

            modelBuilder.Entity<Proizvod>().HasData(
                new Proizvod() { Id = 1, Naziv = "The cowboy burger", Cijena = 25.99m, SlikaUrl = "https://www.thecookierookie.com/wp-content/uploads/2015/05/featured-cowboy-burger-recipe.jpg",Sastojci = "Rajčica,pecivo,kečap,majoneza,pljeskavica", KategorijaId = 2 },
                new Proizvod() { Id = 2, Naziv = "Mexican burger", Cijena = 20.99m, SlikaUrl = "https://www.chewoutloud.com/wp-content/uploads/2015/06/mexican-burgers-6.jpg", Sastojci = "Rajčica,pecivo,kečap,majoneza,pljeskavica,guac,feferoni", KategorijaId = 2 },
                new Proizvod() { Id = 3, Naziv = "Capriciossa", Cijena = 17.99m, SlikaUrl = "https://www.italianstylecooking.net/wp-content/uploads/2022/01/Pizza-capricciosa-1200x675.jpg", Sastojci = "Rajčica,pecivo,kečap,gljive,šunka,oregano", KategorijaId = 1 },
                new Proizvod() { Id = 4, Naziv = "Vesuvio", Cijena = 17.99m, SlikaUrl = "https://www.foodandwine.com/thmb/aL6WKUhWMTKgK_PXjkS0CvCFpzs=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/201012-xl-pizza-vesuvio-2000-77cc8c57c18f41a2a9976c84b47334a0.jpg", Sastojci = "Rajčica,pecivo,kečap,sir", KategorijaId = 1 },
                new Proizvod() { Id = 5, Naziv = "Carbonara", Cijena = 12.50m, SlikaUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Espaguetis_carbonara.jpg/640px-Espaguetis_carbonara.jpg", Sastojci = "Tjestenina,slanina,jaja,sol,maslinovo ulje", KategorijaId = 3 },
                new Proizvod() { Id = 6, Naziv = "Pileća krilca", Cijena = 10.99m, SlikaUrl = "https://preppykitchen.com/wp-content/uploads/2022/09/Chicken-Wings-Recipe-Card.jpg", Sastojci = "Pileća krilca,sol,biber,češnjak", KategorijaId = 4 }
                );

            modelBuilder.Entity<Recept>().HasData(
            new Recept() { Id = 1,NazivJela = "Cowboy Burger", Opis = "Prethodno zagrijte roštilj na srednje jaku. Pržite slaninu u velikoj tavi na srednje jakoj vatri dok ne porumeni i postane hrskava. Ocijedite i sačuvajte kaplje. U velikoj zdjeli pomiješajte govedinu, češnjak, worchestershire umak, sol, papar i cheddar sir. Oblikujte 2 velike polpete i pecite na roštilju 4-5 minuta sa svake strane. Tijekom posljednjih nekoliko minuta dodajte još sira cheddar da se otopi. Stavite majonezu na obje strane split rolata i na donje rolice poslažite zelenu salatu, rajčicu, pljeskavicu, kolutiće luka i BBQ umak. Stavite rolat na vrh i poslužite!" }
            );


        }

    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestoranJelaRPA.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Create(Proizvod proizvod)
        {
            _appDbContext.Add(proizvod);
            _appDbContext.SaveChanges();
        }

        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }

        public void Delete(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Remove(kategorija);
            _appDbContext.SaveChanges();
        }

        public void Delete(Proizvod proizvod)
        {
            _appDbContext.Products.Remove(proizvod);
            _appDbContext.SaveChanges();
        }

        public Proizvod DohvatiProizvodSIdom(int id)
        {
            return _appDbContext.Products.Include(k => k.Kategorija).FirstOrDefault(f => f.Id == id);
        }

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorija.Find(id);
        }


        public IEnumerable<Proizvod> PopisProizvod()
        {
            return _appDbContext.Products.Include(k => k.Kategorija);
        }

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorija;
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Products.Include(k => k.Kategorija).Max(x => x.Id);
            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Proizvod proizvod)
        {
            _appDbContext.Products.Update(proizvod);
            _appDbContext.SaveChanges();
        }

        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Update(kategorija);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Recept> PopisRecepata()
        {
            return _appDbContext.Recepti;
        }

        public void Create(Recept recept)
        {
            _appDbContext.Add(recept);
            _appDbContext.SaveChanges();
        }

        public void Delete(Recept recept)
        {
            _appDbContext.Recepti.Remove(recept);
            _appDbContext.SaveChanges();
        }

        public void Update(Recept recept)
        {
            _appDbContext.Recepti.Update(recept);
            _appDbContext.SaveChanges();
        }

        public Recept DohvatiReceptSIdom(int id)
        {
            return _appDbContext.Recepti.Find(id);
        }
    }
}

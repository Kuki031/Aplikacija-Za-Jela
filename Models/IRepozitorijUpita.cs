namespace RestoranJelaRPA.Models
{
    public interface IRepozitorijUpita
    {
        
        IEnumerable<Proizvod> PopisProizvod(); 
        void Create(Proizvod proizvod); 
        void Delete(Proizvod proizvod); 
        void Update(Proizvod proizvod); 

        int SljedeciId();

        Proizvod DohvatiProizvodSIdom(int id);

        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);

        Kategorija DohvatiKategorijuSIdom(int id);


        
        IEnumerable<Recept> PopisRecepata();
        void Create(Recept recept);
        void Delete(Recept recept);
        void Update(Recept recept);

        Recept DohvatiReceptSIdom(int id);

    }
}

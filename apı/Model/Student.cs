namespace apı.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = "";
        public string Sinif { get; set; } = "";
        public int OgrenciNo { get; set; }
        public int OgrenciSiraNo { get; set; }
        public DateTime KayitTarihi { get; set; }

        public void Ekle()
        {



        }

    }

   
}

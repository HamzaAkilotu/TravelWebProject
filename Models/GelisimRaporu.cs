using System;

namespace AnaOkuluYS.Models
{
    public class GelisimRaporu
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public int OgretmenId { get; set; }
        public DateTime Tarih { get; set; }
        public string FizikselGelisim { get; set; }
        public string SosyalGelisim { get; set; }
        public string ZihinselGelisim { get; set; }
        public string DuygusalGelisim { get; set; }
        public string GenelDegerlendirme { get; set; }
        
        // İlişkiler
        public Ogrenci Ogrenci { get; set; }
        public Ogretmen Ogretmen { get; set; }
    }
} 
using System;
using System.Collections.Generic;

namespace AnaOkuluYS.Models
{
    public class Etkinlik
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public string Konum { get; set; }
        public int OgretmenId { get; set; }
        public bool Aktif { get; set; }
        
        // İlişkiler
        public Ogretmen Ogretmen { get; set; }
        public ICollection<EtkinlikKatilim> Katilimlar { get; set; }
    }
} 
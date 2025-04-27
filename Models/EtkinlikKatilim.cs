using System;

namespace AnaOkuluYS.Models
{
    public class EtkinlikKatilim
    {
        public int Id { get; set; }
        public int EtkinlikId { get; set; }
        public int OgrenciId { get; set; }
        public bool KatilimDurumu { get; set; }
        public string Notlar { get; set; }
        
        // İlişkiler
        public Etkinlik Etkinlik { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }
} 
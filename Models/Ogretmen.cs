using System;
using System.Collections.Generic;

namespace AnaOkuluYS.Models
{
    public class Ogretmen
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime IseBaslamaTarihi { get; set; }
        public string UzmanlikAlani { get; set; }
        public bool Aktif { get; set; }
        
        // İlişkiler
        public ICollection<GelisimRaporu> GelisimRaporlari { get; set; }
        public ICollection<Etkinlik> Etkinlikler { get; set; }
    }
} 
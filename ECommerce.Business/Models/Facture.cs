using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Business.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public Clients Client { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string FichierPDF { get; set; }
    }
}
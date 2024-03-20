using System;

namespace ProjetCSharp.Models
{
    public class NombreVentes
    {
        public int Id { get; set; }   
        public int Nbventes { get; set; }
        public int Annee { get; set; }
        public int? consId { get; set; }
        // public Consoles cons {  get; set; }

        public override string ToString()
        {
            String display = "";
            display += $"Console Id: {consId} \n " +
                $"Nombre de ventes : {Nbventes} \n" +
                $"Annee : {Annee}";
            return display;
        }
    }

}

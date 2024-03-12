using System;
namespace ProjetCSharp.Models
{
    public class Consoles
    {
        public int Id { get; set; } 
        public string Const { get; set; }
        public string Name { get; set; }

    public Consoles(int id,string Constr, string name) {
        this.Id = id;
        this.Const = Constr;
        this.Name = name;
    }


    }
}

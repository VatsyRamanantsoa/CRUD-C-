using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostC__CRUD.Models
{
    internal class Personne
    {

        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int age { get; set; }

        public string adresse { get; set; }

        public Personne() { }

        public Personne(int id, string nom, string prenom,int age, string adresse)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.adresse = adresse;
        }
    }
}

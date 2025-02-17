using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Caisse_Banque
{
    class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }

        public Utilisateur(string nom, string prenom, string login, string motDePasse)
        {
            Nom = nom;
            Prenom = prenom;
            Login = login;
            MotDePasse = motDePasse;
        }

    }
}

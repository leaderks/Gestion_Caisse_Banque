using Gestion_caisse_banque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Caisse_Banque
{
    public class Banque
    {
        public string Nom { get; set; }
        public decimal Solde { get; private set; }
        public List<Caisse> Caisses { get; private set; }

        public Banque(string nom)
        {
            Nom = nom;
            Solde = 0;
            Caisses = new List<Caisse>();
        }

        public void AjouterCaisse(string nom, decimal soldeInitial)
        {
            Caisse caisse = new Caisse(nom, soldeInitial);
            Caisses.Add(caisse);
        }

        public void ModifierCaisse(string nomActuel, string nouveauNom, decimal nouveauSolde)
        {
            Caisse caisseAModifier = Caisses.Find(c => c.Nom == nomActuel);
            if (caisseAModifier != null)
            {
                caisseAModifier.ModifierNom(nouveauNom);
                caisseAModifier.ModifierSolde(nouveauSolde);
            }
        }

        public void SupprimerCaisse(string nom)
        {
            Caisse caisseASupprimer = Caisses.Find(c => c.Nom == nom);
            if (caisseASupprimer != null)
            {
                Caisses.Remove(caisseASupprimer);
            }
        }

        public List<Caisse> GetCaisses()
        {
            return Caisses;
        }
    }
}

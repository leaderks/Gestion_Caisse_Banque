using Gestion_caisse_banque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Caisse_Banque
{
    public class GestionCaisse
    {
        private List<Caisse> caisses = new List<Caisse>();
        private List<Transaction> transactions = new List<Transaction>();

        public GestionCaisse()
        {
            caisses = new List<Caisse>();
        }

        public List<Caisse> GetCaisse()
        {
            return caisses;
        }
        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
        // Ajouter une caisse
        public void AjouterCaisse(string nom, decimal soldeInitial)
        {
            Caisse nouvelleCaisse = new Caisse(nom, soldeInitial);
            caisses.Add(nouvelleCaisse);
            Console.WriteLine($"Caisse {nom} ajoutée avec succès.");
        }

        // Modifier une caisse
        public void ModifierCaisse(string nomActuel, string nouveauNom, decimal nouveauSolde)
        {
            Caisse caisseAModifier = caisses.Find(c => c.Nom == nomActuel);
            if (caisseAModifier != null)
            {
                caisseAModifier.ModifierNom(nouveauNom);
                caisseAModifier.ModifierSolde(nouveauSolde);
                Console.WriteLine($"Caisse {nomActuel} modifiée avec succès.");
            }
            else
            {
                Console.WriteLine("Caisse non trouvée.");
            }
        }

        // Supprimer une caisse
        public void SupprimerCaisse(string nom)
        {
            Caisse caisseASupprimer = caisses.Find(c => c.Nom == nom);
            if (caisseASupprimer != null)
            {
                caisses.Remove(caisseASupprimer);
                Console.WriteLine($"Caisse {nom} supprimée avec succès.");
            }
            else
            {
                Console.WriteLine("Caisse non trouvée.");
            }
        }

        // Afficher toutes les caisses
        public void AfficherCaisse()
        {
            foreach (var caisse in caisses)
            {
                Console.WriteLine($"Caisse {caisse.Nom} - Solde : {caisse.Solde}");
            }
        }
    }
}

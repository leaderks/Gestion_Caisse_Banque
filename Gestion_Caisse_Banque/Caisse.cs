using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_caisse_banque
{
    public class Caisse
    {
        public string Nom { get; private set; }
        public decimal Solde { get; private set; }
        public List<Transaction> Transactions { get; set; }
        




        public void ModifierNom(string nouveauNom)
        {
            Nom = nouveauNom;
        }

        public void ModifierSolde(decimal nouveauSolde)
        {
            Solde = nouveauSolde;
        }
        public Caisse(string nom, decimal soldeInitial)
        {
            Nom = nom;
            Solde = soldeInitial;
            Transactions = new List<Transaction>();
        }
        public List<Transaction> GetTransactions()
        {
            return Transactions;
        }

        public void AjouterMontant(decimal montant)
        {
            Solde += montant;
        }

        public void RetirerMontant(decimal montant)
        {
            if (montant > Solde)
            {
                throw new InvalidOperationException("Le montant à retirer est supérieur au solde de la caisse.");
            }
            Solde -= montant;
        }
        // Ajouter une transaction en caisse
        public void AjouterTransaction(string description, decimal montant)
        {
            if (montant < 0)
            {
                throw new ArgumentException("Le montant ne peut pas être négatif.");
            }

            if (description == "entree")
            {
                Solde += montant;
                Transaction nouvelleTransaction = new Transaction(description, montant, TypeTransaction.Entree, this);
                Transactions.Add(nouvelleTransaction);
                Console.WriteLine($"Vous avez ajouté {montant} à la caisse {Nom}. Nouveau solde : {Solde}");
            }
            else if (description == "sortie")
            {
                if (montant <= Solde)
                {
                    Solde -= montant;
                    Transaction nouvelleTransaction = new Transaction(description, montant, TypeTransaction.Sortie, this);
                    Transactions.Add(nouvelleTransaction);
                    Console.WriteLine($"Vous avez retiré {montant} de la caisse {Nom}. Nouveau solde : {Solde}");
                }
                else
                {
                    Console.WriteLine("Solde insuffisant.");
                }
            }
        }

        // Solde de la caisse
        public void AfficherSoldeCaisse()
        {
            Console.WriteLine($"Caisse {Nom} - Solde : {Solde}");
        }

        // Annuler la dernière transaction d'une caisse
        public void AnnulerDerniereTransaction()
        {
            if (Transactions.Count > 0)
            {
                Transaction derniereTransaction = Transactions.Last();
                if (derniereTransaction.Annulation)
                {
                    throw new InvalidOperationException("La transaction est déjà annulée.");
                }

                if (derniereTransaction.Type == TypeTransaction.Entree)
                {
                    Solde -= derniereTransaction.Montant;
                }
                else
                {
                    Solde += derniereTransaction.Montant;
                }

                Transactions.RemoveAt(Transactions.Count - 1);
                Console.WriteLine($"Le solde est maintenant {Solde}.");
            }
        }
    }
}




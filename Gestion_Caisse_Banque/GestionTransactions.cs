using Gestion_caisse_banque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Caisse_Banque
{
    public class GestionTransactions
    {
        private List<Caisse> caisses = new List<Caisse>();
        private List<Transaction> transactions = new List<Transaction>();


        public List<Caisse> GetCaisse()
        {
            return caisses;
        }
        public List<Transaction> Transactions { get; set; }

        public GestionTransactions()
        {
            Transactions = new List<Transaction>();
        }
       

        // Enregistrer une nouvelle transaction
        public void EnregistrerTransaction(string description, decimal montant, TypeTransaction type, Caisse caisse)
        {
            if (Transactions.Any(t => t.Description == description && t.Montant == montant && t.Type == type && t.Caisse == caisse))
            {
                throw new InvalidOperationException("La transaction est déjà enregistrée.");
            }

            var transaction = new Transaction(description, montant, type, caisse);
            caisse.AjouterTransaction(description, montant);
            Transactions.Add(transaction);
            Console.WriteLine($"Transaction enregistrée : {transaction.Description} - {transaction.Montant} (Caisse : {caisse.Nom})");
            Console.WriteLine($"Solde final de la caisse {caisse.Nom} : {caisse.Solde}");
        }

        // Annuler une transaction
        public void AnnulerTransaction(int index)
        {
            if (index >= 0 && index < Transactions.Count && !Transactions[index].Annulation)
            {
                var transaction = Transactions[index];
                transaction.Cancel();
                transaction.Caisse.AnnulerDerniereTransaction();
                Console.WriteLine($"Transaction annulée : {transaction.Description}");
            }
            else
            {
                throw new InvalidOperationException("La transaction est déjà annulée ou n'existe pas.");
            }
        }

        // Afficher toutes les transactions
        public void AfficherTransactions()
        {
            Console.WriteLine("Liste des transactions :");
            foreach (var transaction in Transactions)
            {
                if (!transaction.Annulation)
                {
                    Console.WriteLine($"{transaction.Date}: {transaction.Description} - {transaction.Montant} (Caisse : {transaction.Caisse.Nom})");
                }
                else
                {
                    Console.WriteLine($"{transaction.Date}: [ANNULÉ] {transaction.Description}");
                }
            }
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_caisse_banque
{

    public enum TypeTransaction
    {
        Entree,
        Sortie
    }

    public class Transaction
    {
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public decimal Montant { get; private set; }
        public bool Annulation { get; private set; }
        public TypeTransaction Type { get; private set; }
        public Caisse Caisse { get; private set; }

        public Transaction(string description, decimal montant, TypeTransaction type, Caisse caisse)
        {
            Date = DateTime.Now;
            Description = description;
            Montant = montant;
            Annulation = false;
            Type = type;
            Caisse = caisse;
        }

        public void Cancel()
        {
            Annulation = true;
        }

        public decimal GetSoldeApresTransaction()
        {
            return Caisse.Solde + Montant;
        }

    }
}
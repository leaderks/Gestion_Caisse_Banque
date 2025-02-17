using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Caisse_Banque
{
    public class GestionBanques
    {
        private List<Banque> banques;

        public GestionBanques()
        {
            banques = new List<Banque>();
        }

        public void AjouterBanque(string nom)
        {
            Banque banque = new Banque(nom);
            banques.Add(banque);
        }

        public void ModifierBanque(string nomActuel, string nouveauNom)
        {
            Banque banqueAModifier = banques.Find(b => b.Nom == nomActuel);
            if (banqueAModifier != null)
            {
                banqueAModifier.Nom = nouveauNom;
            }
        }

        public void SupprimerBanque(string nom)
        {
            Banque banqueASupprimer = banques.Find(b => b.Nom == nom);
            if (banqueASupprimer != null)
            {
                banques.Remove(banqueASupprimer);
            }
        }

        public List<Banque> GetBanques()
        {
            return banques;
        }
    }
}

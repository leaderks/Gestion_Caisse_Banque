using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Caisse_Banque
{
    class Gestionutilisateurs
    {
        private List<Utilisateur> utilisateurs = new List<Utilisateur>();

        public void Ajouterutilisateur(Utilisateur utilisateur)
        {
            utilisateurs.Add(utilisateur);
        }

        public void Supprimerutilisateur(int idUtilisateur)
        {
            var utilisateur = utilisateurs.FirstOrDefault(u => u.Id == idUtilisateur);
            if (utilisateur != null)
            {
                utilisateurs.Remove(utilisateur);
            }
        }

        public Utilisateur AuthentifierUtilisateur(string login, string motDePasse)
        {
            var utilisateur = utilisateurs.FirstOrDefault(u => u.Login == login && u.MotDePasse == motDePasse);
            return utilisateur;
        }
        public void AfficherUtilisateurs()
        {
            foreach (var utilisateur in utilisateurs)
            {
                Console.WriteLine($"Nom : {utilisateur.Nom}, Prénom : {utilisateur.Prenom}, Login : {utilisateur.Login}");
            }
        }

        public Utilisateur GetUtilisateurByLogin(string login)
        {
            return utilisateurs.FirstOrDefault(u => u.Login == login);
        }
        public void ModifierUtilisateur()
        {
            Console.Write("Login de l'utilisateur à modifier : ");
            var login = Console.ReadLine();

            var utilisateur = GetUtilisateurByLogin(login);
            if (utilisateur != null)
            {
                Console.Write("Nouveau nom : ");
                var nom = Console.ReadLine();
                Console.Write("Nouveau prénom : ");
                var prenom = Console.ReadLine();
                Console.Write("Nouveau login : ");
                var nouveauLogin = Console.ReadLine();
                Console.Write("Nouveau mot de passe : ");
                var nouveauMotDePasse = Console.ReadLine();

                utilisateur.Nom = nom;
                utilisateur.Prenom = prenom;
                utilisateur.Login = nouveauLogin;
                utilisateur.MotDePasse = nouveauMotDePasse;
            }
            else
            {
                Console.WriteLine("Utilisateur non trouvé.");
            }
        }
    }
}

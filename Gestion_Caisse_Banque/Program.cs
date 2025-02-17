using Gestion_caisse_banque;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_Caisse_Banque
{
    class Program
    {
        static Gestionutilisateurs gestionUtilisateurs = new Gestionutilisateurs();
        static Utilisateur utilisateurConnecte = null;
        static GestionCaisse gestionCaisse = new GestionCaisse();
        static GestionTransactions gestionTransactions = new GestionTransactions();
        static GestionBanques gestionBanque = new GestionBanques();
        

        static List<Caisse> caisses = new List<Caisse>();

        static void Main(string[] args)
        {
            var utilisateur1 = new Utilisateur("k", "salomon", "ks", "ks");
            var utilisateur2 = new Utilisateur("Ariane", "Ariane", "Ariane", "Ariane");
            var utilisateur3 = new Utilisateur("Brynda", "Brynda", "Brynda", "Brynda");
            var utilisateur4 = new Utilisateur("Junior", "Junior", "Junior", "Junior");

            var utilisateur5 = new Utilisateur("loveline", "loveline", "loveline", "loveline");

            var utilisateur6 = new Utilisateur("Admin", "Admin", "Admin", "admin");
            gestionUtilisateurs.Ajouterutilisateur(utilisateur1);
            gestionUtilisateurs.Ajouterutilisateur(utilisateur2);
            gestionUtilisateurs.Ajouterutilisateur(utilisateur3);
            gestionUtilisateurs.Ajouterutilisateur(utilisateur4);
            gestionUtilisateurs.Ajouterutilisateur(utilisateur5);
            gestionUtilisateurs.Ajouterutilisateur(utilisateur6);

            while (true)
            {
                if (utilisateurConnecte == null)
                {
                    AfficherEcranConnexion();
                }
                else
                {
                    AfficherEcranPrincipal();
                }
            }
        }

        static void AfficherEcranConnexion()
        {
            Console.WriteLine("Application de gestion de caisse et de banque");
            Console.WriteLine("******************************************");
            Console.WriteLine("1 - Se connecter");
            Console.WriteLine("2 - Quitter");
            Console.Write("Quelle est votre choix? :");

            var choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    SeConnecter();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
            }
        }

        static void SeConnecter()
        {
            Console.Write("Login : ");
            var login = Console.ReadLine();
            Console.Write("Mot de passe : ");
            var motDePasse = ReadPassword();

            utilisateurConnecte = gestionUtilisateurs.AuthentifierUtilisateur(login, motDePasse);
            if (utilisateurConnecte == null)
            {
                Console.WriteLine("Login ou mot de passe incorrect.");
                utilisateurConnecte = null;
            }
        }

        static string ReadPassword()
        {
            string password = string.Empty;
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        Console.Write("\b \b"); // backspace
                        password = password.Substring(0, password.Length - 1);
                    }
                }
                else
                {
                    Console.Write("*");
                    password += cki.KeyChar;
                }
            }

            return password;
        }

        static void AfficherEcranPrincipal()
        {
            Console.WriteLine("Application de gestion de caisse et de banque");
            Console.WriteLine("******************************************");
            Console.WriteLine($"Bonjour, {utilisateurConnecte.Nom} {utilisateurConnecte.Prenom}");
            if (utilisateurConnecte.Login == "Admin")
            {
                Console.WriteLine("1 - Ajouter un utilisateur");
                Console.WriteLine("2 - Afficher la liste des utilisateurs");
                Console.WriteLine("3 - Supprimer un utilisateur");
            }
            Console.WriteLine("4 - Gestion de Banque");
            Console.WriteLine("5 - Se déconnecter");
            Console.WriteLine("6 - Quitter");
            Console.Write("Quelle est votre choix? :");

            var choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    if (utilisateurConnecte.Login == "Admin")
                    {
                        AjouterUtilisateur();
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas les droits pour effectuer cette opération.");
                    }
                    break;
                case "2":
                    if (utilisateurConnecte.Login == "Admin")
                    {
                        AfficherUtilisateurs();
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas les droits pour effectuer cette opération.");
                    }
                    break;
                case "3":
                    if (utilisateurConnecte.Login == "Admin")
                    {
                        SupprimerUtilisateur();
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas les droits pour effectuer cette opération.");
                    }
                    break;
                case "4":
                    GestionBanque();
                    break;
                case "5":
                    SeDeconnecter();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
            }
        }

        static void SupprimerUtilisateur()
        {
            Console.Write("Login de l'utilisateur à supprimer : ");
            var login = Console.ReadLine();

            var utilisateur = gestionUtilisateurs.GetUtilisateurByLogin(login);
            if (utilisateur != null)
            {
                gestionUtilisateurs.Supprimerutilisateur(utilisateur.Id);
                Console.WriteLine("Utilisateur supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Utilisateur non trouvé.");
            }
        }

        static void AjouterUtilisateur()
        {
            Console.WriteLine("Ajout d'un nouveau utilisateur");
            Console.Write("Nom : ");
            var nom = Console.ReadLine();
            Console.Write("Prénom : ");
            var prenom = Console.ReadLine();
            Console.Write("Login : ");
            var login = Console.ReadLine();
            Console.Write("Mot de passe : ");
            var motDePasse = ReadPassword();

            var nouvelUtilisateur = new Utilisateur(nom, prenom, login, motDePasse);
            gestionUtilisateurs.Ajouterutilisateur(nouvelUtilisateur);
        }

        static void AfficherUtilisateurs()
        {
            gestionUtilisateurs.AfficherUtilisateurs();
        }

        static void GestionBanque()
        {
            bool quitter = false;

            while (!quitter)
            {
                Console.WriteLine("Gestion de banque");
                Console.WriteLine("1 - Ajouter une banque");
                Console.WriteLine("2 - Modifier une banque");
                Console.WriteLine("3 - Supprimer une banque");
                Console.WriteLine("4 - Afficher toutes les banques");
                Console.WriteLine("5 - Gestion de caisse");
                Console.WriteLine("6 - Quitter");

                Console.Write("Quelle est votre choix? :");

                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.Write("Nom de la banque : ");
                        var nom = Console.ReadLine();
                        gestionBanque.AjouterBanque(nom);
                        // Ajouter la banque à la liste des banques
                        break;
                    case "2":
                        Console.Write("Nom actuel de la banque : ");
                        var nomActuel = Console.ReadLine();
                        Console.Write("Nouveau nom : ");
                        var nouveauNom = Console.ReadLine();
                        gestionBanque.ModifierBanque(nomActuel, nouveauNom);
                        break;
                    case "3":
                        Console.Write("Nom de la banque à supprimer : ");
                        var nomASupprimer = Console.ReadLine();
                        gestionBanque.SupprimerBanque(nomASupprimer);
                        break;
                    case "4":
                        var banques = gestionBanque.GetBanques();
                        foreach (var banque in banques)
                        {
                            Console.WriteLine(banque.Nom);
                        }
                        break;
                    case "5":
                        GestionCaisseDansBanque();
                        break;
                    case "6":
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
            }
        }

        static void GestionCaisseDansBanque()
        {
            bool quitter = false;
            var banques = gestionBanque.GetBanques(); // Assigner la valeur ici

            while (!quitter)
            {
                Console.WriteLine("Gestion de caisse dans la banque");
                Console.WriteLine("1 - Ajouter une caisse");
                Console.WriteLine("2 - Modifier une caisse");
                Console.WriteLine("3 - Supprimer une caisse");
                Console.WriteLine("4 - Afficher toutes les caisses");
                Console.WriteLine("5 - Enregistrer une transaction");
                Console.WriteLine("6 - Annuler une transaction");
                Console.WriteLine("7 - Afficher toutes les transactions");
                Console.WriteLine("8 - Quitter");

                Console.Write("Quelle est votre choix? :");

                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Sélectionnez une banque pour créer une caisse :");
                        for (int i = 0; i < banques.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {banques[i].Nom}");
                        }
                        Console.Write("Entrez le numéro de la banque : ");
                        int numeroBanque;
                        while (!int.TryParse(Console.ReadLine(), out numeroBanque) || numeroBanque < 1 || numeroBanque > banques.Count)
                        {
                            Console.Write("Numéro de banque invalide, veuillez réessayer : ");
                        }
                        Banque banqueSelectionnee = banques[numeroBanque - 1];
                        Console.Write("Nom de la caisse : ");
                        var nom = Console.ReadLine();
                        Console.Write("Solde initial : ");
                        decimal soldeInitial;
                        while (!decimal.TryParse(Console.ReadLine(), out soldeInitial))
                        {
                            Console.Write("Solde initial invalide, veuillez réessayer : ");
                        }
                        banqueSelectionnee.AjouterCaisse(nom, soldeInitial);
                        break;
                    case "2":
                        Console.Write("Nom actuel de la caisse : ");
                        var nomActuel = Console.ReadLine();
                        Console.Write("Nouveau nom : ");
                        var nouveauNom = Console.ReadLine();
                        Console.Write("Nouveau solde : ");
                        decimal nouveauSolde;
                        while (!decimal.TryParse(Console.ReadLine(), out nouveauSolde))
                        {
                            Console.Write("Nouveau solde invalide, veuillez réessayer : ");
                        }
                        foreach (var banque in banques)
                        {
                            banque.ModifierCaisse(nomActuel, nouveauNom, nouveauSolde);
                        }
                        break;
                    case "3":
                        Console.Write("Nom de la caisse à supprimer : ");
                        var nomASupprimer = Console.ReadLine();
                        foreach (var banque in banques)
                        {
                            banque.SupprimerCaisse(nomASupprimer);
                        }
                        break;
                    case "4":
                        foreach (var banque in banques)
                        {
                            Console.WriteLine($"Banque : {banque.Nom}");
                            foreach (var caisse in banque.GetCaisses())
                            {
                                Console.WriteLine($"  - {caisse.Nom} : {caisse.Solde}");
                            }
                        }
                        break;
                    case "5":
                        EnregistrerTransaction(banques, gestionTransactions);
                        break;
                    case "6":
                        AnnulerTransaction(banques, gestionTransactions);
                        break;
                    case "7":
                        AfficherTransactions(banques, gestionTransactions);
                        break;
                    case "8":
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
            }
        }

        static void AnnulerTransaction(List<Banque> banques, GestionTransactions gestionTransactions)
        {
            Console.WriteLine("Sélectionnez une banque pour annuler une transaction :");
            for (int i = 0; i < banques.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {banques[i].Nom}");
            }

            Console.Write("Entrez le numéro de la banque : ");
            int numeroBanque;
            while (!int.TryParse(Console.ReadLine(), out numeroBanque) || numeroBanque < 1 || numeroBanque > banques.Count)
            {
                Console.Write("Numéro de banque invalide, veuillez réessayer : ");
            }

            Banque banqueSelectionnee = banques[numeroBanque - 1];

            var caisses = banqueSelectionnee.GetCaisses();
            if (caisses == null || caisses.Count == 0)
            {
                Console.WriteLine("Aucune caisse créée dans cette banque. Veuillez créer une caisse avant d'annuler une transaction.");
                return;
            }

            Console.WriteLine("Choisissez une caisse pour annuler une transaction :");
            for (int i = 0; i < caisses.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {caisses[i].Nom}");
            }

            Console.Write("Entrez le numéro de la caisse : ");
            int choixCaisse;
            while (!int.TryParse(Console.ReadLine(), out choixCaisse) || choixCaisse < 1 || choixCaisse > caisses.Count)
            {
                Console.Write("Numéro de caisse invalide, veuillez réessayer : ");
            }

            Caisse caisse = caisses[choixCaisse - 1];

            var transactions = gestionTransactions.Transactions.Where(t => t.Caisse == caisse).ToList();
            if (transactions.Count == 0)
            {
                Console.WriteLine("Aucune transaction à annuler.");
                return;
            }

            Console.WriteLine("Sélectionnez une transaction à annuler :");
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {transactions[i].Description} - {transactions[i].Montant}");
            }

            Console.Write("Entrez le numéro de la transaction : ");
            int choixTransaction;
            while (!int.TryParse(Console.ReadLine(), out choixTransaction) || choixTransaction < 1 || choixTransaction > transactions.Count)
            {
                Console.Write("Numéro de transaction invalide, veuillez réessayer : ");
            }

            var transaction = transactions[choixTransaction - 1];
            gestionTransactions.AnnulerTransaction(gestionTransactions.Transactions.IndexOf(transaction));

            if (transaction.Type == TypeTransaction.Entree)
            {
                caisse.RetirerMontant(transaction.Montant);
            }
            else
            {
                caisse.AjouterMontant(transaction.Montant);
            }

            Console.WriteLine("Transaction annulée avec succès.");
            Console.WriteLine($"Solde final de la caisse {caisse.Nom} : {caisse.Solde}");
        }

        static void AfficherTransactions(List<Banque> banques, GestionTransactions gestionTransactions)
        {
            Console.WriteLine("Sélectionnez une banque pour afficher les transactions :");
            for (int i = 0; i < banques.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {banques[i].Nom}");
            }

            Console.Write("Entrez le numéro de la banque : ");
            int numeroBanque;
            while (!int.TryParse(Console.ReadLine(), out numeroBanque) || numeroBanque < 1 || numeroBanque > banques.Count)
            {
                Console.Write("Numéro de banque invalide, veuillez réessayer : ");
            }

            Banque banqueSelectionnee = banques[numeroBanque - 1];

            var caisses = banqueSelectionnee.GetCaisses();
            if (caisses == null || caisses.Count == 0)
            {
                Console.WriteLine("Aucune caisse créée dans cette banque. Veuillez créer une caisse avant d'afficher les transactions.");
                return;
            }

            Console.WriteLine("Choisissez une caisse pour afficher les transactions :");
            for (int i = 0; i < caisses.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {caisses[i].Nom}");
            }

            Console.Write("Entrez le numéro de la caisse : ");
            int choixCaisse;
            while (!int.TryParse(Console.ReadLine(), out choixCaisse) || choixCaisse < 1 || choixCaisse > caisses.Count)
            {
                Console.Write("Numéro de caisse invalide, veuillez réessayer : ");
            }

            Caisse caisse = caisses[choixCaisse - 1];

            var transactions = gestionTransactions.Transactions.Where(t => t.Caisse == caisse).ToList();

            if (transactions.Count == 0)
            {
                Console.WriteLine("Aucune transaction à afficher.");
                return;
            }

            Console.WriteLine("Liste des transactions de la caisse :");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Date : {transaction.Date}, Description : {transaction.Description}, Montant : {transaction.Montant}, Type : {transaction.Type}");
            }
        }
        static void EnregistrerTransaction(List<Banque> banques, GestionTransactions gestionTransactions)
        {
            Console.WriteLine("Sélectionnez une banque pour enregistrer une transaction :");
            for (int i = 0; i < banques.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {banques[i].Nom}");
            }

            Console.Write("Entrez le numéro de la banque : ");
            int numeroBanque;
            while (!int.TryParse(Console.ReadLine(), out numeroBanque) || numeroBanque < 1 || numeroBanque > banques.Count)
            {
                Console.Write("Numéro de banque invalide, veuillez réessayer : ");
            }

            Banque banqueSelectionnee = banques[numeroBanque - 1];

            var caisses = banqueSelectionnee.GetCaisses();
            if (caisses == null || caisses.Count == 0)
            {
                Console.WriteLine("Aucune caisse créée dans cette banque. Veuillez créer une caisse avant d'enregistrer une transaction.");
                return;
            }

            Console.WriteLine("Choisissez une caisse pour enregistrer une transaction :");
            for (int i = 0; i < caisses.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {caisses[i].Nom}");
            }

            Console.Write("Entrez le numéro de la caisse : ");
            int choixCaisse;
            while (!int.TryParse(Console.ReadLine(), out choixCaisse) || choixCaisse < 1 || choixCaisse > caisses.Count)
            {
                Console.Write("Numéro de caisse invalide, veuillez réessayer : ");
            }

            Caisse caisse = caisses[choixCaisse - 1];

            Console.Write("Description de la transaction : ");
            var description = Console.ReadLine();
            Console.Write("Montant de la transaction : ");
            decimal montant;
            while (!decimal.TryParse(Console.ReadLine(), out montant))
            {
                Console.Write("Montant invalide, veuillez réessayer : ");
            }
            Console.Write("Type de transaction (1 pour Entree, 2 pour Sortie) : ");
            var typeTransaction = Console.ReadLine() == "1" ? TypeTransaction.Entree : TypeTransaction.Sortie;

            gestionTransactions.EnregistrerTransaction(description, montant, typeTransaction, caisse);

            if (typeTransaction == TypeTransaction.Entree)
            {
                caisse.AjouterMontant(montant);
            }
            else
            {
                caisse.RetirerMontant(montant);
            }

            Console.WriteLine("Transaction enregistrée avec succès.");
            Console.WriteLine($"Solde final de la caisse {caisse.Nom} : {caisse.Solde}");
        }
        static void SeDeconnecter()
        {
            utilisateurConnecte = null;
        }
    }
}
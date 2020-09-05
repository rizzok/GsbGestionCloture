using System;
using Topshelf;

namespace GsbGestionClotureService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciation permettant la création d'un service Windows
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<GestionCloture>(s =>
                {
                    // Instanciation d'un objet de la classe GestionCloture
                    s.ConstructUsing(gestionCloture => new GestionCloture());
                    // Appelle la méthode Start de l'objet gestionCloture quand le service démarre
                    s.WhenStarted(gestionCloture => gestionCloture.Start());
                    // Appelle la méthode Stop de l'objet gestionCloture quand le service est arrêté
                    s.WhenStopped(gestionCloture => gestionCloture.Stop());
                });
                // Exécute le service en tant qu'utilisateur local du système
                x.RunAsLocalSystem();
                // Définition des paramètre du service
                x.SetServiceName("GsbGestionClotureService");
                x.SetDisplayName("Gsb gestion de la clôture");
                x.SetDescription("Met à jour les états des fiches de frais en fonction de la date.");
            });
            // Converti un enum en int
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());

            Environment.ExitCode = exitCodeValue;
        }
    }
}

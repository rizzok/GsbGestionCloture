using System.Timers;

namespace GsbGestionClotureService
{
    /// <summary>
    /// Implémente un objet de type Timer permettant de lancer les requêtes SQL mettan à jour la base de données
    /// Sert d'intermédiaire entre les classes d'accès aux données (DataAccess) / de gestion des dates (DateGestion) 
    /// et le Main (fonction principale du programme)
    /// </summary>
    public class GestionCloture
    {
        private readonly Timer _timer;

        /// <summary>
        /// Constructeur
        /// Lance la méthode TimerElapsed à chaque fois que le nombre de milisecondes 
        /// défini à l'instanciation de l'objet Timer est atteint, ici toutes les heures
        /// </summary>
        public GestionCloture()
        {
            _timer = new Timer(3600000){ AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        /// <summary>
        /// Se connecte à la base de données et envoie une requête SQL si une condition est respectée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Connexion à la base de données
            DataAccess dataAccess = new DataAccess("gsb_frais", "localhost", "root", "");

            // Si le jour actuel se situe entre le 1ier et le 10ième jour du mois, 
            // change l'état des fiches du mois précédent à clôturé
            if (DateGestion.entre(1, 10))
            {
                // Met à jour l'état des fiches du mois précédent à 'CL' = clôturée
                dataAccess.requestAdmin(
                    "UPDATE fichefrais " +
                    "SET idetat = 'CL' " +
                    "WHERE idetat = 'CR' " +
                    "AND mois = " + DateGestion.getAnneeEtMoisPrecedent()
                    );
            }
            // Si le jour actuel se situe entre le 20ième et le dernier jour du mois, 
            // change l'état des fiches du mois précédent à remboursé
            else if (DateGestion.entre(20, 31))
            {
                // Met à jour l'état des fiches du mois précédent à 'RB' = remboursée
                dataAccess.requestAdmin(
                    "UPDATE fichefrais " +
                    "SET idetat = 'RB' " +
                    "WHERE idetat = 'VA' " +
                    "AND mois = " + DateGestion.getAnneeEtMoisPrecedent()
                    );
            }
        }

        /// <summary>
        /// Lance le Timer
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        /// Arrête le Timer
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }
    }
}

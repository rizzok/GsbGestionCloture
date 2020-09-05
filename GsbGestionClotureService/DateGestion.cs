using System;

namespace GsbGestionClotureService
{
    /// <summary>
    /// Classe abstraite comportant de méthodes statiques utiles à la gestion des fiches de frais
    /// </summary>
    public abstract class DateGestion
    {
        /// <summary>
        /// Calcule la date par rapport à l'objet DateTime et le nombre passés en paramètre
        /// Puis formate sous la forme "MM"
        /// </summary>
        /// <param name="dateTime">Objet de type DateTime</param>
        /// <param name="number">Nombre entier</param>
        /// <returns>Une chaîne de caractères représentant un mois sous la forme "MM"</returns>
        private static string calculDate(DateTime dateTime, int number)
        {
            dateTime = dateTime.AddMonths(number);
            string month = dateTime.ToString("MM");
            return month;
        }

        /// <summary>
        /// Permet d'obtenir le mois précédent par rapport à aujourd'hui
        /// </summary>
        /// <returns>Chaîne de caractères contenant le mois précédent au format "MM"</returns>
        public static string getMoisPrecedent()
        {
            return getMoisPrecedent(DateTime.Today);
        }

        /// <summary>
        /// Permet d'obtenir le mois précédent par rapport à la date passée en paramètre
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>Chaîne de caractères contenant le mois précédent au format "MM"</returns>
        public static string getMoisPrecedent(DateTime dateTime)
        {
            return calculDate(dateTime, -1);
        }

        /// <summary>
        /// Permet d'obtenir le mois suivant par rapport à aujourd'hui
        /// </summary>
        /// <returns>Chaîne de caractères contenant le mois suivant au format "MM"</returns>
        public static string getMoisSuivant()
        {
            return getMoisSuivant(DateTime.Today);
        }

        /// <summary>
        /// Permet d'obtenir le mois suivant par rapport à la date passée en paramètre
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>Chaîne de caractères contenant le mois suivant au format "MM"</returns>
        public static string getMoisSuivant(DateTime dateTime)
        {
            return calculDate(dateTime, 1);
        }

        /// <summary>
        /// Reçoit 2 numéros de jour dans le mois
        /// Retourne vrai si la date actuelle se situe entre ces 2 jours
        /// </summary>
        /// <param name="day1">Premier entier correspondant à un jour dans le mois</param>
        /// <param name="day2">Second entier correspondant à un jour dans le mois</param>
        /// <returns>Vrai si la date actuelle est entre les 2 jours, sinon retour faux</returns>
        public static bool entre(int day1, int day2)
        {
            return entre(day1, day2, DateTime.Today);
        }

        /// <summary>
        /// Reçoit 2 numéros de jour dans le mois
        /// Retourne vrai si la date actuelle se situe entre ces 2 jours
        /// </summary>
        /// <param name="day1">Premier entier correspondant à un jour dans le mois</param>
        /// <param name="day2">Second entier correspondant à un jour dans le mois</param>
        /// <param name="dateTime">Date à vérifier</param>
        /// <returns>Vrai si la date actuelle est entre les 2 jours, sinon retour faux</returns>
        public static bool entre(int day1, int day2, DateTime dateTime)
        {
            int day = dateTime.Day;
            return (day >= day1 && day <= day2);
        }

        /// <summary>
        /// Permet de récupérer une date, d'y soustraire un mois
        /// Et de retourner l'année sous la forme "yyyy"
        /// </summary>
        /// <param name="dateTime">Une date</param>
        /// <returns>Année sous la forme "yyyy"</returns>
        public static string getAnneeDuMoisPrecedent(DateTime dateTime)
        {
            dateTime = dateTime.AddMonths(-1);
            return dateTime.ToString("yyyy");
        }

        /// <summary>
        /// Récupère le mois précédent et l'année associée sous la forme "yyyyMM"
        /// </summary>
        /// <returns>mois précédent et l'année associée sous la forme "yyyyMM"</returns>
        public static string getAnneeEtMoisPrecedent()
        {
            return getAnneeDuMoisPrecedent(DateTime.Today) + getMoisPrecedent();
        }

        /// <summary>
        /// Récupère le mois précédent et l'année associée sous la forme "yyyyMM"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>mois précédent et l'année associée sous la forme "yyyyMM"</returns>
        public static string getAnneeEtMoisPrecedent(DateTime dateTime)
        {
            return getAnneeDuMoisPrecedent(dateTime) + getMoisPrecedent(dateTime);
        }

    }
}

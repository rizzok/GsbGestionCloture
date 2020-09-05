using MySql.Data.MySqlClient;

namespace GsbGestionClotureService
{
    /// <summary>
    /// Accès aux données
    /// Connexion à la base MySQL, exécution de requêtes, gestion du curseur
    /// </summary>
    public class DataAccess
    {
        private MySqlConnection dbConnection; // Connexion à la base de données

        /// <summary>
        /// Constructeur
        /// Initialise la connexion à la base de données
        /// </summary>
        /// <param name="database">Nom de la base de données</param>
        /// <param name="server">Nom du serveur</param>
        /// <param name="userid">Identifiant de l'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        public DataAccess(string database, string server, string userid, string password)
        {
            this.dbConnection = new MySqlConnection(
                "database=" + database + "; " +
                "server=" + server + "; " +
                "userid=" + userid + "; " +
                "password=" + password
                );
        }

        /// <summary>
        /// Execution d'une requête de type INSERT, UPDATE ou DELETE
        /// </summary>
        /// <param name="request">Requête SQL</param>
        public void requestAdmin(string request)
        {
            this.dbConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(request, this.dbConnection);
            mySqlCommand.ExecuteNonQuery();
            this.dbConnection.Close();
        }

        /// <summary>
        /// Execution d'une requête d'interrogation de données
        /// </summary>
        /// <param name="request">Requête SQL</param>
        /// <returns>MySqlDataReader</returns>
        public MySqlDataReader requestSelect(string request)
        {
            this.dbConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(request, this.dbConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            mySqlDataReader.Close();
            this.dbConnection.Close();
            return mySqlDataReader;
        }

    }
}

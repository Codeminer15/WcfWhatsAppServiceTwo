using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Data;

namespace WcfTwoService
{
    public static class WhatsAppConfig
    {
        // Variables para controlar la inicialización y manejo de errores
        private static bool _initialized = false;
        private static Exception _lastError = null;

        //Variable para el manejo de tiempo
        private static DateTime _lastRefreshTime = DateTime.MinValue;

        // Propiedades de configuración obtenidas desde la base de datos
        public static string AccessToken { get; private set; }
        public static string Version { get; private set; }
        public static string PhoneNumberId { get; private set; }
        public static string ApiUrl { get; private set; }

        /// Cadena de conexión centralizada. Se obtiene del archivo de configuración (Web.config),
        /// y si no está definida, se usa un valor por defecto.8
        public static string ConnectionString
        {
            get
            {
                // Consulta en Web.config
                var configValue = ConfigurationManager.ConnectionStrings["WhatsAppDB"]?.ConnectionString;

                if (string.IsNullOrEmpty(configValue))
                {
                    throw new ApplicationException("La cadena de conexión no está configurada en Web.config.");
                }
                return configValue;
                // Si no existe en config, usa el valor por defecto para pruebas locales
                //return string.IsNullOrEmpty(configValue) ?
                //    "Data Source=DESKTOP-JMH\\SQLEXPRESS;Initial Catalog=ApiWhatsAppConfig;User ID=AppWhatsAppUser;Password=$v3n0@H3R!2025;" :
                //    configValue;
            }
        }
        /// Constructor estático para inicializar la configuración al cargar la clase.
        static WhatsAppConfig()
        {
            try
            {
                InitializeConfig();  // Carga los parámetros desde la base de datos
                _initialized = true; //Marcador
            }
            catch (Exception ex)
            {
                _lastError = ex;
                throw new ApplicationException("Error inicializando WhatsAppConfig. Ver inner exception para detalles.", ex);
            }
        }
        /// Carga la configuración de la base de datos y almacena los valores en las variables estáticas.
        private static void InitializeConfig()
        {// Verifica que la conexión con la base de datos esté disponible antes de continuar
            if (!TestConnection(ConnectionString))
            {
                throw new ApplicationException("No se pudo establecer conexión con la base de datos");
            }
            //Verificar la existencia de la tabla
            if (!TableExists("UrlConfig"))
            {
                throw new ApplicationException("La tabla 'UrlConfig' no existe en la base de datos.");
            }

            // Consulta SQL para obtener la configuración más reciente desde la tabla UrlConfig
            string query = @"SELECT TOP 1
                           UserAccessToken,
                           Version,
                           PhoneNumberId,
                           ApiUrl
                           FROM UrlConfig
                           ORDER BY LastUpdate DESC";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    { // Asignar los valores obtenidos de la base de datos a las variables estáticas
                        AccessToken = reader["UserAccessToken"] as string ?? string.Empty;
                        Version = reader["Version"] as string ?? string.Empty;
                        PhoneNumberId = reader["PhoneNumberId"] as string ?? string.Empty;
                        ApiUrl = reader["ApiUrl"] as string ?? ApiUrl; // Usa el valor por defecto si es null
                    }
                    else
                    {
                        throw new ApplicationException("No se encontraron registros en la tabla UrlConfig");
                    }
                }
            }
        }
        /// Verifica si se puede establecer una conexión con la base de datos
        private static bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection testConn = new SqlConnection(connectionString))
                {
                    testConn.Open();
                    return (testConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException ex)
            {
                LogError("Error de conexión SQL", ex);
                return false;
            }
        }
        /// Verificar antes la existencia de la base de datos
        private static bool TableExists(string tableName)
        {
            string query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private static void LogError(string message, Exception ex)
        {
            try
            {
                EventLog.WriteEntry("WcfTwoService", $"{message}: {ex.Message}", EventLogEntryType.Error);
            }
            catch
            {
                // Si no se puede escribir en el Event Log, no hagas nada para evitar más errores.
            }
        }
        /// Verifica si la configuración ha sido correctamente inicializada antes de su uso.
        /// Mejora el rendimiento al evitar múltiples consultas, pero mantiene los datos actualizados.
        public static void EnsureInitialized()
        { //Actualizar en intervalos de un minuto
            TimeSpan refreshInterval = TimeSpan.FromMinutes(1);

            if (!_initialized || (DateTime.Now - _lastRefreshTime) > refreshInterval)
            {
                try
                {
                    InitializeConfig();
                    _lastRefreshTime = DateTime.Now;
                    _initialized = true;
                    _lastError = null; // Limpia error anterior si todo salió bien
                }
                catch(Exception ex)
                {
                    _initialized = false;
                    _lastError = ex;
                    throw new ApplicationException("Error al refrescar la configuración", ex);
                }
            }
            // Si aún no está inicializado luego de intentar, lanza el error
            if (!_initialized && _lastError != null)
            {
                throw new ApplicationException("WhatsAppConfig no se inicializó correctamente", _lastError);
            }
        }
    }
}
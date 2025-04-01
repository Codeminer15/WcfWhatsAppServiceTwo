using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using System.Data;

namespace WcfTwoService
{
    public static class WhatsAppConfig
    {
        private readonly static bool _initialized = false;
        private readonly static Exception _lastError = null;

        public static string AccessToken { get; private set; }
        public static string Version { get; private set; }
        public static string PhoneNumberId { get; private set; }
        public static string ApiUrl { get; private set; }

        // Cadena de conexión centralizada (puede venir de Web.config)
        public static string ConnectionString
        {
            get
            {
                // Primero intenta obtenerla del Web.config
                var configValue = ConfigurationManager.ConnectionStrings["WhatsAppDB"]?.ConnectionString;

                // Si no existe en config, usa el valor por defecto
                return string.IsNullOrEmpty(configValue) ?
                    "Data Source=DESKTOP-JMH\\SQLEXPRESS;Initial Catalog=ApiWhatsAppConfig;User ID=AppWhatsAppUser;Password=$v3n0@H3R!2025;" :
                    configValue;
            }
        }

        static WhatsAppConfig()
        {
            try
            {
                InitializeConfig();
                _initialized = true;
            }
            catch (Exception ex)
            {
                _lastError = ex;
                throw new ApplicationException("Error inicializando WhatsAppConfig. Ver inner exception para detalles.", ex);
            }
        }

        private static void InitializeConfig()
        {
            if (!TestConnection(ConnectionString))
            {
                throw new ApplicationException("No se pudo establecer conexión con la base de datos");
            }

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
                    {
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
            catch
            {
                return false;
            }
        }

        public static void EnsureInitialized()
        {
            if (!_initialized)
            {
                throw new ApplicationException("WhatsAppConfig no se inicializó correctamente", _lastError);
            }
        }
    }
}
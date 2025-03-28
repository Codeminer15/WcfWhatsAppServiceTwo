Imports System.Data.Sql
Imports System.Data.SqlClient

Module ConnectionDB
    Public Function GetConnection() As SqlConnection
        Dim ConnectionString As String = "Data Source=DESKTOP-JMH\SQLEXPRESS;Initial Catalog=ApiWhatsAppConfig;Integrated Security=True;"
        Return New SqlConnection(ConnectionString)
    End Function
End Module

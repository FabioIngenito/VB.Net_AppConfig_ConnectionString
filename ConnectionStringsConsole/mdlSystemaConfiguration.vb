'PEGUEI ESTE EXEMPLO EM:
'I GOT THIS EXAMPLE IN:
'http://msdn.microsoft.com/pt-br/library/system.configuration.configurationmanager.connectionstrings.aspx
'https://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.connectionstrings.aspx
'... mas alterei um pouco...
'... but I changed a little ...

'NOTA: É preciso que o "app.config" esteja INCLUÍDO no projeto. Para saber isto, basta ver se o ícone aparece como um folha branca ou 
'      se está colorido (com linhas e uma bolinha parecendo um planetinha Terra).
'NOTE: The "app.config" must be INCLUDED in the project. To know this, just see if the icon appears as a white sheet or 
'      if it Is colored (with lines And a ball looking Like a planet Earth).

Imports System.Configuration

Module mdlSystemaConfiguration

    Sub Main()
        ReadConnectionStrings()
        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Pega a seção ConnectionStrings.
    ''' Get the ConnectionStrings section.
    ''' Esta função utiliza os ConnectionStrings.
    ''' This function uses ConnectionStrings.
    ''' Propriedade para ler os connectionStrings.
    ''' Property to read the connectionStrings.
    ''' Seção de configuração.
    ''' Configuration section.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReadConnectionStrings()

        ' Pega a seção ConnectionStrings.
        ' Get the ConnectionStrings section.
        Dim connections As ConnectionStringSettingsCollection = ConfigurationManager.ConnectionStrings
        ' Mostrando somente UMA conexão ("Desenvolvimento")
        ' Showing only ONE connection ("Development")
        Dim connections1 As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Desenvolvimento")
        ' -> Depois experimente colocar um nome ERRADO de propósito:
        ' -> Then try putting a Wrong Name on purpose:
        'Dim connections1 As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Desenvolvimento1")

        If Not IsNothing(connections1) Then
            Console.WriteLine()
            Console.WriteLine("SOMENTE UMA CONEXÃO - ONLY ONE CONNECTION: ")
            Console.WriteLine("Nome - Name:       {0}", connections1.Name)
            Console.WriteLine("String de Conexão: {0}", connections1.ConnectionString)
            Console.WriteLine("Provider Name:     {0}", connections1.ProviderName)
            Console.WriteLine()
            Console.WriteLine("---------------------------------------")
        End If

        If connections.Count <> 0 Then
            Console.WriteLine()
            Console.WriteLine("Using the ConnectionStrings Property.")
            Console.WriteLine("Strings de conexão - Connection Strings:")
            Console.WriteLine()

            ' Pega os elementos da coleção.
            For Each connection As ConnectionStringSettings In connections
                Dim name As String = connection.Name
                Dim provider As String = connection.ProviderName
                Dim connectionString As String = connection.ConnectionString

                Console.WriteLine("Nome - Name:         {0}", name)
                Console.WriteLine("Connection String:   {0}", connectionString)
                Console.WriteLine("Provedor - Provider: {0}", provider)
                Console.WriteLine()
            Next
        Else
            Console.WriteLine()
            Console.WriteLine("Nenhuma sequência de conexão está definida. - No connection string is defined.")
            Console.WriteLine()
        End If

    End Sub

End Module
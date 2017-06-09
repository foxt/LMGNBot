Imports Discord
Imports Discord.Commands
Imports System.Reflection
Imports Discord.WebSocket
Imports System.Web
Imports Newtonsoft.Json
Imports Discord.Addons.Paginator
Imports System.Collections.ObjectModel

Module Module1

    Sub Main()

        Dim main = New Task(AddressOf Start)
        For Each a As Assembly In AppDomain.CurrentDomain.GetAssemblies

            Console.WriteLine(a.CodeBase)


        Next
        main.Start()
        main.Wait()
        While True
            Threading.Thread.Sleep(50000)

        End While

    End Sub

    Private WithEvents client As DiscordSocketClient

    Async Function createClient(token, name) As Task
        Await Log(New LogMessage(LogSeverity.Info, "Client", "Connecting client for " & name))
        ' Create a new DiscordSocketClient
        client = New DiscordSocketClient(New DiscordSocketConfig())
        ' Define the token the bot will use to connect with
        Await client.LoginAsync(TokenType.Bot, token) '" & name & "
        Await client.StartAsync
        ' Create the commands handler
        Dim commands = New CommandHandler()
        commands.Install(client, name)
    End Function

    Async Sub Start()
        Await createClient("MjgyMDkwMzMwOTU2ODkwMTEy.C4hcmw.yH8rtUpd-qNH7whJvc5wjIxr0Kw", "LMGNBot")
        Await createClient("MzE0NDM1MTU3ODk1Njc1OTA1.C_4IEg.5ksiCSMX_R9d3g9wTkB06qDXI0Q", "WarriorBot")
        ' Block this method until the application is terminated
        Await Task.Delay(-1)
    End Sub

    Function Log(ByVal message As LogMessage) As Task Handles client.Log
        Console.WriteLine(message.ToString())
        Return Task.CompletedTask
    End Function

End Module

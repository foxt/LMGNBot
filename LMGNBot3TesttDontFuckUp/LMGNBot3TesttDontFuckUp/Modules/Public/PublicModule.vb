Imports System.ComponentModel
Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket

Public Class PublicModule
    Inherits ModuleBase
    Private _client As DiscordSocketClient

    Public Sub New(ByVal client As DiscordSocketClient)

        _client = client
        Log(New LogMessage(LogSeverity.Info, "CommandModule", "PublicModule's new thingy ran"))
    End Sub

    <Command("join")>
    <Description("Returns the Invite URL of the bot.")>
    Async Public Sub Join()
        Dim application = Await _client.GetApplicationInfoAsync()
        Await Context.Channel.SendMessageAsync($"A user with `MANAGE SERVER` can invite me to your server here: <https://discordapp.com/oauth2/authorize?client_id={application.Id}&scope=bot>")
    End Sub

    ' TODO: This module could use some more examples.

    <Command("test")>
    <Description("Test command to debug the bot")>
    Async Public Sub test()
        Await Context.Channel.SendMessageAsync($":smile_cat:    Working!")
    End Sub

    Function Log(ByVal message As LogMessage) As Task
        Console.WriteLine(message.ToString())
        Return Task.CompletedTask
    End Function


End Class
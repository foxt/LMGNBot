Imports System.Collections.ObjectModel
Imports System.Reflection
Imports System.Web
Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket
Imports Newtonsoft.Json

Public Class CommandHandler

#Region "EmbedManager"
    Public Class paginatedMessage
            Public ID As Integer
            Public embeds As List(Of Embed)
            Public message As IUserMessage
            Public currentPage As Integer
        End Class
        Dim paginatedMessages As New List(Of paginatedMessage)
        Public Async Function sendMessage(embeds As List(Of Embed), originalMessage As IUserMessage) As Task
            Dim pm = Await originalMessage.Channel.SendMessageAsync(originalMessage.Author.Mention & " 1 " & "/ " & embeds.Count & " PMID: " & paginatedMessages.Count, False, embeds.First)
            paginatedMessages.Add(New paginatedMessage With {
                              .ID = paginatedMessages.Count,
                              .embeds = embeds,
                              .message = pm,
                              .currentPage = 1})
            Await pm.AddReactionAsync(New Emoji("🇽"))
            If embeds.Count > 1 Then
                Await pm.AddReactionAsync(New Emoji("➡"))
            End If
        End Function
    Async Function handleReaction(a As Object, channel As ISocketMessageChannel, reaction As SocketReaction) As Task Handles client.ReactionAdded
        Await Log(New LogMessage(LogSeverity.Verbose, "Paginator", "New reaction " & reaction.Emote.Name & " from " & reaction.User.GetValueOrDefault.Username & " in " & reaction.Channel.Name & ". "))

        If reaction.Message.GetValueOrDefault.Author.Id = client.CurrentUser.Id Then
            'If reaction.Message.GetValueOrDefault.MentionedUsers.Contains(reaction.Message.GetValueOrDefault.Author) Then
            If reaction.Emote.Name = "🇽" Then
                If reaction.Message.GetValueOrDefault.Embeds.FirstOrDefault.Footer.GetValueOrDefault.Text.Contains("PMID: ") Then
                    paginatedMessages.RemoveAt(reaction.Message.Value.Content.Split(" ").Last)
                End If
                Await reaction.Message.Value.DeleteAsync()
            Else
                If reaction.Message.GetValueOrDefault.Embeds.FirstOrDefault.Footer.GetValueOrDefault.Text.Contains("PMID: ") Then
                    If reaction.Emote.Name = "➡" Then
                        For Each pm As paginatedMessage In paginatedMessages
                            If pm.ID = reaction.Message.Value.Content.Split(" ").Last Then


                                pm.currentPage = pm.currentPage + 1
                                Await pm.message.ModifyAsync(Function(x)
                                                                 x.Content = reaction.Message.GetValueOrDefault.MentionedUsers.First.Mention & " " & pm.currentPage & " " & "/ " & pm.embeds.Count & " PMID: " & pm.ID
                                                                 x.Embed = pm.embeds.Item(pm.currentPage - 1)

                                                             End Function)
                                Await pm.message.RemoveAllReactionsAsync()
                                If pm.embeds.Count > 1 And pm.currentPage < pm.embeds.Count Then
                                    Await pm.message.AddReactionAsync(New Emoji("➡"))
                                End If
                                If pm.embeds.Count > 1 And pm.currentPage > 1 Then
                                    Await pm.message.AddReactionAsync(New Emoji("⬅"))
                                End If
                            End If
                        Next
                    ElseIf reaction.Emote.Name = "⬅" Then
                        For Each pm As paginatedMessage In paginatedMessages
                            If pm.ID = reaction.Message.Value.Content.Split(" ").Last Then


                                pm.currentPage = pm.currentPage - 1
                                Await pm.message.ModifyAsync(Function(x)
                                                                 x.Content = reaction.Message.GetValueOrDefault.MentionedUsers.First.Mention & " " & pm.currentPage & " " & "/ " & pm.embeds.Count & " PMID: " & pm.ID
                                                                 x.Embed = pm.embeds.Item(pm.currentPage - 1)

                                                             End Function)
                                Await pm.message.RemoveAllReactionsAsync()
                                If pm.embeds.Count > 1 And pm.currentPage < pm.embeds.Count Then
                                    Await pm.message.AddReactionAsync(New Emoji("➡"))
                                End If
                                If pm.embeds.Count > 1 And pm.currentPage > 1 Then
                                    Await pm.message.AddReactionAsync(New Emoji("⬅"))
                                End If
                            End If
                        Next
                    End If
                End If
            End If
            'End If
        Else
            Await Log(New LogMessage(LogSeverity.Verbose, "Paginator", "New reaction " & reaction.Emote.Name & " from " & reaction.User.GetValueOrDefault.Username & " in " & reaction.Channel.Name & ". Not the bot's message so I'm ignoring it."))
        End If
    End Function

#End Region

    Interface ICollection(Of T)
            Inherits IEnumerable(Of T)
            Inherits IEnumerable
            ReadOnly Property Count() As Integer
            ReadOnly Property IsReadOnly() As Boolean

            Sub Add(item As T)
            Sub Clear()
            Function Contains(item As T) As Boolean
            Sub CopyTo(array As T(), arrayIndex As Integer)
            Function Remove(item As T) As Boolean
        End Interface

        Private WithEvents client As DiscordSocketClient

        ' Write log messages to console
        Function Log(ByVal message As LogMessage) As Task Handles client.Log
            Console.WriteLine(New LogMessage(message.Severity, name, message.Message))
            Return Task.CompletedTask
        End Function

        Private commands As CommandService
        Private self As ISelfUser
        Dim uptime As DateTime
        Dim name As String

        Async Sub Install(ByVal c As DiscordSocketClient, ByVal namee As String)
            client = c
            name = namee
            ' Create the Command Service
            commands = New CommandService()
            ' Retrieve the Bot User for later use
            self = client.CurrentUser()
            Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loaded Successfully"))
            uptime = DateTime.Now
        End Sub
        Dim botstionBlue = New Color(Convert.ToByte(69), Convert.ToByte(255), Convert.ToByte(254))

        Async Function hC(ByVal msg As IUserMessage) As Task Handles client.MessageReceived
            If msg.Content.StartsWith("b!") Then
                If msg.Content.StartsWith("b!testpaginator") Then
                    Dim pages As New List(Of Embed)
                    Dim testembed As New EmbedBuilder With {.Author = New EmbedAuthorBuilder With {.Name = "Test Embed"}, .Color = botstionBlue, .Description = "This is a test embed description", .Footer = New EmbedFooterBuilder With {.Text = "Test embed footer"}, .Title = "Test embed title", .Url = "https://github.com/thelmgn/botstion"}
                    pages.Add(testembed)
                    pages.Add(testembed)
                    pages.Add(testembed)
                    pages.Add(testembed)
                    sendMessage(pages, msg)
                End If
            End If
        End Function

        Function getEmbed()

        End Function
        Async Function newServer(ByVal guild As SocketGuild) As Task Handles client.JoinedGuild
            Await TryCast(client.GetChannel(295552185826279424), IMessageChannel).SendMessageAsync("I just joined " & guild.Name)
            If client.Guilds.Count > 90 Then
                Await guild.DefaultChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "WOAH WE'VE HIT A LIMIT OF 90 GUILDS, I'M OUT. :door:", "Guild limit!", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Critical error!"))
                Await guild.LeaveAsync
                Await TryCast(client.GetChannel(295552185826279424), IMessageChannel).SendMessageAsync("I just left " & guild.Name & " reason: ERR_GUILD_LIMIT")
            Else
                Await guild.DefaultChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/5999436f48c8f7835827894e40c1abc3%5B1%5D%20%281%29.png", "**Hello!**/n/nI'm " & name & "! A simple bot made in Discord.NET. I can help you with moderation, having fun, searching the web, etc/nType `lb.help` to get started!/n/n**Adding me to more servers**/n/nYou can add me to more servers with [this](https://thelmgn.com/db/gi/?id=" & client.CurrentUser.Id & ") link/n/n**Greetz**/n/n[LMGN](https://thelmgn.com) for creating me, [Haden](http://thehaden.co/) for creating the EBT Bot Testing server, [RogueException](https://github.com/RogueException) for creating Discord.NET, [Foxbot](http://foxbot.me) for creating the documentation and code examples, The [DiscordAPI](https://discord.gg/discord-api) server for help and [Aurora Community](http://discord.gg/aurora) for being such a great community.", "", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "Hi!", "", "You can show this message at anytime with lb.help.welcome"))

            End If
        End Function

        Async Function leftServer(ByVal guild As SocketGuild) As Task Handles client.LeftGuild
            Await TryCast(client.GetChannel(295552185826279424), IMessageChannel).SendMessageAsync("I just left " & guild.Name)
        End Function

        Async Function HandleBanne(ByVal user As SocketUser, guild As IGuild) As Task Handles client.UserBanned
            Dim banneChannel = Await guild.GetDefaultChannelAsync()
            Await banneChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/02/6b3cc6ff5c09de83cc37561a43304dee%281%29.gif", user.Username & " got banne™", "", "", "Banne™"))
        End Function

        Async Function HandleUnbanne(ByVal user As SocketUser, guild As IGuild) As Task Handles client.UserUnbanned
            Dim banneChannel = Await guild.GetDefaultChannelAsync()
            Await banneChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(0), Convert.ToByte(255), Convert.ToByte(0)), "", user.Username & " got unbanne™", "", "", "Unbanne™"))
        End Function

        Function getAge(Time As TimeSpan)
            If Time.TotalDays > 1 Then
                Return Math.Floor(Time.TotalDays) & " day(s)"
            Else
                If Time.TotalHours > 1 Then
                    Return Math.Floor(Time.TotalHours) & " hours(s)"
                Else
                    If Time.TotalMinutes > 1 Then
                        Return Math.Floor(Time.TotalMinutes) & " minute(s)"
                    Else
                        Return Time.TotalSeconds & " second(s)"
                    End If
                End If
            End If
        End Function
        Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
            Dim Generator As System.Random = New System.Random()
            Return Generator.Next(Min, Max)
        End Function
        Async Function HandleJoine(ByVal user As SocketGuildUser) As Task Handles client.UserJoined
            Await user.Guild.DefaultChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(0), Convert.ToByte(255), Convert.ToByte(0)), "", user.Username & " joine™, they signed up " & getAge(DateTime.UtcNow - user.CreatedAt) & " ago.", "", "", "User joine™."))

        End Function

        Async Function HandleKicke(ByVal user As SocketGuildUser) As Task Handles client.UserLeft
            Await user.Guild.DefaultChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", user.Username & " got kicke™ or left", "", "", "User leave."))
        End Function

        Function widetext(text As String)
            Return text.ToLower.Replace("a", "Ａ").Replace("b", "Ｂ").Replace("c", "Ｃ").Replace("d", "Ｄ").Replace("e", "Ｅ").Replace("f", "Ｆ").Replace("g", "Ｇ").Replace("h", "Ｈ").Replace("i", "Ｉ").Replace("j", "Ｊ").Replace("k", "Ｋ").Replace("l", "Ｌ").Replace("m", "Ｍ").Replace("n", "Ｎ").Replace("o", "Ｏ").Replace("p", "Ｐ").Replace("q", "Ｑ").Replace("r", "Ｒ").Replace("s", "Ｓ").Replace("t", "Ｔ").Replace("u", "Ｕ").Replace("v", "Ｖ").Replace("w", "Ｗ").Replace("x", "Ｘ").Replace("y", "Ｙ").Replace("z", "Ｚ")
        End Function


    End Class
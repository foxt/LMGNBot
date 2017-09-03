Imports System.Collections.ObjectModel
Imports System.Net
Imports System.Reflection
Imports System.Web
Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket
Imports Newtonsoft.Json
Imports System.Xml
Imports StatsdClient


Public Class CommandHandler

#Region "Initialize"
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
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loading Commands"))
        client = c
        name = namee
        ' Create the Command Service
        commands = New CommandService()
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loading Uptime"))
        uptime = DateTime.Now
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loading requests"))
        wc.Headers.Add(HttpRequestHeader.UserAgent, "botstion.tech")
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loading DataDog"))
        StatsdClient.DogStatsd.Configure(New StatsdConfig With {.Prefix = "Botstion as " & My.User.Name, .StatsdServerName = "127.0.0.1"})
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loaded Successfully"))
    End Sub
#End Region
#Region "Configuration"
    Public Class serverConfiguration
        Public serverID As Integer
        Public embeds As Boolean
    End Class
#End Region
#Region "Classes"
#Region "mcatClasses"
    Public Class mcatSort
        Public Property releaseDate As Integer
    End Class

    Public Class mcatResult
        Public Property _id As String
        Public Property title As String
        Public Property renderedArtists As String
        Public Property type As String
        Public Property upc As String
        Public Property catalogId As String
        Public Property releaseDate As DateTime
        Public Property preReleaseDate As DateTime?
        Public Property label As String
        Public Property coverUrl As String
        Public Property tags As Object()
        Public Property freeDownloadForUsers As Boolean
        Public Property showToAdminsOnly As Boolean
        Public Property showOnWebsite As Boolean
        Public Property showAsFree As Boolean
        Public Property urls As String()
        Public Property downloadable As Boolean
        Public Property streamable As Boolean
        Public Property inEarlyAccess As Boolean
        Public Property playlistId As String
        Public Property imageHashSum As String
        Public Property thumbHashes As Object
        Public Property coverArt As String
    End Class

    Public Class mcatResponse
        Public Property sort As mcatSort
        Public Property results As mcatResult()
        Public Property total As Integer
    End Class
#End Region
    Dim owapiresponse As OWAPI.OWAPIResponse
    Class bashquote
        Public id As String
        Public text As String
        Public votes As Integer
    End Class
    Dim bashQuotes = JsonConvert.DeserializeObject(My.Computer.FileSystem.ReadAllText("bash.min.json"))
    Class user
        Public id As Int64

    End Class

#End Region
    Dim users = New List(Of User)
    Dim allUsers = New List(Of Int64)
#Region "Functions"
    Async Function sendMessage(channel As IMessageChannel, text As String, Optional tts As Boolean = False, Optional embed As Embed = Nothing) As Task(Of IUserMessage)
        Return (Await channel.SendMessageAsync(text, tts, embed))
    End Function
#End Region
#Region "Message Handlers"
    Async Function hC(ByVal msg As IUserMessage) As Task Handles client.MessageReceived
        DogStatsd.Increment("Messages Seen")
        Try
            If msg.Content.StartsWith("b!") Then
                DogStatsd.Increment("Commands Seen")

                If msg.Content.StartsWith("b!mcatlookup ") Then
#Region "Monstercat"
                    Dim mcatMSG = Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                              .Author = New EmbedAuthorBuilder With {
                                                                                                   .Name = "Monstercat",
                                                                                                   .Url = "http://monstercat.com",
                                                                                                   .IconUrl = "https://assets.monstercat.com/essentials/logos/monstercat_logo_square_small.png"},
                                                                                              .Footer = New EmbedFooterBuilder With {
                                                                                                   .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                   .Text = "Botstion was made by theLMGN with Discord.NET."},
                                                                                              .Url = "https://botstion.tech",
                                                                                              .Title = "Searching...",
                                                                                              .Timestamp = DateTimeOffset.UtcNow,
                                                                                              .Color = black,
                                                                                              .Description = "Searching releases. This may take a while."})
                    Dim mcatFound = False
                    For Each result As mcatResult In JsonConvert.DeserializeObject(Of mcatResponse)(Await wc.DownloadStringTaskAsync(New Uri("https://connect.monstercat.com/api/catalog/release"))).results
                        If result.title.ToLower.Contains(msg.Content.Replace("b!mcatlookup ", "").ToLower) Or result.catalogId.ToUpper = msg.Content.Replace("b!mcatlookup ", "").ToUpper Then
                            Dim mcatFields = New List(Of EmbedFieldBuilder)
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Title", .Value = result.title}))
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Artist", .Value = result.renderedArtists}))
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "ID", .Value = result.catalogId}))
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Type", .Value = result.type}))
                            Dim mcatUrls = ""
                            For Each item As String In result.urls
                                If item.StartsWith("http://open.spotify.com") Or item.StartsWith("https://open.spotify.com") Then
                                    mcatUrls = mcatUrls & "[Spotify](" & item & ")"
                                ElseIf item.StartsWith("https://itunes.apple.com") Then
                                    mcatUrls = mcatUrls & "[iTunes Canada](" & item & ")"
                                ElseIf item.StartsWith("https://play.google.com") Then
                                    mcatUrls = mcatUrls & "[Google Play](" & item & ")"
                                ElseIf item.StartsWith("http://music.monstercat.com") Then
                                    mcatUrls = mcatUrls & "[Monstercat](" & item & ")"
                                ElseIf item.StartsWith("https://soundcloud.com") Then
                                    mcatUrls = mcatUrls & "[Soundcloud](" & item & ")"
                                ElseIf item.StartsWith("https://www.youtube.com") Then
                                    mcatUrls = mcatUrls & "[YouTube](" & item & ")"
                                ElseIf item.StartsWith("https://www.mixcloud.com") Then
                                    mcatUrls = mcatUrls & "[Mixcloud](" & item & ")"
                                ElseIf item.StartsWith("https://monstercatmedia.bandcamp.com") Then
                                    mcatUrls = mcatUrls & "[Bandcamp](" & item & ")"
                                Else
                                    mcatUrls = mcatUrls & item
                                End If
                                mcatUrls = mcatUrls & vbNewLine
                            Next
                            mcatUrls = mcatUrls & "[HD Cover](" & result.coverUrl.Replace(" ", "%20").Replace(")", "%29") & ")"
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = False, .Name = "Links", .Value = mcatUrls}))
                            Await mcatMSG.ModifyAsync(Function(x)
                                                          x.Embed = (New EmbedBuilder With {
                                                  .Author = New EmbedAuthorBuilder With {
                                                                                                   .Name = "Monstercat",
                                                                                                   .Url = "http://monstercat.com",
                                                                                                   .IconUrl = "https://assets.monstercat.com/essentials/logos/monstercat_logo_square_small.png"},
                                                                                              .Footer = New EmbedFooterBuilder With {
                                                                                                   .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                   .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                              .Url = "https://botstion.tech",
                                                                                              .Title = "Results",
                                                                                              .Timestamp = DateTimeOffset.UtcNow,
                                                                                              .Color = black,
                                                                                              .Fields = mcatFields,
                                                                                              .Description = "Here is the result for your search",
                                                                                              .ImageUrl = result.coverUrl.Replace(" ", "%20").Replace(")", "%29")}).Build
                                                          Return True
                                                      End Function)
                            mcatFound = True
                            Exit For
                        End If
                    Next

                    If mcatFound = False Then
                        Await msg.ModifyAsync(Function(x)
                                                  x.Embed = (New EmbedBuilder With {
                                              .Author = New EmbedAuthorBuilder With {
                                                                                               .Name = "Monstercat",
                                                                                               .Url = "http://monstercat.com",
                                                                                               .IconUrl = "https://assets.monstercat.com/essentials/logos/monstercat_logo_square_small.png"},
                                                                                          .Footer = New EmbedFooterBuilder With {
                                                                                               .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                               .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                          .Url = "https://botstion.tech",
                                                                                          .Title = "No results.",
                                                                                          .Timestamp = DateTimeOffset.UtcNow,
                                                                                          .Color = botstionBlue,
                                                                                          .Description = "Couldn't find any results for your search query. Track lookup soon."}).Build
                                                  Return True
                                              End Function)
                    End If
#End Region

                ElseIf msg.Content.StartsWith("b!say") And msg.Author.Id = 158311402677731328 Then
                    Await sendMessage(msg.Channel, "", False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "Botstion",
                                                                                                    .Url = "https://botstion.tech",
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "Message",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = botstionBlue,
                                                                                               .Description = msg.Content.Replace("b!say ", "")})
                    Await msg.DeleteAsync()
                ElseIf msg.Content.StartsWith("b!help") Then
                    Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                                   .Author = New EmbedAuthorBuilder With {
                                                                                                        .Name = "Botstion",
                                                                                                        .Url = "https://botstion.tech",
                                                                                                        .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png"},
                                                                                                   .Footer = New EmbedFooterBuilder With {
                                                                                                        .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                        .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                                   .Url = "https://botstion.tech",
                                                                                                   .Title = "Commands",
                                                                                                   .Timestamp = DateTimeOffset.UtcNow,
                                                                                                   .Color = botstionBlue,
                                                                                                   .Description = "```md\n# b!help\n    *Shows this message*\n# b!mcatlookup [release name/release id]\n    Looks up a Monstercat release\n# b!helpdesk [message]\n    Sends a message along with a instant invite to this server to the help desk team.\n# b!ash [quote id]\n    Looks up a quote on bash.org\n# b!quote [message id]\n   Quotes the message with the ID```\n\n[Statistics](https://p.datadoghq.com/sb/fdbbf58de-2d712f13e8?tv_mode=true) [Website](http://botstion.tech)".Replace("\n", Chr(13))})
#Region "Quotes"
                ElseIf msg.Content.StartsWith("b!qdb") Then

                ElseIf msg.Content.StartsWith("b!ash ") Then
                    Dim bashfound = False
                    Dim bashmsg = Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "bash.org QDB",
                                                                                                    .Url = "http://bash.org",
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/08/2017-08-27_13-53-05.png"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET."},
                                                                                               .Url = "http://bash.org/",
                                                                                               .Title = "Loading.",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = qdbOrange,
                                                                                               .Description = "Please wait whilst we load the database."})
                    bashQuotes = JsonConvert.DeserializeObject(Of List(Of bashquote))(My.Computer.FileSystem.ReadAllText("bash.min.json"))
                    Await bashmsg.ModifyAsync(Function(x)
                                                  x.Embed = New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "bash.org QDB",
                                                                                                    .Url = "http://bash.org",
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/08/2017-08-27_13-53-05.png"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET."},
                                                                                               .Url = "http://bash.org/",
                                                                                               .Title = "Loading...",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = qdbOrange,
                                                                                               .Description = "Please wait whilst we search the quotes."}.Build
                                                  Return True
                                              End Function)

                    For Each quote As bashquote In bashQuotes
                        If quote.id.ToString = msg.Content.Replace("b!ash ", "") Then
                            bashfound = True
                            Await bashmsg.ModifyAsync(Function(x)
                                                          x.Embed = New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "bash.org QDB",
                                                                                                    .Url = "http://bash.org",
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/08/2017-08-27_13-53-05.png"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET. This quote has " & quote.votes & " votes."},
                                                                                               .Url = "http://bash.org/?" & quote.id,
                                                                                               .Title = "Quote #" & quote.id & " (" & quote.votes & ")",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = qdbOrange,
                                                                                               .Description = quote.text.Replace("*", "\*")}.Build
                                                          Return True
                                                      End Function)
                        End If
                    Next
                    If bashfound = False Then
                        Await bashmsg.ModifyAsync(Function(x)
                                                      x.Embed = New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "bash.org QDB",
                                                                                                    .Url = "http://bash.org",
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/08/2017-08-27_13-53-05.png"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET."},
                                                                                               .Url = "http://bash.org/",
                                                                                               .Title = "Error",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = qdbOrange,
                                                                                               .Description = "We couldn't find that quote."}.Build
                                                      Return True
                                                  End Function)
                    End If
                ElseIf msg.Content.StartsWith("b!quote ") Then
                    Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                        .Author = New EmbedAuthorBuilder With {
                            .Name = "bash.org QDB",
                            .Url = "http://bash.org",
                            .IconUrl = "https://sx.thelmgn.com/2017/08/2017-08-27_13-53-05.png"},
                        .Footer = New EmbedFooterBuilder With {
                            .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                            .Text = "Botstion was made by theLMGN with Discord.NET."},
                        .Url = "http://bash.org/",
                        .Title = "Loading.",
                        .Timestamp = DateTimeOffset.UtcNow,
                        .Color = qdbOrange,
                        .Description = "Please wait whilst we load the database."})
#End Region
#Region "Overwatch"
                ElseIf msg.Content.StartsWith("b!ow") And False Then
                    If msg.Content.StartsWith("b!ow pc quickplay ") Then
                        Dim owRawData = Await wc.DownloadStringTaskAsync(New Uri("http://owapi.net/api/v3/u/" & msg.Content.Replace("b!ow pc quickplay ", "") & "/blob"))
                        If owRawData.Contains("""error"": 404") Then
                            Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                              .Author = New EmbedAuthorBuilder With {
                                                                                                   .Name = "Overwatch",
                                                                                                   .Url = "http://owapi.net",
                                                                                                   .IconUrl = "https://i.imgur.com/YZ4w2ey.png"},
                                                                                              .Footer = New EmbedFooterBuilder With {
                                                                                                   .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                   .Text = "Botstion was made by theLMGN with Discord.NET. Overwatch content is provided by http://owapi.net. Overwatch is a trademark of Blizzard Entertainment Inc."},
                                                                                              .Url = "https://botstion.tech",
                                                                                              .Title = "Error 404",
                                                                                              .Timestamp = DateTimeOffset.UtcNow,
                                                                                              .Color = oworange,
                                                                                              .Description = "Could not find profile."})
                        Else
                            Dim owData As OWAPI.OWAPIResponse = JsonConvert.DeserializeObject(Of OWAPI.OWAPIResponse)(owRawData)
                        End If

                    ElseIf msg.Content.StartsWith("b!ow pc competitive") Then

                    ElseIf msg.Content.StartsWith("b!ow ps4 quickplay") Then

                    ElseIf msg.Content.StartsWith("b!ow ps4 competitive") Then

                    ElseIf msg.Content.StartsWith("b!ow xbox quickplay") Then

                    ElseIf msg.Content.StartsWith("b!ow xbox competitive") Then

                    Else
                        Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                          .Author = New EmbedAuthorBuilder With {
                                                                                               .Name = "Overwatch",
                                                                                               .Url = "http://owapi.net",
                                                                                               .IconUrl = "https://i.imgur.com/YZ4w2ey.png"},
                                                                                          .Footer = New EmbedFooterBuilder With {
                                                                                               .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                               .Text = "Botstion was made by theLMGN with Discord.NET. Overwatch content is provided by http://owapi.net. Overwatch is a trademark of Blizzard Entertainment Inc."},
                                                                                          .Url = "https://botstion.tech",
                                                                                          .Title = "Invalid Syntax",
                                                                                          .Timestamp = DateTimeOffset.UtcNow,
                                                                                          .Color = oworange,
                                                                                          .Description = "Invalid syntax /n/nMust be in the format/n`b!ow <pc|ps4|xbox> <quickplay|competitive> battletag-number`/n/nExample:/n`b!ow pc quickplay theLMGN-2143`".Replace("/n", vbNewLine)})
                    End If
#End Region
                ElseIf msg.Content.StartsWith("b!helpdesk") Then
                    DogStatsd.Event("Help request from " & msg.Author.Username & "#" & msg.Author.Discriminator, msg.Content & Chr(13) & "Invite link: " & (Await TryCast(msg.Channel, IGuildChannel).CreateInviteAsync(1800, 1, True)).Url)
                    Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "Help Desk",
                                                                                                    .Url = "https://botstion.tech"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "Message sent!",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = botstionBlue,
                                                                                               .Description = ":white_check_mark: A message has been sent to the help desk team along with an instant invite to your channel."})
                Else
                    Await sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "Command Handler",
                                                                                                    .Url = "https://botstion.tech"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "Invalid command",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = botstionBlue,
                                                                                               .Description = "`" & msg.Content & "`is not a command. Try b!help for a list of 'em!"})
                End If
            End If
            If msg.Content = "b!authenticate" And TryCast(msg.Channel, IGuildChannel).GuildId = 320950192444669954 Then
                Dim memberrole = Nothing
                For Each role As IRole In client.GetGuild(320950192444669954).Roles
                    If role.Name = "Member" Then

                        memberrole = role
                    End If
                Next
                Await TryCast(msg.Author, IGuildUser).AddRoleAsync(memberrole)
                Await sendMessage(TryCast(client.GetChannel(321738285267419146), IMessageChannel), "", False, New EmbedBuilder With {
                    .Author = New EmbedAuthorBuilder With {
                        .IconUrl = msg.Author.GetAvatarUrl(),
                        .Name = msg.Author.Username},
                    .Color = botstionBlue,
                    .Description = "Hey @everybody! " & msg.Author.Username & " just joined the server!",
                    .ThumbnailUrl = msg.Author.GetAvatarUrl(),
                    .Title = "We have a new victim!",
                    .Footer = New EmbedFooterBuilder With {
                        .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                        .Text = "Botstion was made by theLMGN with Discord.NET"},
                    .Timestamp = DateTimeOffset.UtcNow
                }.Build)
                Await msg.DeleteAsync()
            End If
            If msg.Content.EndsWith("machine broke") Then
                sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {.Author = New EmbedAuthorBuilder With {.IconUrl = "https://sx.thelmgn.com/2017/09/firefox_2017-09-02_19-04-33.png", .Name = "Shaq"}, .Color = botstionBlue, .Description = "Understanda🅱le have a nice day", .Title = "Message from Shaq"}.Build)
            End If
            DogStatsd.Histogram("Response Time", (msg.CreatedAt - DateTime.Now).TotalMilliseconds)
        Catch ex As Exception
            sendMessage(msg.Channel, msg.Author.Mention, False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "Error Handler",
                                                                                                    .Url = "https://botstion.tech"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "An error happened whilst processing your command. ",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .Color = botstionBlue,
                                                                                               .Description = "A " & ex.Message & " error happened whilst running that command. The full technical details has been sent to the Botstion team."})
            Console.WriteLine(ex.ToString)
            DogStatsd.Event("Unhandled Exception in " & msg.Content & " from " & msg.Author.Username & "#" & msg.Author.Discriminator, ex.ToString)
        End Try

    End Function
#End Region
#Region "Handlers"
    Async Function backgroundTasks() As Task Handles client.Ready
        While True
            Try
                Await client.SetGameAsync("http://botstion.tech")
                DogStatsd.Gauge("Servers", client.Guilds.Count)
                DogStatsd.Gauge("Memory Used", Process.GetCurrentProcess.WorkingSet64)
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
                DogStatsd.Gauge("Unique Members", allUsers.Count)
            Catch ex As Exception
                DogStatsd.Event("Unhandled Exception in background tasks", ex.ToString)
            End Try
            Threading.Thread.Sleep(10000)
        End While
    End Function
    Async Function newServer(ByVal guild As SocketGuild) As Task Handles client.JoinedGuild
        Try
            Await TryCast(client.GetChannel(322480171745673218), IMessageChannel).SendMessageAsync("<@158311402677731328>", False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .IconUrl = guild.IconUrl,
                                                                                                    .Name = guild.Name,
                                                                                                    .Url = "https://botstion.tech"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "New server!",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .ThumbnailUrl = guild.IconUrl,
                                                                                               .Color = botstionBlue,
                                                                                               .Description = "Server name: " & guild.Name & vbNewLine & "Members: " & guild.MemberCount & vbNewLine & "Channels: " & guild.Channels.Count})
            DogStatsd.Event("Joined server", guild.Name & " with " & guild.MemberCount & " members")
            If client.Guilds.Count > 90 Then
                Await guild.DefaultChannel.SendMessageAsync("", False, New EmbedBuilder With {
                    .Author = New EmbedAuthorBuilder With {
                        .IconUrl = guild.IconUrl,
                        .Name = guild.Name,
                        .Url = "https://botstion.tech"},
                    .Footer = New EmbedFooterBuilder With {
                        .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                        .Text = "Botstion was made by theLMGN with Discord.NET"},
                    .Url = "https://botstion.tech",
                    .Title = "New server!",
                    .Timestamp = DateTimeOffset.UtcNow,
                    .ThumbnailUrl = guild.IconUrl,
                    .Color = botstionBlue,
                    .Description = "I've reached my guild limit of 90. I'm leaving here."})
                Await guild.LeaveAsync
                DogStatsd.Event("Guild limit", "Hit the 90 guild limit. Left " & guild.Name)
            Else
                Await guild.DefaultChannel.SendMessageAsync("", False, New EmbedBuilder With {
                    .Author = New EmbedAuthorBuilder With {
                        .IconUrl = guild.IconUrl,
                        .Name = guild.Name,
                        .Url = "https://botstion.tech"},
                    .Footer = New EmbedFooterBuilder With {
                        .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                        .Text = "Botstion was made by theLMGN with Discord.NET"},
                    .Url = "https://botstion.tech",
                    .Title = "Hello!",
                    .Timestamp = DateTimeOffset.UtcNow,
                    .ThumbnailUrl = guild.IconUrl,
                    .Color = botstionBlue,
                    .Description = "I'm Botstion! A Discord bot made by [TheLMGN](https://thelmgn.com)" & vbNewLine & vbNewLine & "[Visit my website](https://botstion.tech)/n[Join my creators Discord!](https://discord.gg/dE2aCVW)/n[Read the docs!](https://botstion.tech/help)/n[Check my source on Github!](https://github.com/thelmgn/botstion)".Replace("/n", vbNewLine)})

            End If
        Catch ex As Exception
            DogStatsd.Event("Unhandled Exception in joining " & guild.Name, ex.ToString)
        End Try
    End Function

    Async Function leftServer(ByVal guild As SocketGuild) As Task Handles client.LeftGuild
        Try
            Await TryCast(client.GetChannel(322480171745673218), IMessageChannel).SendMessageAsync("<@158311402677731328>", False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .IconUrl = guild.IconUrl,
                                                                                                    .Name = guild.Name,
                                                                                                    .Url = "https://botstion.tech"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "Left server. :(",
                                                                                               .Timestamp = DateTimeOffset.UtcNow,
                                                                                               .ThumbnailUrl = guild.IconUrl,
                                                                                               .Color = botstionBlue,
                                                                                               .Description = "Server name: " & guild.Name & vbNewLine & "Members: " & guild.MemberCount & vbNewLine & "Channels: " & guild.Channels.Count})
            DogStatsd.Event("Left server", guild.Name & " with " & guild.MemberCount & " members")
        Catch ex As Exception
            DogStatsd.Event("Unhandled Exception in leaving " & guild.Name, ex.ToString)
        End Try
    End Function

#End Region
#Region "Utilities"
    Dim wc As New WebClient
    Dim botstionBlue = New Color(Convert.ToByte(69), Convert.ToByte(255), Convert.ToByte(254))
    Dim black = New Color(Convert.ToByte(0), Convert.ToByte(0), Convert.ToByte(0))
    Dim oworange = New Color(Convert.ToByte(250), Convert.ToByte(160), Convert.ToByte(46))
    Dim qdbOrange = New Color(Convert.ToByte(192), Convert.ToByte(128), Convert.ToByte(0))
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

    Function widetext(text As String)
        Return text.ToLower.Replace("a", "Ａ").Replace("b", "Ｂ").Replace("c", "Ｃ").Replace("d", "Ｄ").Replace("e", "Ｅ").Replace("f", "Ｆ").Replace("g", "Ｇ").Replace("h", "Ｈ").Replace("i", "Ｉ").Replace("j", "Ｊ").Replace("k", "Ｋ").Replace("l", "Ｌ").Replace("m", "Ｍ").Replace("n", "Ｎ").Replace("o", "Ｏ").Replace("p", "Ｐ").Replace("q", "Ｑ").Replace("r", "Ｒ").Replace("s", "Ｓ").Replace("t", "Ｔ").Replace("u", "Ｕ").Replace("v", "Ｖ").Replace("w", "Ｗ").Replace("x", "Ｘ").Replace("y", "Ｙ").Replace("z", "Ｚ")
    End Function
#End Region

End Class
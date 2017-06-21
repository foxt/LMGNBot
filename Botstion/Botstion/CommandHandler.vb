Imports System.Collections.ObjectModel
Imports System.Net
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
    Public Async Function sendMessage(embed As Embed, originalMessage As IUserMessage) As Task
        Dim pm = Await originalMessage.Channel.SendMessageAsync(originalMessage.Author.Mention, False, embed)
        Dim el = New List(Of Embed)
        el.Add(embed)
        paginatedMessages.Add(New paginatedMessage With {
                              .ID = paginatedMessages.Count,
                              .embeds = el,
                              .message = pm,
                              .currentPage = 1})
        Await pm.AddReactionAsync(New Emoji("🇽"))

    End Function
    Public Async Function sendMessages(embeds As List(Of Embed), originalMessage As IUserMessage) As Task
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
        While True
            If reaction.Message.Value Is Nothing Then
                Await Log(New LogMessage(LogSeverity.Verbose, "Paginator", "Waiting for message."))
                Threading.Thread.Sleep(1000)
            Else
                Exit While
            End If
        End While
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
        client = c
        name = namee
        ' Create the Command Service
        commands = New CommandService()
        ' Retrieve the Bot User for later use
        self = client.CurrentUser()
        Await Log(New LogMessage(LogSeverity.Info, "Commands", "Loaded Successfully"))
        uptime = DateTime.Now
    End Sub
#End Region
#Region "Configuration"
    Public Class serverConfiguration
        Public serverID As Integer
        Public embeds As Boolean
    End Class
#End Region
#Region "JSON Classes"
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

    Public Class owachTank
        Public Property shot_down As Boolean
        Public Property halt_state As Boolean
        Public Property hog_wild As Boolean
        Public Property i_am_your_shield As Boolean
        Public Property mine_sweeper As Boolean
        Public Property power_overwhelming As Boolean
        Public Property giving_you_the_hook As Boolean
        Public Property game_over As Boolean
        Public Property the_power_of_attraction As Boolean
        Public Property anger_management As Boolean
        Public Property overclocked As Boolean
        Public Property storm_earth_and_fire As Boolean
    End Class

    Public Class owachSupport
        Public Property enabler As Boolean
        Public Property supersonic As Boolean
        Public Property the_floor_is_lava As Boolean
        Public Property huge_rez As Boolean
        Public Property the_iris_embraces_you As Boolean
        Public Property rapid_discord As Boolean
        Public Property the_car_wash As Boolean
        Public Property huge_success As Boolean
        Public Property group_health_plan As Boolean
        Public Property naptime As Boolean
    End Class

    Public Class owachMaps
        Public Property escort_duty As Boolean
        Public Property shutout As Boolean
        Public Property world_traveler As Boolean
        Public Property lockdown As Boolean
        Public Property cant_touch_this As Boolean
        Public Property double_cap As Boolean
    End Class

    Public Class owachSpecial
        Public Property cleanup_duty As Boolean
        Public Property survived_the_night As Boolean
        Public Property snowed_in As Boolean
        Public Property ambush As Boolean
        Public Property held_the_door As Boolean
        Public Property whap As Boolean
        Public Property cool_as_ice As Boolean
        Public Property flagbearer As Boolean
        Public Property not_a_scratch As Boolean
        Public Property four_they_were As Boolean
    End Class

    Public Class owachDefense
        Public Property did_that_sting As Boolean
        Public Property armor_up As Boolean
        Public Property ice_blocked As Boolean
        Public Property cold_snap As Boolean
        Public Property mine_like_a_steel_trap As Boolean
        Public Property roadkill As Boolean
        Public Property simple_geometry As Boolean
        Public Property raid_wipe As Boolean
        Public Property charge As Boolean
        Public Property the_dragon_is_sated As Boolean
        Public Property smooth_as_silk As Boolean
        Public Property triple_threat As Boolean
    End Class

    Public Class owachGeneral
        Public Property level_25 As Boolean
        Public Property decorated As Boolean
        Public Property the_path_is_closed As Boolean
        Public Property level_50 As Boolean
        Public Property survival_expert As Boolean
        Public Property blackjack As Boolean
        Public Property centenary As Boolean
        Public Property undying As Boolean
        Public Property level_10 As Boolean
        Public Property the_friend_zone As Boolean
        Public Property decked_out As Boolean
    End Class

    Public Class owachOffense
        Public Property whoa_there As Boolean
        Public Property special_delivery As Boolean
        Public Property rocket_man As Boolean
        Public Property their_own_worst_enemy As Boolean
        Public Property clearing_the_area As Boolean
        Public Property waste_not_want_not As Boolean
        Public Property power_outage As Boolean
        Public Property total_recall As Boolean
        Public Property hack_the_planet As Boolean
        Public Property death_from_above As Boolean
        Public Property die_die_die_die As Boolean
        Public Property target_rich_environment As Boolean
        Public Property slice_and_dice As Boolean
        Public Property its_high_noon As Boolean
    End Class

    Public Class owachivements
        Public Property tank As owachTank
        Public Property support As owachSupport
        Public Property maps As owachMaps
        Public Property special As owachSpecial
        Public Property defense As owachDefense
        Public Property general As owachGeneral
        Public Property offense As owachOffense
    End Class

    Public Class OWQPAverageStats
        Public Property objective_kills_avg As Double
        Public Property deaths_avg As Double
        Public Property healing_done_avg As Double
        Public Property objective_time_avg As Double
        Public Property time_spent_on_fire_avg As Double
        Public Property final_blows_avg As Double
        Public Property solo_kills_avg As Double
        Public Property damage_done_avg As Double
        Public Property melee_final_blows_avg As Double
        Public Property eliminations_avg As Double
    End Class

    Public Class OWQPOverallStats
        Public Property comprank As Integer
        Public Property avatar As String
        Public Property wins As Integer
        Public Property rank_image As String
        Public Property tier As String
        Public Property win_rate As Double
        Public Property prestige As Integer
        Public Property level As Integer
        Public Property losses As Integer
        Public Property games As Integer
    End Class

    Public Class OWQPGameStats
        Public Property shield_generator_destroyed_most_in_game As Double
        Public Property eliminations_most_in_game As Double
        Public Property environmental_kills As Double
        Public Property recon_assists_most_in_game As Double
        Public Property objective_kills As Double
        Public Property objective_time As Double
        Public Property kill_streak_best As Double
        Public Property objective_time_most_in_game As Double
        Public Property turrets_destroyed As Double
        Public Property final_blows As Double
        Public Property offensive_assists As Double
        Public Property defensive_assists As Double
        Public Property defensive_assists_most_in_game As Double
        Public Property environmental_deaths As Double
        Public Property medals_gold As Double
        Public Property recon_assists As Double
        Public Property games_won As Double
        Public Property medals_silver As Double
        Public Property eliminations As Double
        Public Property turrets_destroyed_most_in_game As Double
        Public Property teleporter_pads_destroyed As Double
        Public Property kpd As Double
        Public Property multikills As Double
        Public Property teleporter_pad_destroyed_most_in_game As Double
        Public Property solo_kills_most_in_game As Double
        Public Property offensive_assists_most_in_game As Double
        Public Property final_blows_most_in_game As Double
        Public Property medals As Double
        Public Property time_spent_on_fire As Double
        Public Property solo_kills As Double
        Public Property melee_final_blows_most_in_game As Double
        Public Property melee_final_blows As Double
        Public Property environmental_kills_most_in_game As Double
        Public Property multikill_best As Double
        Public Property damage_done As Double
        Public Property objective_kills_most_in_game As Double
        Public Property cards As Double
        Public Property healing_done_most_in_game As Double
        Public Property time_spent_on_fire_most_in_game As Double
        Public Property healing_done As Double
        Public Property medals_bronze As Double
        Public Property shield_generators_destroyed As Double
        Public Property damage_done_most_in_game As Double
        Public Property deaths As Double
        Public Property time_played As Double
    End Class

    Public Class OWquickplay
        Public Property average_stats As OWQPAverageStats
        Public Property competitive As Boolean
        Public Property overall_stats As OWQPOverallStats
        Public Property game_stats As OWQPGameStats
    End Class
    Public Class OWStatss
        Public Property competitive As Object ' Will intregrate Soon™
        Public Property quickplay As OWQuickplay
    End Class
    Public Class OWstats
        Public Property achievements As owachivements
        Public Property stats As OWStatss
        Public Property heroes As OWHeroes
    End Class
    Public Class OWAPIResponse
        Public Property eu As OWstats
        Public Property any As OWstats
        Public Property us As OWstats
        Public Property kr As OWstats
        Public Property _request As Object
    End Class
#End Region
#Region "Message Handlers"
    Async Function hC(ByVal msg As IUserMessage) As Task Handles client.MessageReceived
        If msg.Content.StartsWith("b!") Then
            If msg.Content.StartsWith("b!mcatlookup ") Then
                Dim mcatMSG = Await msg.Channel.SendMessageAsync(msg.Author.Mention, False, New EmbedBuilder With {
                                                                                              .Author = New EmbedAuthorBuilder With {
                                                                                                   .Name = "Monstercat",
                                                                                                   .Url = "http://monstercat.com",
                                                                                                   .IconUrl = "https://assets.monstercat.com/essentials/logos/monstercat_logo_square_small.png"},
                                                                                              .Footer = New EmbedFooterBuilder With {
                                                                                                   .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                   .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                              .Url = "https://botstion.tech",
                                                                                              .Title = "Searching...",
                                                                                              .Timestamp = DateTimeOffset.UtcNow,
                                                                                              .Color = botstionBlue,
                                                                                              .Description = "Searching releases. This may take a while."})
                Dim mcatWC As New WebClient
                Dim mcatFound = False
                For Each result As mcatResult In JsonConvert.DeserializeObject(Of mcatResponse)(Await mcatWC.DownloadStringTaskAsync(New Uri("https://connect.monstercat.com/api/catalog/release"))).results
                    If result.title.Contains(msg.Content.Replace("b!mcatlookup ", "")) Then
                        Dim mcatFields = New List(Of EmbedFieldBuilder)
                        mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Title", .Value = result.title}))
                        mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Artist", .Value = result.renderedArtists}))
                        mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "ID", .Value = result.catalogId}))
                        mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Type", .Value = result.type}))
                        Dim mcatUrls = ""
                        For Each item As String In result.urls
                            If item.StartsWith("https://open.spotify.com") Then
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
                                                                                              .Color = botstionBlue,
                                                                                              .Fields = mcatFields,
                                                                                              .Description = "Here is the result for your search",
                                                                                              .ImageUrl = result.coverUrl.Replace(" ", "%20").Replace(")", "%29")}).Build
                                                  End Function)
                        mcatFound = True
                        Exit For
                    End If
                Next
                If mcatFound = False Then
                    For Each result As mcatResult In JsonConvert.DeserializeObject(Of mcatResponse)(Await mcatWC.DownloadStringTaskAsync(New Uri("https://connect.monstercat.com/api/catalog/release"))).results
                        If result.catalogId.Contains(msg.Content.Replace("b!mcatlookup ", "")) Then
                            Dim mcatFields = New List(Of EmbedFieldBuilder)
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Title", .Value = result.title}))
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Artist", .Value = result.renderedArtists}))
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "ID", .Value = result.catalogId}))
                            mcatFields.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Type", .Value = result.type}))
                            Dim mcatUrls = ""
                            For Each item As String In result.urls
                                If item.StartsWith("https://open.spotify.com") Then
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
                                End If
                                mcatUrls = mcatUrls & vbNewLine
                            Next
                            mcatUrls = mcatUrls & "[HD Cover](" & (result.coverUrl.Replace(" ", "%20").Replace(")", "%29")) & ")"
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
                                                                                              .Color = botstionBlue,
                                                                                              .Fields = mcatFields,
                                                                                              .Description = "Here is the result for your search",
                                                                                              .ImageUrl = result.coverUrl.Replace(" ", "%20").Replace(")", "%29")}).Build
                                                      End Function)
                            mcatFound = True
                            Exit For
                        End If
                    Next
                End If
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
                                          End Function)
                End If
            Else
                Await msg.Channel.SendMessageAsync(msg.Author.Mention, False, New EmbedBuilder With {
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
        If msg.Content = "AAxx" And False Then
            Await msg.DeleteAsync()
            Dim thingies = New List(Of EmbedFieldBuilder)
            thingies.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Author", .Value = "<@158311402677731328>"}))
            thingies.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Bot", .Value = client.CurrentUser.Mention}))
            thingies.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Permissions", .Value = "All the ones except the ones that shouldn't be granted, or shouldn't be granted without permission."}))
            thingies.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Source", .Value = "https://github.com/thelmgn/botstion"}))
            thingies.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Framework", .Value = "Discord.NET"}))
            thingies.Add((New EmbedFieldBuilder With {.IsInline = True, .Name = "Website", .Value = "https://botstion.tech"}))
            Await msg.Channel.SendMessageAsync("", False, New EmbedBuilder With {
                                                                                               .Author = New EmbedAuthorBuilder With {
                                                                                                    .Name = "theLMGN#4036",
                                                                                                    .Url = "https://thelmgn.com",
                                                                                                    .IconUrl = "http://www.download.thelmgn.com/branding/2017/logo.jpg"},
                                                                                               .Footer = New EmbedFooterBuilder With {
                                                                                                    .IconUrl = "https://sx.thelmgn.com/2017/06/botstion.png",
                                                                                                    .Text = "Botstion was made by theLMGN with Discord.NET"},
                                                                                               .Url = "https://botstion.tech",
                                                                                               .Title = "Botstion",
                                                                                               .Color = botstionBlue,
                                                                                               .Fields = thingies
                                                                                               })
        End If
    End Function
#End Region
#Region "Handlers"
    Async Function newServer(ByVal guild As SocketGuild) As Task Handles client.JoinedGuild
        Await TryCast(client.GetChannel(290522781354033154), IMessageChannel).SendMessageAsync("<@158311402677731328>", False, New EmbedBuilder With {
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
            Await TryCast(client.GetChannel(295552185826279424), IMessageChannel).SendMessageAsync("<@158311402677731328>", False, New EmbedBuilder With {
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
                .Description = "I've reached my guild limit of 90. I'm leaving " & guild.Name & "."})
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
    End Function

    Async Function leftServer(ByVal guild As SocketGuild) As Task Handles client.LeftGuild
        Await TryCast(client.GetChannel(290522781354033154), IMessageChannel).SendMessageAsync("<@158311402677731328>", False, New EmbedBuilder With {
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
    End Function

#End Region
#Region "Utilities"
    Dim botstionBlue = New Color(Convert.ToByte(69), Convert.ToByte(255), Convert.ToByte(254))
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
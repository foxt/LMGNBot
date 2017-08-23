import discord
import asyncio
from random import randint
from time import sleep
import os
from sys import exit
import math

client = discord.Client()

def rad():
    rad_numb = randint(1,6)
    if rad_numb == 1:
        return "one"
    
    if rad_numb == 2:
        return "two"

    if rad_numb == 3:
        return "three"

    if rad_numb == 4:
        return "four"

    if rad_numb == 5:
        return "five"
    
    if rad_numb == 6:
        return "six"


async def my_background_task():
    await client.wait_until_ready()
    counter = True
    channel = discord.Object(id='channel_id_here')
    while not client.is_closed:
        

        await asyncio.sleep(10) # task runs every 60 seconds

@client.event
async def on_ready():
    print(' ___       _____ ______   ________  ________   ________  ________  _________   ')
    print('|\  \     |\   _ \  _   \|\   ____\|\   ___  \|\   __  \|\   __  \|\___   ___\ ')
    print('\ \  \    \ \  \\\__\ \  \ \  \___|\ \  \\ \  \ \  \|\ /\ \  \|\  \|___ \  \_| ')
    print(' \ \  \    \ \  \\|__| \  \ \  \  __\ \  \\ \  \ \   __  \ \  \\\  \   \ \  \  ')
    print('  \ \  \____\ \  \    \ \  \ \  \|\  \ \  \\ \  \ \  \|\  \ \  \\\  \   \ \  \ ')
    print('   \ \_______\ \__\    \ \__\ \_______\ \__\\ \__\ \_______\ \_______\   \ \__\ ')
    print('    \|_______|\|__|     \|__|\|_______|\|__| \|__|\|_______|\|_______|    \|__|')
    print('                                Logged in as:')
    namePos = round(len("Bot Name: " + client.user.name) / 2)
    namePos = 40 - namePos
    print(" " * namePos +  "Bot Name: "  + client.user.name)
    idPos = round(len("Client ID: " + client.user.id) / 2)
    idPos = 40 - idPos
    print(" " * idPos +  "Client ID: "  + client.user.id)
    invitePos = round(len("Invite: thelmgn.com/db/gi?id=" + client.user.id) / 2)
    invitePos = 40 - invitePos
    print(" " * invitePos +  "Invite: thelmgn.com/db/gi?id=" + client.user.id)
    print('_' * 80)

    
@client.event
async def on_channel_delete(channel):
    cd_embed = discord.Embed(title="Channel deleted", type="rich", description="The channel " + channel.name + " was deleted.", color=discord.Color.red())
    await client.send_message(discord.utils.find(lambda m: m.name == 'lmgnstestingrealm', channel.server.channels), embed=cd_embed)

@client.event
async def on_channel_create(channel):
    cc_embed = discord.Embed(title="Channel created", type="rich", description="The channel " + channel.name + " was created.", color=discord.Color.green())
    await client.send_message(discord.utils.find(lambda m: m.name == 'lmgnstestingrealm', channel.server.channels), embed=cc_embed)

@client.event
async def on_message(message):

    if message.author.id > 0:
        print("New message from "+message.author.name + " in "+ message.channel.name + " ("+message.server.name+")")
        print(message.content)
        print("")
        
        if message.content.startswith('!messagecount'):
            count_counter = 0
            count_messages = 0
            count_tmp = await client.send_message(message.channel, 'Calculating messages...')
            async for log in client.logs_from(message.channel, limit=100):
               count_messages += 1
               if log.author == message.author:
                   count_counter += 1

            await client.edit_message(count_tmp, ':abc: Of the ' + str(count_messages) +  " messages I've analyzed in this channel, " + str(count_counter) + " we're posted by you. %" + str(math.floor(float(count_counter / count_messages) * 100)))
    

        elif message.content.startswith("!hello"):
            await client.send_message(message.channel, ":slight_smile: Hello, "+message.author.name+"!")
    

        elif message.content.startswith("!avatar"):
            await client.send_message(message.channel, ":frame_photo: <@"+message.author.id+">'s Picture is "+message.author.avatar_url)
   
        elif message.content.startswith("!emoji_url"):
            await client.send_message(message.channel, "Okay! Add a reaction to this message to get the URL")
    
        elif message.content.startswith("!cmds"):
            await client.send_message(message.author, ":abc: Commands:\n`!messagecount` - Looks at the last 100 message and calculates the percentage of the ones you've sent\n`!hello` - Says hello back. Because I'm nice (It's also useful for debugging.)\n`!emoji_url` - Allows you to get a url of an emoji using reactions.\n`!rtd` - Allows you roll a virtual die! (please wait for the :game_die: to go away before running the command again).\n`!feedback` - Sends you a Google Forms document for feedback.\n`!help (note)` - Sends the helpdesk a invite link + a message. (eg !help !kick isn't working)\n`!avatar` - Gets **your** avatar url.\n`!userinfo @mention` - Gets some info on the user mentioned. (eg !userinfo <@"+ message.author.id +">)\n`!ban @mention` - Bans a member (requires permissions). (eg !ban <@"+ message.author.id +">)\n`!kick @mention` - Kicks a user (requires permissions). (eg !kick <@"+ message.author.id +">)\n`!prune (number)` - Prunes message (requires manage messages permissions) (eg !prune 5)\n`!credits` - Credits/Helpers/Links (add to server)\n`!donate` - Donate (eg !donate 5)\n`!helpdesk (message)` - Sends a message to the support team\n`!serverinfo (servername)` - Gets some info on the server ")
            await client.send_message(message.channel, ":mailbox_with_mail: The commands have been DMed to you! <@" + message.author.id + ">")
    
        elif message.content.startswith("!credits"):
            await client.send_file(message.channel, "logo.png", filename="lmgnbotlogo.png", content=":abc: LMGNBot Pre-Release \n\nCoded by LMGN \nIdeas from *Soren805*\nHelp from the Discord API Discord server.\nDiscord.py wrote by Rapptz\n\nMake your own Discord Bot: https://github.com/Rapptz/discord.py \nAdd me to your discord server: http://thelmgn.com/db/gi?id=" + client.user.id, tts=False)

        elif message.content.startswith("!donate"):
            await client.send_message(message.channel, ":dollar: http://paypal.me/lmgn/" + message.content.replace("!donate ", "").replace("!donate",""))

        elif message.content.startswith("!helpdesk"):
            helpdesk_invite = await client.create_invite(message.channel, max_uses=1, temporary=True)
            await client.send_message(discord.Object(id="245260407864950785"), ":information_desk_person::skin-tone-1: `<@" + message.author.id + "> (" + message.author.name + ") needs help in " + message.server.name + " (" + helpdesk_invite.url  + ")\n" + message.content)
            await client.send_message(message.channel, ":information_desk_person::skin-tone-1: The information has been sent to the helpdesk team. + invite link to this channel")
        
        elif message.content.startswith("!update_avatar"):
            updateavatar_image = open("logo.png", "rb")
            await client.edit_profile(avatar=updateavatar_image.read())
            updateavatar_image.close()
            await client.send_message(message.channel, ":frame_photo: Updated my profile picture!")

        elif message.content.startswith("!rtd"):
            rtd_message = await client.send_message(message.channel,":"+rad()+": :game_die:")
            sleep(0.001)
            await client.edit_message(rtd_message,":"+rad()+": :game_die:")
            sleep(0.001)
            await client.edit_message(rtd_message,":"+rad()+": :game_die:")
            sleep(0.001)
            await client.edit_message(rtd_message,":"+rad()+": :game_die:")
            sleep(0.001)
            await client.edit_message(rtd_message,":"+rad()+": :game_die:")
            sleep(0.001)
            await client.edit_message(rtd_message,":"+rad()+":")

        elif message.content.startswith("!feedback"):
            await client.send_message(message.channel, ":mailbox_with_mail: Send your feedback here: https://goo.gl/forms/OUQxzTGIKKY0BP7t1")
            await client.send_message(message.channel, ":id: <@"+message.author.id+">'s ID is " + message.author.id)

        elif message.content.startswith("!userinfo"):
            userinfo_userfound = False
            userinfo_message = await client.send_message(message.channel,"Please wait.")
            for member in message.server.members:
                if userinfo_userfound == False:
                    
                    if member.mentioned_in(message):
                        if userinfo_userfound == False:
                            await client.edit_message(userinfo_message, "Found user! Preparing response.")
                            userinfo_userinfostring = "Picture: "+member.avatar_url + "\nDefault Picture: "+member.default_avatar_url + "\nStatus:" + str(member.status) + "\nName: " +member.name + "\nNickname: "+member.display_name + "\nDiscriminator: #"+member.discriminator + "\nRobot: "+str(member.bot) + "\nMention: <@" + member.id+ ">" +"\nID: "+str(member.id)+"\nSignup Time: "+str(member.created_at)
                            await client.edit_message(userinfo_message, userinfo_userinfostring)
                            userinfo_userfound = True
            if userinfo_userfound == False:
                await client.edit_message(userinfo_message, ":x: We couldn't find " + message.content.replace("!userinfo","", 1))

        elif message.content.startswith("!serverinfo"):
            serverinfo_serverfound = False
            serverinfo_message = await client.send_message(message.channel,"Please wait.")
            for server in client.servers:
                if serverinfo_serverfound == False:
                    if message.content.replace("!serverinfo ", "", 1) in server.name:
                        if serverinfo_serverfound == False:
                            await client.edit_message(serverinfo_message, "Found server! Preparing response.")

                            serverinfo_channels = 0
                            for channels in server.channels: 
                                serverinfo_channels =+ 1

                            serverinfo_roles = 0
                            for roles in server.roles: 
                                serverinfo_roles =+ 1

                            serverinfo_emojis = 0
                            for emojis in server.emojis: 
                                serverinfo_emojis =+ 1

                            serverinfo_serverinfostring = "Name: " + server.name + "\nRole count: " + str(serverinfo_roles) + "\nEmoji count:" + str(serverinfo_emojis) + "\nRegion: " + str(server.region) + "\nAFK Timeout: " + str(server.afk_timeout) + "\nAFK Channel: " + str(server.afk_channel.name) + "\nMember Count: " + str(server.member_count) + "\nChannel Count: " + str(serverinfo_channels) + "\nOwner: " + server.owner.mention + " (" + server.owner.name + ") " + "\nRequires 2FA: " + str(bool(server.mfa_level)) + "\nMainchat Channel: " + server.default_channel.name + "\n IconURL: " + server.icon_url + "\nCreated Time: " + str(server.created_at)
                            await client.edit_message(serverinfo_message, serverinfo_serverinfostring)
                            serverinfo_serverfound = True
                            if server.default_channel.permissions_for(client.user).create_instant_invite == True:
                                serverinfo_invite = await client.create_invite(destination=server.default_channel, max_age=300, xkcd=True)
                                await client.edit_message(serverinfo_message, serverinfo_message.content + "\nInvite Link:" + serverinfo_invite)
                            else:
                                await client.edit_message(serverinfo_message, serverinfo_message.content + "\nInvite Link: :cop::skin-tone-1: I don't permissions.")
                            
                            
            if serverinfo_serverfound == False:
                await client.edit_message(serverinfo_message, ":x: We couldn't find " + message.content.replace("!serverinfo","", 1))
                
        elif message.content.startswith("!shutdown"):
            if message.author.id == "158311402677731328":
                await client.send_message(message.channel,":wave::skin-tone-1:")
                client.logout()
                exit()
            else:
                await client.send_message(message.channel,":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!broadcast allservers"):
            if message.author.id == "158311402677731328":
                for server in client.servers:
                    await client.send_message(server.default_channel, message.content.replace("!broadcast allservers", ""))
            else:
                await client.send_message(message.channel,":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!broadcast allchannels"):
            if message.author.id == "158311402677731328":
                for server in client.servers:
                    for channel in server.channels:
                        await client.send_message(channel, message.content.replace("!broadcast allchannels", ""))
            else:
                await client.send_message(message.channel,":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!embedTest"):
            et_embed = discord.Embed(title="Title of the embed", type="rich", description="This is the description", url="https://thelmgn.com", color=discord.Color.teal())
            et_embed.set_footer(text="FOOTER", icon_url="https://i.imgur.com/3G99xcd.png")
            et_embed.set_image(url="https://i.imgur.com/3G99xcd.png")
            et_embed.set_author(name="LMGN", url="https://thelmgn.com",icon_url="https://i.imgur.com/3G99xcd.png")
            await client.send_message(message.channel, embed=et_embed)

        elif message.content.startswith("!users"):
            
            users_numb = 0
            if True:
                users_message = client.send_message(message.channel,"Please wait.")
                for server in client.servers:
                    for member in server.members:
                        users_numb += 1
                client.edit_message(users_message,str(users_numb))
            else:
                await client.send_message(message.channel,":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!servers"):
            servers_string = "Servers:"
            if message.author.id == "158311402677731328":
                for server in client.servers:
                        servers_string = servers_string + "\n" +server.name
                await client.send_message(message.channel,servers_string)
            else:
                await client.send_message(message.channel,":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!kick"):
            if message.channel.permissions_for(message.author).kick_members:
                kick_userfound = False
                kick_message = await client.send_message(message.channel,"Kicked:")
                for member in message.server.members:
                    if member.mentioned_in(message):
                        await client.kick(member)
                        await client.send_message(message.channel, kick_message.content +  member.name)
            else:
                await client.send_message(message.channel, ":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!ban "):
            if message.channel.permissions_for(message.author).ban_members:
                ban_userfound = False
                ban_message = await client.send_message(message.channel,"Banned:")
                for member in message.server.members:
                    if member.mentioned_in(message):
                        await client.ban(member)
                        await client.send_message(message.channel, ban_message.content + member.name)
            else:
                await client.send_message(message.channel, ":cop::skin-tone-1: You do not have permissions!")

        elif message.content.startswith("!purge "):        
            if message.channel.permissions_for(message.author).manage_messages:
                await client.send_message(message.channel, "Deleted "+str(len(await client.purge_from(message.channel, limit=int(message.content.replace("!purge ", "")))))+" messages, <@" + message.author.id + ">"".")
            else:
                await client.send_message(message.channel, ":cop::skin-tone-1: You do not have permissions!")
     

@client.event
async def on_reaction_add(reaction, user):
    if reaction.message.author.id == client.user.id:
        if reaction.message.content == "Okay! Add a reaction to this message to get the URL":
            if reaction.custom_emoji:
                await client.send_message(reaction.message.channel, "<@"+user.id+"> Here's the URL: " + reaction.emoji.url + " and the emoji ID is " + str(reaction.emoji.id))
                await client.delete_message(reaction.message)
            else:
                await client.send_message(reaction.message.channel, "<@"+user.id+"> :x: Sorry, I can only get urls for custom emoji.")
                await client.delete_message(reaction.message)




startPos = round(len("LMGNBot successfully loaded! Connecting to discord") / 2)
startPos = 40 - startPos
print(" " * startPos +  "LMGNBot successfully loaded! Connecting to Discord")
print('_' * 80)
client.loop.create_task(my_background_task())
client.run("Token")
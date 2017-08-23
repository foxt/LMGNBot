#Config

#Colors
add = discord.Color.green() #Join/Unban/Sent/Added
remove = discord.Color.red() #Ban/Delete/removed
change = discord.Color.teal() # Edited/modified

#Texts
botname = "Logbot"
boturl = "https://thelmgn.com"
botlogo = "https://cdn3.iconfinder.com/data/icons/file-format-2/512/log_.log_file_file_format_document_extension_format-512.png"

#token
token = "MjQ3NzkyNzM3NzU4MzQ3MjY0.CzhFLQ.E31SQZ93sR_c5M722sh30eOYwtM" # By default, this token is a dud.



#You don't need to edit anything below this line :D































































































































































































































































































import os
try:
    from shutil import make_archive
    import discord
    import asyncio
    import time
except ImportError:
    print("Ohh noooeess. You don't have Discord.py installed'")
    try:
        import pip
        pip.main(['install', 'discord.py'])
    except:
        print("We tried to install them for you, but it failed")


client = discord.Client()

@client.event
async def on_ready():
    print('Logged in as')
    print(client.user.name)
    print(client.user.id)
    print('------')

async def logEvent(logText,coloroony):
    if not os.path.exists("logs"):
        os.makedirs("logs")
    fh = open(time.strftime("logs\%y %m %d") + ".log", "a")
    fh.write(time.strftime("%d/%m/%Y %I:%M:%S") + " " + logText)
    fh.close()
    et_embed = discord.Embed(title="Log event", type="rich", description=logText, color=coloroony)
    et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
    et_embed.set_author(name=botname, url=boturl,icon_url=botlogo)
    await client.send_message(discord.Object(id="248166421337604096"), embed=et_embed)
    
    

@client.event
async def on_message_delete(message):
    await logEvent("Message deleted: Message author: " + message.author.display_name + " " +message.author.mention + " in " + message.channel.name + chr(13) + message.content + chr(13) + "", remove())
 
@client.event
async def on_message(message):
    if not message.author.id == client.user.id:
        await logEvent("Message sent by: " + message.author.display_name + " " +message.author.mention + " in " + message.channel.name + chr(13) + message.content + chr(13) + "", add())

    if message.content == "!shutdown":
        if message.channel.permissions_for(message.author).manage_server:
            logEvent("HandNut:spin: Shutting down.")
            client.logout()
            close()
        else:
            et_embed = discord.Embed(title="Permission Error", type="rich", description=":cop::skin-tone-1: You do not have permissions! " + messsage.author.mention, color=remove())
            et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
            et_embed.set_author(name=botname, url=boturl,icon_url=boturl)
            await client.send_message(message.channel, embed=et_embed)

    if message.content == "!getLogs":
        if message.channel.permissions_for(message.author).manage_server:
            if os.path.exists("logs.zip"):
                os.remove("logs.zip")
            make_archive('logs', 'zip', root_dir='logs')
            await client.send_file(message.author, "logs.zip", filename="HereAreTheLogsYouRequested.zip", content=":envelope_with_arrow: Here are the logs.")
        else:
            et_embed = discord.Embed(title="Permission Error", type="rich", description=":cop::skin-tone-1: You do not have permissions! " + messsage.author.mention, color=remove())
            et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
            et_embed.set_author(name=botname, url=boturl,icon_url=boturl)
            await client.send_message(message.channel, embed=et_embed)

@client.event
async def on_message_edit(before, after):
    if before.content == after.content:
    else:
        await logEvent("Message Edited by: " + after.author.display_name + " " +after.author.mention + " in " + after.channel.name + "    " + chr(13) + "Old Content:" + chr(13) + before.content + chr(13) + "New Content:" + chr(13) + after.content + chr(13) + "", change())

@client.event
async def on_reaction_add(reaction, user):
    await logEvent("Reaction added to a message by: " + reaction.message.author.display_name + " " + reaction.message.author.mention + chr(13) + "Message content:" + chr(13) + reaction.message.content + chr(13) + "Reaction: " + reaction.emoji.name + " added by: " + user.display_name + " " + user.mention, add())

@client.event
async def on_reaction_remove(reaction, user):
    await logEvent("Reaction removed from a message by: " + reaction.message.author.display_name + " " +reaction.message.author.mention + chr(13) + "Message content:" + chr(13) + reaction.message.content + chr(13) + "Reaction: " + reaction.emoji.name + " added by: " + user.display_name + " " + user.mention, remove())

@client.event
async def on_channel_delete(channel):
    await logEvent("The channel " + channel.name + " has been deleted.", remove())

@client.event
async def on_channel_create(channel):
    await logEvent("The channel " + channel.name + " has been created.", add())

@client.event
async def on_channel_update(before,after):
    await logEvent("The channel " + after.name + " has been modified.", change())

@client.event
async def on_member_join(member):
    await logEvent("The user " + member.display_name + " " + member.mention + " has joined the server.", add())
    
@client.event
async def on_member_leave(member):
    await logEvent("The user " + member.name + " " + member.mention + " has left the server.", remove())

@client.event
async def on_member_update(before,after):
    if before.display_name != after.display_name:
        await logEvent("The user " + before.display_name + " " + member.mention + " changed their display_name to " + after.display_name, change())

    if before.top_role != after.top_role:
        await logEvent("The user " + after.display_name + " " + after.mention + " has been promoted/demoted to " + after.top_role.name + " from " + before.top_role.name, change())

@client.event
async def on_server_role_create(role):
    await logEvent("The role " + role.name + " has been created.", add())

@client.event
async def on_server_role_delete(role):
    await logEvent("The role " + role.name + " has been deleted.", remove())

@client.event
async def on_member_ban(member):
    await logEvent(member.name + " has been banned from the server.", remove())

@client.event
async def on_member_unban(member):
    await logEvent(member.name + " has been unbanned from the server.", add())
    
client.run(token)

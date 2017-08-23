from shutil import make_archive
import discord
import asyncio
import time
import os

#Change colors

add = discord.Color.green() #Join/Unban/Sent/Added
remove = discord.Color.red() #Ban/Delete/removed
change = discord.Color.blue() # Edited/modified
action = discord.Color.teal() # Pinned


client = discord.Client()

@client.event
async def on_ready():
    print('Logged in as')
    print(client.user.name)
    print(client.user.id)
    print('------')

    
@client.event
async def on_member_join(member):
    et_embed = discord.Embed(title="Member Join", type="rich", description=member.name + " has joined.", color=discord.Color.green())
    et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
    et_embed.set_author(name="Aurora Welcomer", url="https://auroradoesn'thavea.website'",icon_url="https://sx.thelmgn.com/2016/12/r3qb1.png")
    et_embed.set_image(url=str(str(member.avatar_url)))
    await client.send_message(discord.Object(id="259845862715424768"), embed=et_embed)
    
@client.event
async def on_member_leave(member):
    et_embed = discord.Embed(title="Member Leave", type="rich", description=member.name + " has joined.", color=discord.Color.red())
    et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
    et_embed.set_author(name="Aurora Welcomer", url="https://auroradoesn'thavea.website",icon_url="https://sx.thelmgn.com/2016/12/r3qb1.png")
    et_embed.set_image(url=str(member.avatar_url))
    await client.send_message(discord.Object(id="259845862715424768"), embed=et_embed)

@client.event
async def on_member_ban(member):
    et_embed = discord.Embed(title="Member Ban", type="rich", description=member.name + " has banned.", color=discord.Color.red())
    et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
    et_embed.set_author(name="Aurora Welcomer", url="https://auroradoesn'thavea.website",icon_url="https://sx.thelmgn.com/2016/12/r3qb1.png")
    et_embed.set_image(url=str(member.avatar_url))
    await client.send_message(discord.Object(id="259845862715424768"), embed=et_embed)
    
@client.event
async def on_member_unban(server, member):
    et_embed = discord.Embed(title="Member Unban", type="rich", description=member.name + " has been unbanned.", color=discord.Color.green())
    et_embed.set_footer(text="coded by lmgn", icon_url="https://i.imgur.com/3G99xcd.png")
    et_embed.set_author(name="Aurora Welcomer", url="https://auroradoesn'thavea.website",icon_url="https://sx.thelmgn.com/2016/12/r3qb1.png")
    et_embed.set_image(url=str(member.avatar_url))
    await client.send_message(discord.Object(id="259845862715424768"), embed=et_embed)

#Heres the token! :D

client.run('MjYwMTE4Mzg0NDEzMjQ1NDQw.Czhtpg.Rxa_v3FIPpaT5-DtPqpi4MKvHJ8')

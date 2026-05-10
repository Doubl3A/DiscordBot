using Core;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostApplicationBuilder(args);

builder.Services.AddHostedService<ApplicationHost>();
builder.Services.AddSingleton<DiscordClient>();
builder.Services.AddSingleton(new DiscordConfiguration());


// Initialize new bot
var bot = new DiscordBot();

// Configuration
bot.UseSlashCommands();

// TODO - Migrate to Lavalink4NET as DSharpPlus.Lavalink is deprecated
bot.AddLavalink();

await bot.Run();
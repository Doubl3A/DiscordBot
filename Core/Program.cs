using Core;

// Initialize new bot
var bot = new DiscordBot();

// Configuration
bot.UseSlashCommands();
bot.AddLavalink();

await bot.Run();
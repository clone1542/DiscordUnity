﻿using DiscordUnity2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordUnity2.State
{
    public class DiscordChannel
    {
        public string Id { get; internal set; }
        public ChannelType Type { get; internal set; }
        public DiscordServer Server { get; internal set; }
        public int? Position { get; internal set; }
        public DiscordOverwrite[] PermissionOverwrites { get; internal set; }
        public string Name { get; internal set; }
        public string Topic { get; internal set; }
        public bool? Nsfw { get; internal set; }
        public string LastMessageId { get; internal set; }
        public int? Bitrate { get; internal set; }
        public int? UserLimit { get; internal set; }
        public int? RateLimitPerUser { get; internal set; }
        public Dictionary<string, DiscordUser> Recipients { get; internal set; }
        public string Icon { get; internal set; }
        public DiscordUser Owner { get; internal set; }
        public string ApplicationId { get; internal set; }
        public DiscordChannel Parent { get; internal set; }
        public DateTime? LastPinTimestamp { get; internal set; }

        internal DiscordChannel(ChannelModel model, DiscordServer server = null)
        {
            Id = model.Id;
            Type = model.Type;
            if (server != null) Server = server;
            else if (!string.IsNullOrEmpty(model.GuildId)) Server = DiscordAPI.Servers[model.GuildId];
            Position = model.Position;
            Topic = model.Topic;
            Nsfw = model.Nsfw;
            LastMessageId = model.LastMessageId;
            Bitrate = model.Bitrate;
            UserLimit = model.UserLimit;
            RateLimitPerUser = model.RateLimitPerUser;
            Recipients = model.Recipients?.ToDictionary(x => x.Id, x => new DiscordUser(x));
            Icon = model.Icon;
            Owner = Recipients?[model.OwnerId];
            ApplicationId = model.ApplicationId;
            LastPinTimestamp = model.LastPinTimestamp;
        }

        public Task<RestResult<DiscordMessage>> CreateMessage(string content, string nonce = null, bool tts = false)
            => DiscordAPI.CreateMessage(Id, content, nonce, tts);
    }

    public class DiscordOverwrite
    {
        public string Id { get; internal set; }
        public string Type { get; internal set; }
        public int Allow { get; internal set; }
        public int Deny { get; internal set; }

        internal DiscordOverwrite(OverwriteModel model)
        {
            Id = model.Id;
            Type = model.Type;
            Allow = model.Allow;
            Deny = model.Deny;
        }
    }
}

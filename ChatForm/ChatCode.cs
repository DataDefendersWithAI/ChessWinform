using System;
using System.Collections.Generic;

namespace winforms_chat
{
    public static class ChatCommandExt
    {
        public enum ChatCommand
        {
            Move,
            EndGame,
            Rematch,
            TimeSync,
            ServerCreateRoom,
            ClientLeaveRoom,
            ClientDisconnect,
            ServerDisconnect,
            GetUserList,
            AutoMatching,
            ServerBeginGame,
        }

        private static readonly Dictionary<ChatCommand, string> commandMap = new Dictionary<ChatCommand, string>
        {
            { ChatCommand.Move, "MV#*" },
            { ChatCommand.EndGame, "ED#*" },
            { ChatCommand.Rematch, "RSTR#*" },
            { ChatCommand.TimeSync, "TSync#*" },
            { ChatCommand.ServerCreateRoom, "SCRR#*" },
            { ChatCommand.ClientLeaveRoom, "CLRR#*" },
            { ChatCommand.ClientDisconnect, "CDIS#*" },
            { ChatCommand.ServerDisconnect, "SDIS#*" },
            { ChatCommand.GetUserList, "USER_LIST#*" },
            { ChatCommand.AutoMatching, "AUTO_MATCH#*" },
            { ChatCommand.ServerBeginGame, "SBG#*" },
        };

        public static string ToString(this ChatCommand command)
        {
            return commandMap[command];
        }
    }
}

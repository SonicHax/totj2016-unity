using System;
using System.Collections.Generic;
using System.Text;

    public class RomOLD
    {
        public int roomID;
        public string name;
        public string active;
        public int players;
        public int host;

        public RomOLD(string n, string a, int p, int h){
            this.name = n;
            this.active = "false";
            this.players = p;
            this.host = h;
        }

        public RomOLD()
        {
            this.roomID = RoomState.roomID;
            this.name = RoomState.name;
            this.active = RoomState.active;
            this.players = RoomState.players;
            this.host = RoomState.host;
        }

        public void RoomToRoomState()
        {
            RoomState.roomID = this.roomID;
            RoomState.name = this.name;
            RoomState.active = this.active;
            RoomState.players = this.players;
            RoomState.host = this.host;
        }

    }
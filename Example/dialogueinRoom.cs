using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureChat.Example
{
    public class dialogueinRoom
    {
        public static string room_name;
        public static void Hook()
        {
            On.Player.Update += Player_Update;
        }

        private static void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig.Invoke(self,eu);
            if (room_name != self.room.abstractRoom.name)
            {
                if (self.room.abstractRoom.name == "SU_A41")
                {
                    Plugin.Log("Enter the room: SU_A41");
                    new CreatureChatTx(self.room, 0, null, "I enter the room! this is a Text!!!");
                }
            room_name = self.room.abstractRoom.name;
            }
        }
    }
}

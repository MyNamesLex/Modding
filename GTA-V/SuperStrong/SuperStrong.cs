using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using System.Windows.Forms;

namespace SuperStrong
{
    public class SuperStrong : Script
    {
        public SuperStrong()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        public void OnTick(object sender, EventArgs e)
        {
            Entity[] entitys = World.GetNearbyEntities(Game.Player.Character.Position, 999);

            for (int i = 0; i < entitys.Length; i++)
            {
                if (entitys[i].HasBeenDamagedBy(Game.Player.Character))
                {
                    Entity entity = entitys[i];
                    entity.ApplyForce(Game.Player.Character.ForwardVector * 99);
                }
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

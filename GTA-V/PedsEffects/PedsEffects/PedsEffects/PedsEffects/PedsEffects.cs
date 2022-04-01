using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GTA;
using GTA.Math;

namespace PedsEffects
{
    public class PedsEffects : Script
    {

        public bool PressedY = false; // Toggle Push All Peds
        public bool PressedZ = false; // give all peds axe and go to player toggle
        public bool PressedJ = false; // all peds attack player

        public PedsEffects()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        public void OnTick(object sender, EventArgs e)
        {
            Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 9999);

            foreach (Ped p in nearbyPeds)
            {
                if (PressedY == true) // push peds
                {
                    p.ApplyForce((Game.Player.Character.ForwardVector * 9999) + (Game.Player.Character.UpVector * 9999));
                }
                else
                {

                }

                if (PressedZ == true) // give battleaxe and go to player
                {
                    p.Weapons.Give(WeaponHash.BattleAxe, 1, true, true);
                    p.Task.GoTo(Game.Player.Character);
                    p.AlwaysKeepTask = true;
                }
                else
                {

                }

                if (PressedJ == true) // all peds attack player
                {
                    p.Weapons.Give(WeaponHash.AssaultRifle, 1, true, true);
                    p.Task.FightAgainst(Game.Player.Character);
                    p.AlwaysKeepTask = true;
                    p.ShootRate = 500;
                }
                else
                {

                }
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J)
            {
                if (PressedJ == false)
                {
                    PressedJ = true;
                }
                else
                {
                    PressedJ = false;
                }
            }
            if (e.KeyCode == Keys.Y)
            {
                if (PressedY == false)
                {
                    PressedY = true;
                }
                else
                {
                    PressedY = false;
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                if (PressedZ == false)
                {
                    PressedZ = true;
                }
                else
                {
                    PressedZ = false;
                }
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

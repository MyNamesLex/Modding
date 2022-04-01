using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using GTA.NaturalMotion;
using GTA.Native;
using System.Windows.Forms;
using System.Drawing;

namespace CarsFlyMod
{
    public class CarsMod : Script
    {

        public bool PressedE = false; // Toggle Car Pull
        public bool PressedT = false; // Toggle Car Push

        public CarsMod()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        public void OnTick(object sender, EventArgs e)
        {
            Vehicle[] nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 1000);

            //vehicle effects

            foreach (Vehicle v in nearbyCars)
            {
                if (PressedE == true) // pull cars
                {
                    Vector3 distancetoplayer = Game.Player.Character.Position - v.Position;
                    v.ApplyForce(distancetoplayer * 10);
                }

                else
                {

                }

                if (PressedT == true) // push cars
                {
                    v.ApplyForce((Game.Player.Character.ForwardVector * 10) + (Game.Player.Character.UpVector * 10));
                }

                else
                {

                }
            }
        }

        public void PushCars()
        {
            Vehicle[] nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 1000);
            foreach (Vehicle v in nearbyCars)
            {
                v.ApplyForce((Game.Player.Character.ForwardVector * 10) + (Game.Player.Character.UpVector * 10));
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            //button toggles

            if (e.KeyCode == Keys.E)
            {
                if (PressedE == false)
                {
                    PressedE = true;
                }
                else
                {
                    PressedE = false;
                }
            }
            if(e.KeyCode == Keys.T)
            {
                if (PressedT == false)
                {
                    PressedT = true;
                }
                else
                {
                    PressedT = false;
                }
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

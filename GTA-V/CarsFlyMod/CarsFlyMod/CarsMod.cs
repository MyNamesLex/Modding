using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using GTA.Native;
//using NativeUI;
using System.Windows.Forms;
using System.Drawing;

namespace CarsFlyMod
{
    class CarsMod : Script
    {
        // NativeUI namespace couldnt be found?

        //public MenuPool modMenuPool;
        //public UIMenu mainMenu;


        public bool PressedE = false; // Toggle Car Pull
        public bool PressedT = false; // Toggle Car Push
        public bool PressedY = false; // Toggle Push All Peds
        public bool PressedZ = false; // give all peds axe and go to player toggle
        public bool PressedJ = false; // all peds attack player
        public CarsMod()
        {
            /*
            modMenuPool = new MenuPool();
            mainMenu = new UIMenu("Mod Menu", "Select an option!");
            modMenuPool.Add(mainMenu);
            */

            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }
        public void OnTick(object sender, EventArgs e)
        {
            //menu
            /*
            if(modMenuPool != null)
            {
                modMenuPool.ProcessMenus();
            }
            */


            //get nearby peds and cars

            Vehicle[] nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 1000);
            Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 9999);


            //vehicle effects

            foreach(Vehicle v in nearbyCars)
            {
                if (PressedE == true) // pull cars
                {
                        Vector3 distancetoplayer = Game.Player.Character.Position - v.Position;
                        v.ApplyForce(distancetoplayer * 10);
                }

                else
                {

                }
                
                if(PressedT == true) // push cars
                {
                    v.ApplyForce((Game.Player.Character.ForwardVector * 10) + (Game.Player.Character.UpVector * 10));
                }

                else
                {

                }
            }

            //Ped effects

            foreach(Ped p in nearbyPeds)
            {
                if (PressedY == true) // push peds
                {
                    if (p.IsInVehicle())
                    {
                        p.Task.WarpOutOfVehicle(p.CurrentVehicle);
                    }
                    else
                    {
                        p.ApplyForce((Game.Player.Character.ForwardVector * 9999) + (Game.Player.Character.UpVector * 9999));
                    }
                }
                else
                {

                }

                if(PressedZ == true) // give battleaxe and go to player
                {
                    p.Weapons.Give(WeaponHash.BattleAxe, 1, true, true);
                    if (p.IsInVehicle())
                    {
                        p.Task.WarpOutOfVehicle(p.CurrentVehicle);
                    }
                    else
                    {
                        p.Task.GoTo(Game.Player.Character);
                    }
                }
                else
                {
                    
                }

                if(PressedJ == true) // all peds attack player
                {
                    if(p.IsInVehicle())
                    {
                        p.Task.FightAgainst(Game.Player.Character);
                    }
                    p.Weapons.Give(WeaponHash.Pistol, 1, true, true);
                    p.Task.FightAgainst(Game.Player.Character);
                }
                else
                {
                    p.Task.WanderAround();
                }
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            // call menu
            /*
            if(e.KeyCode == Keys.F10 && !modMenuPool.IsAnyMenuOpen())
            {
                mainMenu.Visible = !mainMenu.Visible;
            }
            */

            //button toggles

            if(e.KeyCode == Keys.E)
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

            if(e.KeyCode == Keys.Y)
            {
                if(PressedY == false)
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

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

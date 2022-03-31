using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using GTA.NaturalMotion;
using GTA.Native;
using NativeUI;
using System.Windows.Forms;
using System.Drawing;

namespace CarsFlyMod
{
    public class CarsMod : Script
    {
        MenuPool menuPool;
        UIMenu modMenu;
        UIMenuItem PushCarsItem;
        public bool PressedE = false; // Toggle Car Pull
        public bool PressedT = false; // Toggle Car Push
        public bool PressedY = false; // Toggle Push All Peds
        public bool PressedZ = false; // give all peds axe and go to player toggle
        public bool PressedJ = false; // all peds attack player
        public bool PressedL = false; // everything invisible
        public CarsMod()
        {
            /*
            modMenu = new UIMenu("Mod Menu", "Test");
            menuPool.Add(modMenu);

            PushCarsItem = new UIMenuItem("Push Cars", "Pushes Cars In Direction Your Facing");
            modMenu.AddItem(PushCarsItem);
            */
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
           // menuPool = new MenuPool();
            //modMenu.OnItemSelect += ItemSelecterEvent;
        }

        void ItemSelecterEvent(UIMenu sender, UIMenuItem item, int index)
        {
            if(item == PushCarsItem)
            {
                PushCars();
            }
        }

        public void OnTick(object sender, EventArgs e)
        {

            if(menuPool != null)
            {
                menuPool.ProcessMenus();
            }

            Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 9999);
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

                if(PressedL == true) // invisible
                {
                    v.Opacity = 0;
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
                    p.ApplyForce((Game.Player.Character.ForwardVector * 9999) + (Game.Player.Character.UpVector * 9999));
                }
                else
                {

                }

                if(PressedZ == true) // give battleaxe and go to player
                {
                    p.Weapons.Give(WeaponHash.BattleAxe, 1, true, true);
                    p.Task.GoTo(Game.Player.Character);
                    p.AlwaysKeepTask = true;
                }
                else
                {

                }

                if(PressedJ == true) // all peds attack player
                {
                    p.Weapons.Give(WeaponHash.AssaultRifle, 1, true, true);
                    p.Task.FightAgainst(Game.Player.Character);
                    p.AlwaysKeepTask = true;
                    p.ShootRate = 500;
                }
                else
                {

                }

                if (PressedL == true) // invisible
                {
                    p.Opacity = 0;
                    if(Game.Player.Character.IsInVehicle())
                    {
                        Game.Player.Character.CurrentVehicle.Opacity = 0;
                    }
                }
                else
                {

                }
            }

            // player impact
            if(PressedL == true)
            {
                Game.Player.Character.Opacity = 0;
            }
        }

        public void PushCars()
        {
          //  Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 9999);
            Vehicle[] nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 1000);
            foreach (Vehicle v in nearbyCars)
            {
                v.ApplyForce((Game.Player.Character.ForwardVector * 10) + (Game.Player.Character.UpVector * 10));
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 9999);
            Vehicle[] nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 1000);

            if(e.KeyCode == Keys.F10)
            {
                modMenu.Visible = !modMenu.Visible;
            }

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
                    foreach (Ped p in nearbyPeds)
                    {
                        p.Task.WanderAround();
                    }
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
                    foreach (Ped p in nearbyPeds)
                    {
                        p.Task.WanderAround();
                    }
                    PressedJ = false;
                }
            }
            if(e.KeyCode == Keys.L)
            {
                if(PressedL == false)
                {
                    PressedL = true;
                }
                else
                {
                    foreach (Ped p in nearbyPeds)
                    {
                        p.ResetOpacity();
                    }
                    foreach (Vehicle v in nearbyCars)
                    {
                        v.ResetOpacity();
                    }
                    if (Game.Player.Character.IsInVehicle())
                    {
                        Game.Player.Character.CurrentVehicle.ResetOpacity();
                    }
                    Game.Player.Character.ResetOpacity();
                    PressedL = false;
                }
            }

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

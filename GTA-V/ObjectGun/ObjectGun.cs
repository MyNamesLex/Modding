using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using System.Windows.Forms;
using System.Drawing;

namespace ObjectGun
{
    public class ObjectGun : Script
    {
        public bool StartBool = false;
        public bool CarOnlyMode = false;
        public bool EntityOnlyMode = false;
        public bool AllGunsMode = false;
        public bool AllPedsObjectMode = false;
        public List<Entity> entities;
        public List<Vehicle> veh;
        public ObjectGun()
        {
            this.Tick += onTick;
            this.KeyUp += onKeyUp;
            this.KeyDown += onKeyDown;
        }

        public void Start()
        {
            StartBool = true;
        }

        public void onTick(object sender, EventArgs e)
        {
            entities = World.GetNearbyEntities(Game.Player.Character.Position, 999999).ToList();
            veh = World.GetNearbyVehicles(Game.Player.Character, 999999).ToList();

            if (StartBool == false)
            {
                Start();
            }

            if (AllGunsMode == false)
            {
                if (Game.Player.Character.IsShooting && Game.Player.Character.Weapons.Current == WeaponHash.Pistol)
                {
                    ObjectFire();
                }
            }
            else if (AllGunsMode == true)
            {
                if (Game.Player.Character.IsShooting)
                {
                    ObjectFire();
                }
            }

            if (AllPedsObjectMode == true)
            {
                Ped[] allPeds = World.GetAllPeds();

                foreach (Ped p in allPeds)
                {
                    if (p.IsShooting)
                    {
                        Ped currentped = p;
                        PedObjectFire(currentped);
                    }
                }
            }
        }

        public void PedObjectFire(Ped p)
        {
            Random r = new Random();
            int rng = r.Next(0, 2);

            if (CarOnlyMode == true)
            {
                rng = 1;
            }

            if (EntityOnlyMode == true)
            {
                rng = 0;
            }

            if (rng == 0)
            {
                int rngE = r.Next(0, entities.Count);
                Entity selectedEntity = entities[rngE];
                selectedEntity = World.CreateProp(selectedEntity.Model, p.Position + p.ForwardVector * 5, true, false);
                selectedEntity.MarkAsNoLongerNeeded();
                Vector3 push = (p.ForwardVector * 9999);
                selectedEntity.ApplyForce(push);
            }

            else
            {
                int rngV = r.Next(0, veh.Count);
                Model model = veh[rngV].Model;
                Vehicle selectedVehicle = World.CreateVehicle(model, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 5);
                Vector3 push = (GameplayCamera.ForwardVector * 9999);
               // selectedVehicle.MarkAsNoLongerNeeded();
            }

        }

        public void ObjectFire()
        {

            Random r = new Random();
            int rng = r.Next(0, 2);

            if (CarOnlyMode == true)
            {
                rng = 1;
            }

            if (EntityOnlyMode == true)
            {
                rng = 0;
            }

            if (rng == 0)
            {
                int rngE = r.Next(0, entities.Count);
                Entity selectedEntity = entities[rngE];
                selectedEntity = World.CreateProp(selectedEntity.Model, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 5, true, false);
                selectedEntity.MarkAsNoLongerNeeded();
                Vector3 push = (GameplayCamera.ForwardVector * 9999);
                selectedEntity.ApplyForce(push);
            }

            else
            {
                int rngV = r.Next(0, veh.Count);
                Model model = veh[rngV].Model;
                Vehicle selectedVehicle = World.CreateVehicle(model, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 5);
                Vector3 push = (GameplayCamera.ForwardVector * 9999);
                //selectedVehicle.MarkAsNoLongerNeeded();
                //selectedVehicle.ApplyForce(push);

            }


        }
        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                if (AllGunsMode == true)
                {
                    AllGunsMode = false;
                }
                else
                {
                    AllGunsMode = true;
                }
            }

            if (e.KeyCode == Keys.C)
            {
                if (CarOnlyMode == true)
                {
                    CarOnlyMode = false;
                }
                else
                {
                    CarOnlyMode = true;
                    EntityOnlyMode = false;
                }
            }

            if (e.KeyCode == Keys.E)
            {
                if (EntityOnlyMode == true)
                {
                    EntityOnlyMode = false;
                }
                else
                {
                    CarOnlyMode = false;
                    EntityOnlyMode = true;
                }
            }

            if (e.KeyCode == Keys.End)
            {
                if (AllPedsObjectMode == true)
                {
                    AllPedsObjectMode = false;
                }
                else
                {
                    AllPedsObjectMode = true;
                }
            }
        }
    }
}

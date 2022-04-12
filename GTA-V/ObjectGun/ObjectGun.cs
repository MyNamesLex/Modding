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
            Entity[] entities = World.GetAllEntities();
            Vehicle[] veh = World.GetAllVehicles();

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
                int rngE = r.Next(0, entities.Length);
                Entity selectedEntity = entities[rngE];
                selectedEntity = World.CreateProp(selectedEntity.Model, p.Position + p.ForwardVector * 5, true, false);
                selectedEntity.MarkAsNoLongerNeeded();
                Vector3 push = (p.ForwardVector * 9999);
                selectedEntity.ApplyForce(push);
            }

            else
            {
                int rngV = r.Next(0, veh.Length);
                Vehicle selectedVehicle = veh[rngV];
                selectedVehicle = World.CreateVehicle(selectedVehicle.Model, p.Position + p.ForwardVector * 5);
                selectedVehicle.MarkAsNoLongerNeeded();
                Vector3 push = (p.ForwardVector * 9999);
                selectedVehicle.ApplyForce(push);
            }
        }

        public void ObjectFire()
        {
            Entity[] entities = World.GetAllEntities();
            Vehicle[] veh = World.GetAllVehicles();

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
                int rngE = r.Next(0, entities.Length);
                Entity selectedEntity = entities[rngE];
                selectedEntity = World.CreateProp(selectedEntity.Model, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 5, true, false);
                selectedEntity.MarkAsNoLongerNeeded();
                Vector3 push = (GameplayCamera.ForwardVector * 9999);
                selectedEntity.ApplyForce(push);
            }

            else
            {
                int rngV = r.Next(0, veh.Length);
                Vehicle selectedVehicle = veh[rngV];
                selectedVehicle = World.CreateVehicle(selectedVehicle.Model, Game.Player.Character.Position + Game.Player.Character.ForwardVector * 5);
                selectedVehicle.MarkAsNoLongerNeeded();
                Vector3 push = (GameplayCamera.ForwardVector * 9999);
                selectedVehicle.ApplyForce(push);
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

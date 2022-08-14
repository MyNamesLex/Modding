using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using GTA;
using GTA.Math;

namespace WorstDrivingExperience
{
    public class WorstDrivingExperience : Script
    {
        public Stopwatch timer;
        public bool StartBool = false;
        public WorstDrivingExperience()
        {
            Tick += onTick;
            KeyUp += onKeyUp;
            KeyDown += onKeyDown;
        }

        public void Start()
        {
            StartBool = true;
            timer = new Stopwatch();
            timer.Start();
        }

        public void ResetTimer()
        {
            NudgeVehicles();
            timer.Restart();
        }

        public void NudgeVehicles()
        {
            Vehicle[] allVehs = World.GetNearbyVehicles(Game.Player.Character, 1000);

            foreach(Vehicle v in allVehs)
            {
                Random rx = new Random();
                int rotx = rx.Next(-0, 0);
                Random ry = new Random();
                int roty = ry.Next(-0, 0);
                Random rz = new Random();
                int rotz = rz.Next(-0, 0);

                Random fx = new Random();
                int forcex = fx.Next(-2, 2);
                Random fy = new Random();
                int forcey = fy.Next(-0, 0);
                Random fz = new Random();
                int forcez = fz.Next(-2, 2);

                Vector3 Force = new Vector3(forcex, forcey, forcez);
                Vector3 Rot = new Vector3(rotx, roty, rotz);

                if (v != null)
                {
                    v.ApplyForce(Force, Rot, ForceType.ForceRotPlusForce);
                }
            }
        }

        public void onTick(object sender, EventArgs e)
        {
            if(StartBool == false)
            {
                Start();
            }

            if (Game.Player.Character.CurrentVehicle != null)
            {
                Vehicle veh = Game.Player.Character.CurrentVehicle;
                veh.MaxSpeed = 30;

                if (veh.IsDamaged)
                {
                    veh.Explode();
                }
            }

            if (Game.Player.Character.Health < Game.Player.Character.MaxHealth)
            {
                Game.Player.Character.Kill();
            }

            Ped[] allPeds = World.GetNearbyPeds(Game.Player.Character, 1000);
            Vehicle[] allVehs = World.GetNearbyVehicles(Game.Player.Character, 1000);

            foreach (Ped p in allPeds)
            {
                p.RelationshipGroup.SetRelationshipBetweenGroups(Game.Player.Character.RelationshipGroup, Relationship.Hate);
                p.DrivingStyle = DrivingStyle.Rushed;

                if(p.IsInVehicle() == false && p.LastVehicle != null)
                {
                    p.LastVehicle.IsDriveable = true;
                    p.SetIntoVehicle(p.LastVehicle, VehicleSeat.Driver);
                }

                if(p.HasBeenDamagedByAnyWeapon())
                {
                    p.Kill();
                }
            }

            foreach (Vehicle v in allVehs)
            {
                if (v.IsDamaged)
                {
                    v.Explode();
                }
            }

            if (timer.Elapsed.TotalSeconds >= 5)
            {
                ResetTimer();
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

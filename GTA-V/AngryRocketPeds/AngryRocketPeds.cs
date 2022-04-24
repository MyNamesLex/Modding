using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using GTA;

namespace AngryRocketPeds
{
    public class AngryRocketPeds : Script
    {
        public Stopwatch timer;
        public TimeSpan ts;

        public bool StartBool = false;
        public bool AngryPeds = false;

        public int RandomDuration;
        public AngryRocketPeds()
        {
            this.Tick += onTick;
            this.KeyUp += onKeyUp;
            this.KeyDown += onKeyDown;
        }

        public void Start()
        {
            StartBool = true;
            timer = new Stopwatch();
            ts = new TimeSpan();
            timer.Start();
            GenerateRandomDuration();
            return;
        }

        public void onTick(object sender, EventArgs e)
        {
            Game.Player.WantedLevel = 0;
            if (StartBool == false)
            {
                Start();
                return;
            }
            else
            {
                if (AngryPeds)
                {
                    MakePedsAngry();
                }

                Timer();
            }
        }

        public void Timer()
        {
            ts = timer.Elapsed;
            if (ts.TotalSeconds >= RandomDuration)
            {
                if (AngryPeds == false)
                {
                    AngryPeds = true;
                    ResetTimer();
                    return;
                }
                else if (AngryPeds == true)
                {
                    AngryPeds = false;
                    MakePedsRelax();
                    ResetTimer();
                    return;
                }
            }
        }

        public void MakePedsAngry()
        {
            Ped[] p = World.GetNearbyPeds(Game.Player.Character.Position, 999);

            foreach(Ped t in p)
            {
                if (t == Game.Player.Character)
                {

                }
                else
                {
                    t.Weapons.Give(WeaponHash.RPG, 999999, true, true);

                    if(t.IsInVehicle())
                    {
                        t.Task.LeaveVehicle();
                    }

                    t.ShootRate = 999999999;
                    t.Task.FightAgainst(Game.Player.Character);
                }
            }
        }

        public void MakePedsRelax()
        {
            Ped[] p = World.GetNearbyPeds(Game.Player.Character.Position, 999);

            foreach (Ped t in p)
            {
                if (t == Game.Player.Character)
                {

                }
                else
                {
                    t.Task.FleeFrom(Game.Player.Character);
                }
            }
        }

        public void ResetTimer()
        {
            timer.Restart();
            GenerateRandomDuration();
        }

        public void GenerateRandomDuration()
        {
            Random r = new Random();
            RandomDuration = r.Next(1,60);
        }


        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

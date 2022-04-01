using GTA;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace InvisTimer
{
    public class InvisTimer : Script
    {
        public Stopwatch timer;
        public TimeSpan ts;
        public Ped[] nearbyPeds;
        public Vehicle[] nearbyCars;

        public bool IsInvis = false;
        public bool StartBool = false;
        public bool TriggeredStart = false;
        public InvisTimer()
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
            return;
        }

        public void onTick(object sender, EventArgs e)
        {
            if (StartBool == false)
            {
                Start();
                return;
            }
            else
            {
                if (TriggeredStart == true)
                {
                    Timer();
                    ts = timer.Elapsed;

                    nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 9999);
                    nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 1000);

                    if (IsInvis == false)
                    {
                        InvisEverything(nearbyCars, nearbyPeds);
                    }
                    else
                    {
                        ShowEverything(nearbyCars, nearbyPeds);
                    }
                }
            }
        }

        public void Timer()
        {
            if (ts.TotalMilliseconds >= 5000 && TriggeredStart == true)
            {
                if (IsInvis == false)
                {
                    IsInvis = true;
                    ResetTimer();
                    return;
                }
                else if (IsInvis == true)
                {
                    IsInvis = false;
                    ResetTimer();
                    return;
                }
            }
        }

        public void InvisEverything(Vehicle[] nearbyCars, Ped[] nearbyPeds)
        {
            Game.Player.Character.Opacity = 0;
            foreach (Vehicle v in nearbyCars)
            {
                v.Opacity = 0;
            }
            foreach (Ped p in nearbyPeds)
            {
                p.Opacity = 0;
                if (p.IsInVehicle())
                {
                    p.CurrentVehicle.Opacity = 0;
                }
            }
        }

        public void ShowEverything(Vehicle[] nearbyCars, Ped[] nearbyPeds)
        {
            Game.Player.Character.ResetOpacity();
            foreach (Vehicle v in nearbyCars)
            {
                v.ResetOpacity();
            }
            foreach (Ped p in nearbyPeds)
            {
                p.ResetOpacity();
                if (p.IsInVehicle())
                {
                    p.CurrentVehicle.ResetOpacity();
                }
            }
        }

        public void ResetTimer()
        {
            timer.Restart();
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                if (timer.IsRunning)
                {
                    timer.Stop();
                    ShowEverything(nearbyCars, nearbyPeds);
                }

                timer = new Stopwatch();
                timer.Start();

                if (TriggeredStart == false)
                {
                    TriggeredStart = true;
                    return;
                }
                if (TriggeredStart == true)
                {
                    TriggeredStart = false;
                    return;
                }
            }
        }
    }
}

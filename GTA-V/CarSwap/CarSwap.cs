using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using GTA.Math;

namespace CarSwap
{
    public class CarSwap : Script
    {
        public Stopwatch timer;
        public TimeSpan ts;
        public float TotalSecondThreshold;

        public bool StartBool = false;
        public CarSwap()
        {
            Tick += OnTick;
        }

        public void Start()
        {
            StartBool = true;
            timer = new Stopwatch();
            ts = new TimeSpan();
            TotalSecondThreshold = 60;
            timer.Start();
            return;
        }

        public void OnTick(object sender, EventArgs e)
        {
            if (StartBool == false)
            {
                Start();
                return;
            }

            if (Game.Player.Character.IsInVehicle())
            {
                Timer();
                ts = timer.Elapsed;
            }
        }

        public void Timer()
        {
            if (ts.TotalSeconds >= TotalSecondThreshold)
            {
                Vehicle[] nearbyCars = World.GetNearbyVehicles(Game.Player.Character, 9999);

                Random r = new Random();
                int rng = r.Next(0, nearbyCars.Length);

                Vehicle Current = Game.Player.Character.CurrentVehicle;
                Vehicle GetCar = nearbyCars[rng];

                Vector3 pos = Game.Player.Character.Position;
                Vector3 rot = Game.Player.Character.Rotation;
                Vector3 vel = Game.Player.Character.Velocity;

                Ped[] pedsInCar = Game.Player.Character.CurrentVehicle.Passengers;

                Current.Delete();

                GetCar.Rotation = rot;
                GetCar.Position = pos;
                GetCar.Velocity = vel;
                GetCar.LockStatus = VehicleLockStatus.Unlocked;

                Game.Player.Character.SetIntoVehicle(GetCar, VehicleSeat.Driver);

                for (int i = 0; i < pedsInCar.Length; i++)
                {
                    pedsInCar[i].SetIntoVehicle(GetCar, VehicleSeat.Any);
                }

                ResetTimer();
            }
        }

        public void ResetTimer()
        {
            Random r = new Random();
            int rng = r.Next(10, 60);
            TotalSecondThreshold = rng;
            timer.Restart();
        }
    }
}

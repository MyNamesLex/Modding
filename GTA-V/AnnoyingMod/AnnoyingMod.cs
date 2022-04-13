using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using GTA;
using System.Speech.Synthesis;

namespace AnnoyingMod
{
    public class AnnoyingMod : Script
    {
        public Stopwatch timer;
        public TimeSpan ts;
        public SpeechSynthesizer speech;

        public bool StartBool = false;

        // CURRENT EFFECTS TRACKER //

        public bool Invis = false;
        public bool ChangedGravity = false;
        public bool TTS = false;


        // EFFECTS VARIABLES //

        public float DefaultGravity;
        public AnnoyingMod()
        {
            Tick += onTick;
            KeyUp += onKeyUp;
            KeyDown += onKeyDown;
        }

        public void Start()
        {
            StartBool = true;
            timer = new Stopwatch();
            ts = new TimeSpan();
            timer.Start();

            speech = new SpeechSynthesizer
            {
                Volume = 100,
                Rate = 2
            };

            DefaultGravity = World.GravityLevel;

            return;
        }


        public void onTick(object sender, EventArgs e)
        {
            if (StartBool == false)
            {
                Start();
                return;
            }

            Timer();
            ts = timer.Elapsed;

            // FUNCTIONS THAT REQUIRE RUNNING EVERY FRAME //

            if (TTS == true)
            {
                TTSFunction();
            }
            if (Invis == true)
            {
                InvisEverything();
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void Timer()
        {
            if (ts.TotalSeconds >= 20)
            {
                Effects();
                timer.Restart();
            }
        }

        // EFFECT MANAGER FUNCTIONS //

        public void Effects()
        {
            Random r = new Random();
            int rng = r.Next(1, 3);

            if (ActiveEffects() == false)
            {
                switch (rng)
                {
                    case 1:
                        InvisEverything();
                        break;
                    case 2:
                        ChangeGravity();
                        break;
                    case 3:
                        TTSEnable();
                        break;
                }
            }
            else
            {
                ResetEffects();
            }
        }

        public bool ActiveEffects()
        {
            if(TTS)
            {
                return true;
            }
            if (ChangedGravity)
            {
                return true;
            }
            if(Invis)
            {
                return true;
            }
            return false;
        }

        public void ResetEffects()
        {
            if(Invis == true)
            {
                ShowEverything();
            }

            if(ChangedGravity == true)
            {
                ResetGravity();
            }

            if(TTS == true)
            {
                TTSDisable();
            }
        }

        // INDIVIDUAL EFFECTS //

        public void InvisEverything()
        {
            Invis = true;

            Ped[] allPeds = World.GetNearbyPeds(Game.Player.Character, 9999);
            Entity[] allEntity = World.GetNearbyEntities(Game.Player.Character.Position, 9999);
            Vehicle[] allVehicles = World.GetNearbyVehicles(Game.Player.Character.Position, 9999);
            Game.Player.Character.Opacity = 0;

            foreach (Ped p in allPeds)
            {
                p.Opacity = 0;
                if (p.IsInVehicle())
                {
                    p.CurrentVehicle.Opacity = 0;
                    p.Opacity = 0;
                }
            }

            foreach (Entity e in allEntity)
            {
                e.Opacity = 0;
            }

            foreach (Vehicle v in allVehicles)
            {
                v.Opacity = 0;
            }
        }

        public void ShowEverything()
        {
            Invis = false;

            Ped[] allPeds = World.GetNearbyPeds(Game.Player.Character, 9999);
            Entity[] allEntity = World.GetNearbyEntities(Game.Player.Character.Position, 9999);
            Vehicle[] allVehicles = World.GetNearbyVehicles(Game.Player.Character.Position, 9999);
            Game.Player.Character.ResetOpacity();

            foreach (Ped p in allPeds)
            {
                p.ResetOpacity();
                if(p.IsInVehicle())
                {
                    p.CurrentVehicle.ResetOpacity();
                }
            }

            foreach (Entity e in allEntity)
            {
                e.ResetOpacity();
            }

            foreach (Vehicle v in allVehicles)
            {
                v.ResetOpacity();
            }
        }

        public void ChangeGravity()
        {
            ChangedGravity = true;

            Random r = new Random();
            int rng = r.Next(1, 3);

            switch(rng)
            {
                case 1:
                    World.GravityLevel = 9999;
                    break;
                case 2:
                    World.GravityLevel = 0;
                    break;
                case 3:
                    World.GravityLevel = -5;
                    break;
            }
        }

        public void ResetGravity()
        {
            ChangedGravity = false;

            World.GravityLevel = DefaultGravity;
        }

        public void TTSEnable()
        {
            TTS = true;
        }

        public void TTSFunction()
        {
            Entity[] allPeds = World.GetNearbyPeds(Game.Player.Character, 9999);

            foreach (Ped p in allPeds)
            {
                if (p.IsShooting)
                {
                    speech.SpeakAsync("enemy fired :(");
                }
            }

            if (Game.Player.Character.IsShooting)
            {
                speech.SpeakAsync("you shot :o");
            }

            if (Game.Player.Character.IsBeingJacked)
            {
                speech.SpeakAsync("someone is stealing your car!!!");
            }

            if (Game.Player.Character.IsClimbing)
            {
                speech.SpeakAsync("your climbing");
            }
        }

        public void TTSDisable()
        {
            TTS = false;
        }
    }
}

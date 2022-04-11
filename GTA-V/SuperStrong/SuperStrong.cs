using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using System.Windows.Forms;
using System.Diagnostics;

namespace SuperStrong
{
    public class SuperStrong : Script
    {
        public bool StartBool = false;
        public Stopwatch timer;
        public TimeSpan ts;
        public SuperStrong()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        public void Start()
        {
            StartBool = true;
            timer = new Stopwatch();
            ts = new TimeSpan();
            return;
        }

        public void OnTick(object sender, EventArgs e)
        {
            if (StartBool == false)
            {
                Start();
                return;
            }
            else
            {
                ts = timer.Elapsed;
                Entity[] entitys = World.GetNearbyEntities(Game.Player.Character.Position, 5);

                for (int i = 0; i < entitys.Length; i++)
                {
                    if (entitys[i].HasBeenDamagedBy(Game.Player.Character))
                    {
                        if (entitys[i].HasBeenDamagedByAnyMeleeWeapon() == true
                            && Game.Player.Character.Weapons.Current == WeaponHash.Unarmed
                            && Game.Player.Character.IsInMeleeCombat == true)
                        {
                            Entity entity = entitys[i];
                            if (entity.IsInAir)
                            {

                            }
                            else
                            {
                                entity.ApplyForce(Game.Player.Character.ForwardVector * 500);
                            }
                        }
                    }
                }
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using ThoriumMod.Items.Titan;
using ThoriumMod.Projectiles.Healer;
using ThoriumMod.Projectiles.Minions;
using ThoriumMod.Projectiles.Pets;
using btestmod.ModCompatibilities;
using btestmod.Items;
using Terraria.Utilities;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;

namespace btestmod
{
    internal class bPlayer : ModPlayer
    {
        public bool godSlayer;
        public bool godSlayerCooldown;
        public bool godSlayerActive;
        public bool RecordScratch = false;

        public override void ResetEffects()
        {
            godSlayer = false;
            godSlayerCooldown = false;
            RecordScratch = false;
        }

        /*public override bool PreKill(
          double damage,
          int hitDirection,
          bool pvp,
          ref bool playSound,
          ref bool genGore,
          ref PlayerDeathReason damageSource)
        {
            Mod mod = Terraria.ModLoader.ModLoader.GetMod("btestmod");
            if (godSlayer && !godSlayerCooldown)
            {
                int num1 = 150;
                Player player1 = player;
                player1.statLife = (player1.statLife + num1);
                //player1.HealEffect(num1, true);
                //if (player1.statLife > player1.statLifeMax2)
                //    player1.statLife = player1.statLifeMax2;
                player1.AddBuff(mod.BuffType("GodSlayerCooldown"), 2700, true);
            }
            return false;
            Mod mod = Terraria.ModLoader.ModLoader.GetMod("btestmod");
            if (godSlayer && !godSlayerCooldown)
            {
                player.AddBuff(mod.BuffType("GodSlayerCooldown"), 2700, true);
                player.statLife = 150;
                player.HealEffect(150, true);
            }
            return false;
        }*/
    }
}
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

namespace btestmod
{
    internal class btestmod : Mod
    {
        internal static object MiscHelper;
        internal static btestmod Instance;

        public btestmod()
        {
        }

        public override void Load()
        {
            btestmod.Instance = this;
        }

        internal CalamityCompatibility CalamityCompatibility { get; private set; }

        internal bool CalamityLoaded => this.CalamityCompatibility != null;

        internal ThoriumCompatibility ThoriumCompatibility { get; private set; }

        internal bool ThoriumLoaded => this.ThoriumCompatibility != null;

        internal RedemptionCompatibility RedemptionCompatibility { get; private set; }

        internal bool RedemptionLoaded => this.RedemptionCompatibility != null;
    }
}
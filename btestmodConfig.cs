using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace btestmod
{
    [Label("Config")]
    [BackgroundColor(49, 32, 36, 216)]
    public class btestmodConfig : ModConfig
    {
        public static btestmodConfig Instance;
        private const float MinCBossHealthBoost = 0.0f;
        private const float MaxCBossHealthBoost = 900f;
        private const float MinTBossHealthBoost = 0.0f;
        private const float MaxTBossHealthBoost = 900f;

        public override ConfigScope Mode => (ConfigScope)1;

        [OnDeserialized]
        internal void ClampValues(StreamingContext context)
        {
            this.CBossHealthBoost = (float)Utils.Clamp((double)this.CBossHealthBoost, 0.0, 900.0);
            this.TBossHealthBoost = (float)Utils.Clamp((double)this.TBossHealthBoost, 0.0, 900.0);
        }

        [Label("Calamity Boss Health Percentage Boost")]
        [BackgroundColor(192, 54, 64, 192)]
        [SliderColor(224, 165, 56, 128)]
        [Range(0.0f, 900f)]
        [Increment(50f)]
        [DrawTicks]
        [DefaultValue(0.0f)]
        [Tooltip("Globally boosts the health of all Calamity bosses.\nDoes not affect bosses that are already spawned.")]
        public float CBossHealthBoost { get; set; }

        [Label("Thorium Boss Health Percentage Boost")]
        [BackgroundColor(192, 54, 64, 192)]
        [SliderColor(224, 165, 56, 128)]
        [Range(0.0f, 900f)]
        [Increment(50f)]
        [DrawTicks]
        [DefaultValue(0.0f)]
        [Tooltip("Globally boosts the health of all Thorium bosses.\nDoes not affect bosses that are already spawned.")]
        public float TBossHealthBoost { get; set; }

        public override bool AcceptClientChanges(
        ModConfig pendingConfig,
        int whoAmI,
        ref string message) => true;
    }
}
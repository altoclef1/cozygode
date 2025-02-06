using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace cozygode.Content.Items.Tools.MultiTools
{
    internal class AllPurposeTool : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true; // Automatically re-swing/re-use this item after its swinging animation is over.
            Item.tileBoost += 5;
            Item.axe = 30; // How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
            Item.hammer = 100; // How much hammer power the weapon has
            Item.pick = 250;

        }

    }
}

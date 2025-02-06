using cozygode.Content.Projectiles.Weapons.Melee;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace cozygode.Content.Items.Weapons.Melee.Spear
{
    public class solarspear : ModItem
    {
        

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow;
           Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
             Item.shoot = ModContent.ProjectileType<Solarthrow>(); // Use the newest projectile
            Item.shootSpeed = 3.7f;
        }

        
    }
}
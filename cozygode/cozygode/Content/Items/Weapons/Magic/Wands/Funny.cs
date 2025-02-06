using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using cozygode.Content.Projectiles.Weapons.Magic;

namespace cozygode.Content.Items.Weapons.Magic.Wands
{
    public class Funny : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 1; // Displayed damage, but overridden by projectile
            Item.DamageType = DamageClass.Magic;
            Item.mana = 150;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 200;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Monster>();
            Item.shootSpeed = 10f;
        }
    }
}

using cozygode.Content.Projectiles.Weapons.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace cozygode.Content.Items.Weapons.Melee.YoYo
{
    public class Yoyoyo : ModItem
    {
        

         public override void SetDefaults()
        {
            Item.width = 58;
            Item.height = 50;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.damage = 205;
            Item.knockBack = 4f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.shoot = ModContent.ProjectileType<Yoyoy>();
            Item.shootSpeed = 16f;

            
        }
        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(ItemID.CopperBar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
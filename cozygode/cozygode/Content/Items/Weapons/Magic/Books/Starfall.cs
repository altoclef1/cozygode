using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using cozygode.Content.Projectiles.Weapons.Magic;

namespace cozygode.Content.Items.Weapons.Magic.Books
{
    internal class Starfall : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 100;
            Item.mana = 15; // Mana cost
            Item.useTime = 20; // Speed of casting
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot; // Makes it function as a spell book
            Item.noMelee = true; // Prevents the book itself from dealing damage
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 5, 0, 0); // 5 gold
            Item.rare = ItemRarityID.Yellow; // Rarity level
            Item.UseSound = SoundID.Item9; // Magic spell sound
            Item.autoReuse = true; // Can be held down to keep casting
            Item.shoot = ModContent.ProjectileType<MagicStar>(); // Custom falling star projectile
            Item.shootSpeed = 0f; // Doesn't need speed since it's spawning above
        }
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 targetPosition = Main.MouseWorld; // Cursor position

            // Randomly choose left (-1) or right (1)
            int directionMultiplier = Main.rand.NextBool() ? -1 : 1;

            // Spawn position: High above and either left or right
            Vector2 spawnPosition = new Vector2(targetPosition.X + (400 * directionMultiplier), targetPosition.Y - 700);

            // Calculate velocity to ensure it reaches the cursor
            Vector2 direction = targetPosition - spawnPosition;
            float distance = direction.Length();
            float speed = MathHelper.Clamp(distance / 20f, 20f, 50f);
            direction.Normalize();
            direction *= speed;

            // Spawn the projectile
            Projectile.NewProjectile(source, spawnPosition, direction, type, damage, knockback, player.whoAmI);

            return false; // Prevents default shooting behavior
        }


    }
}
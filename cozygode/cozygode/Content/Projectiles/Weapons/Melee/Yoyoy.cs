using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace cozygode.Content.Projectiles.Weapons.Melee
{
    internal class Yoyoy : ModProjectile
    {
        private float angle = 0f; // Angle for rotation
        private float radius = 100f; // Distance from the cursor
        private bool returning = false; // Track if the yoyo is returning

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;

            // Yo-Yo settings (required for proper yo-yo behavior)
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 10f; // Duration before returning
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 250f; // Maximum distance from the player
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f; // Speed of the yo-yo
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Check if the player is still channeling (holding attack button)
            if (!player.channel) 
            {
                returning = true; // Start returning to the player
            }

            if (returning)
            {
                // Move the yoyo back to the player
                Vector2 directionToPlayer = player.Center - Projectile.Center;
                float returnSpeed = 10f; // Adjust return speed as needed
                Projectile.velocity = directionToPlayer.SafeNormalize(Vector2.Zero) * returnSpeed;

                // If the yoyo is close enough to the player, remove the projectile
                if (directionToPlayer.Length() < 10f)
                {
                    Projectile.Kill(); // Despawn the projectile
                }
            }
            else
            {
                // Get the mouse position in world coordinates
                Vector2 mousePos = Main.MouseWorld;

                // Increase the angle over time
                angle += 0.5f; // Adjust speed of rotation

                // Calculate new position
                Projectile.position = mousePos + new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * radius;

                // Keep projectile facing outward
                Projectile.rotation = angle;
            }
        }
    }
}

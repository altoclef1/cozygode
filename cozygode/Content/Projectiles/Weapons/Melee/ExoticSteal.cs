using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace cozygode.Content.Projectiles.Weapons.Melee
{
    internal class ExoticSteal : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16; // The width of the projectile hitbox
            Projectile.height = 16; // The height of the projectile hitbox
            Projectile.friendly = true; // Indicates it can damage enemies
            Projectile.hostile = false; // Indicates it cannot hurt the player
            Projectile.DamageType = DamageClass.Melee; // Specifies the damage type
            Projectile.penetrate = 1; // How many enemies it can hit before disappearing
            Projectile.timeLeft = 300; // Time before the projectile disappears (in frames)
            Projectile.light = 0.5f; // Adds light to the projectile
            Projectile.aiStyle = 0; // Custom AI, so we set this to 0
        }

        public override void AI()
        {
            // Rotate the projectile
            Projectile.rotation += 0.4f * Projectile.direction;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            

            // Calculate healing based on damage dealt (1.5% of damage)
            int healAmount = (int)Math.Round(hit.Damage * 0.015f);

            // Apply a life steal cap (if using balancing constants)
          

            // Validate that life steal is allowed and the target is valid
            Player player = Main.player[Projectile.owner];
            if (player.lifeSteal <= 0f || healAmount <= 0 || target.lifeMax <= 5)
                return;

            // Show the healing effect
            player.statLife += healAmount;
            if (player.statLife > player.statLifeMax2) // Prevent overhealing
            {
                player.statLife = player.statLifeMax2;
            }

            player.HealEffect(healAmount, true); // Display heal effect

            // Debug: Confirm healing logic
            

            // Optional: If using Calamity's life steal system, spawn a life steal projectile
           
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Handle bouncing off walls
            if (Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X; // Reverse X velocity
            if (Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y; // Reverse Y velocity
            return false; // Prevent the projectile from being destroyed
        }
    }
}






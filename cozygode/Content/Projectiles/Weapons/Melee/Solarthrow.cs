using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace cozygode.Content.Projectiles.Weapons.Melee
{
    public class Solarthrow : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            
        }

        public override void AI()
        {
            // Apply a slight reverse gravity effect
            Projectile.velocity.Y -= 0.1f; // Adjust the value to control the strength of the reverse gravity

            // Custom AI code here (if any)
        }

        public  void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Inflict the On Fire! and Cursed Inferno debuffs
            target.AddBuff(BuffID.OnFire, 300); // 5 seconds
            target.AddBuff(BuffID.CursedInferno, 300); // 5 seconds
        }

        public  void OnHitPvp(Player target, int damage, bool crit)
        {
            // Inflict the On Fire! and Cursed Inferno debuffs
            target.AddBuff(BuffID.OnFire, 300); // 5 seconds
            target.AddBuff(BuffID.CursedInferno, 300); // 5 seconds
        }

        public override void Kill(int timeLeft)
        {
            // Code to execute when the projectile is destroyed
        }
    }
}   
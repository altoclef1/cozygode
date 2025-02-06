using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace cozygode.Content.Projectiles.Weapons.Magic
{
    internal class MagicStar : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.hostile = false;
            
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300; // Lasts 5 seconds before disappearing
        }

        public override void AI()
        {
            // Gravity effect to make it fall
            Projectile.velocity.Y += 0.2f; // Increase this for faster fall

            
            
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Optional: Inflict a debuff on hit
            target.AddBuff(BuffID.OnFire, 120); // Burns the enemy for 2 seconds
        }

        public override void Kill(int timeLeft)
        {
            // Explosion effect on impact
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3));
            }

            // Sound effect on impact
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}

    


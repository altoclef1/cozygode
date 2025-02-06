using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace cozygode.Content.Projectiles.Weapons.Magic
{
    internal class Monster : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true; // Ensures it collides with tiles
            Projectile.aiStyle = 0; // Disables default AI style
        }

        public override void AI()
        {
            // Make the projectile fly straight without deviation
            Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero) * 10f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage.Base = 700000; // Ensures the projectile deals exactly 200 damage
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Explode();
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Explode();
        }

        public override void OnKill(int timeLeft)
        {
            Explode();
        }

        private void Explode()
        {
            // Create a larger explosion effect
            for (int i = -4; i <= 4; i++)
            {
                for (int j = -4; j <= 4; j++)
                {
                    int tileX = (int)(Projectile.position.X / 16) + i; // Fix division factor
                    int tileY = (int)(Projectile.position.Y / 16) + j;

                    if (WorldGen.InWorld(tileX, tileY) && Main.tile[tileX, tileY] != null && Main.tile[tileX, tileY].HasTile)
                    {
                        WorldGen.KillTile(tileX, tileY, noItem: false, effectOnly: false, fail: false); // Ensure fail is false
                    }
                }
            }

            // Firework-like explosion dust effect
            for (int i = 0; i < 75; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-50f, 50f), Main.rand.NextFloat(-50f, 50f));
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Red, velocity.X, velocity.Y, 100, default, 2.5f);
                dust.noGravity = true;
            }
            for (int i = 0; i < 75; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-60f, 60f), Main.rand.NextFloat(-60f, 60f));
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Blue, velocity.X, velocity.Y, 100, default, 2.5f);
                dust.noGravity = true;
            }
            for (int i = 0; i < 75; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-70f, 70f), Main.rand.NextFloat(-70f, 70f));
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Yellow, velocity.X, velocity.Y, 100, default, 2.5f);
                dust.noGravity = true;
            }

            // Play explosion sound
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}

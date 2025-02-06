﻿using cozygode.Content.Projectiles.Weapons.Melee;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace cozygode.Content.Items.Weapons.Melee.Other
{
    public class ExoticKnives : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 62;
            Item.damage = 200;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.knockBack = 3f;
            Item.UseSound = SoundID.Item39;
            Item.autoReuse = true;

          

            Item.shoot = ModContent.ProjectileType<ExoticSteal>();
            Item.shootSpeed = 9f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float knifeSpeed = Item.shootSpeed;
            Vector2 realPlayerPos = player.RotatedRelativePoint(player.MountedCenter, true);
            float mouseXDist = (float)Main.mouseX + Main.screenPosition.X - realPlayerPos.X;
            float mouseYDist = (float)Main.mouseY + Main.screenPosition.Y - realPlayerPos.Y;
            if (player.gravDir == -1f)
            {
                mouseYDist = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - realPlayerPos.Y;
            }
            float mouseDistance = (float)Math.Sqrt((double)(mouseXDist * mouseXDist + mouseYDist * mouseYDist));
            if ((float.IsNaN(mouseXDist) && float.IsNaN(mouseYDist)) || (mouseXDist == 0f && mouseYDist == 0f))
            {
                mouseXDist = (float)player.direction;
                mouseYDist = 0f;
                mouseDistance = knifeSpeed;
            }
            else
            {
                mouseDistance = knifeSpeed / mouseDistance;
            }
            mouseXDist *= mouseDistance;
            mouseYDist *= mouseDistance;
            int knifeAmt = 4;
            if (Main.rand.NextBool())
            {
                knifeAmt++;
            }
            if (Main.rand.NextBool(4))
            {
                knifeAmt++;
            }
            if (Main.rand.NextBool(6))
            {
                knifeAmt++;
            }
            if (Main.rand.NextBool(8))
            {
                knifeAmt++;
            }
            for (int i = 0; i < knifeAmt; i++)
            {
                float knifeSpawnXPos = mouseXDist;
                float knifeSpawnYPos = mouseYDist;
                float randOffsetDampener = 0.05f * (float)i;
                knifeSpawnXPos += (float)Main.rand.Next(-35, 36) * randOffsetDampener;
                knifeSpawnYPos += (float)Main.rand.Next(-35, 36) * randOffsetDampener;
                mouseDistance = (float)Math.Sqrt((double)(knifeSpawnXPos * knifeSpawnXPos + knifeSpawnYPos * knifeSpawnYPos));
                mouseDistance = knifeSpeed / mouseDistance;
                knifeSpawnXPos *= mouseDistance;
                knifeSpawnYPos *= mouseDistance;
                float x4 = realPlayerPos.X;
                float y4 = realPlayerPos.Y;
                Projectile.NewProjectile(source, x4, y4, knifeSpawnXPos, knifeSpawnYPos, type, damage, knockback, player.whoAmI, 0f, 0f);
            }
            return false;
        }

    }
}

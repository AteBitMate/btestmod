// Decompiled with JetBrains decompiler
// Type: ThoriumMod.Utilities.MiscHelper
// Assembly: ThoriumMod, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F05B341B-C392-4EFC-B8A3-922168CD2283
// Assembly location: Z:\Library\Application Support\Terraria\ModLoader\Mods\ThoriumMod\ThoriumMod.XNA.dll

using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Localization;
using ThoriumMod;
using ThoriumMod.Utilities;

namespace btestmod
{
  internal static class MiscHelper
  {
    public static void SetDefaults(this Item item, int type, int stack, bool noMatCheck = false)
    {
      item.SetDefaults(type, noMatCheck);
      item.stack = stack;
    }

    public static void ThoriumChatMessage(string key, Color color)
    {
      key = "Mods.ThoriumMod." + key;
      if (Main.netMode == 2)
      {
        NetMessage.BroadcastChatMessage(NetworkText.FromKey(key, new object[0]), color, -1);
      }
      else
      {
        if (Main.netMode != null)
          return;
        Main.NewText(Language.GetTextValue(key), color, false);
      }
    }

    public static float DistanceSQ(this Rectangle rectangle, Vector2 point)
    {
      if (Utils.FloatIntersect((float) rectangle.Left, (float) rectangle.Top, (float) rectangle.Width, (float) rectangle.Height, point.X, point.Y, 0.0f, 0.0f))
        return 0.0f;
      return (double) point.X >= (double) rectangle.Left && (double) point.X <= (double) rectangle.Right ? ((double) point.Y >= (double) rectangle.Top ? (float) (((double) point.Y - (double) rectangle.Bottom) * ((double) point.Y - (double) rectangle.Bottom)) : (float) (((double) rectangle.Top - (double) point.Y) * ((double) rectangle.Top - (double) point.Y))) : ((double) point.Y >= (double) rectangle.Top && (double) point.Y <= (double) rectangle.Bottom ? ((double) point.X >= (double) rectangle.Left ? (float) (((double) point.X - (double) rectangle.Right) * ((double) point.X - (double) rectangle.Right)) : (float) (((double) rectangle.Left - (double) point.X) * ((double) rectangle.Left - (double) point.X))) : ((double) point.X < (double) rectangle.Left ? ((double) point.Y >= (double) rectangle.Top ? Vector2.DistanceSquared(point, Utils.BottomLeft(rectangle)) : Vector2.DistanceSquared(point, Utils.TopLeft(rectangle))) : ((double) point.Y >= (double) rectangle.Top ? Vector2.DistanceSquared(point, Utils.BottomRight(rectangle)) : Vector2.DistanceSquared(point, Utils.TopRight(rectangle)))));
    }

    public static bool CanHitLine(this Entity start, Entity end) => MiscHelper.CanHitLine(Utils.ToTileCoordinates(start.Center), Utils.ToTileCoordinates(end.Center));

    public static bool CanHitLine(Vector2 start, Vector2 end) => MiscHelper.CanHitLine(Utils.ToTileCoordinates(start), Utils.ToTileCoordinates(end));

    public static bool CanHitLine(Point start, Point end)
    {
      if (!WorldGen.InWorld(start.X, start.Y, 0) || !WorldGen.InWorld(end.X, end.Y, 0) || WorldGen.SolidTile3(Framing.GetTileSafely(start)))
        return false;
      int num1 = Math.Abs(end.X - start.X);
      int num2 = Math.Abs(end.Y - start.Y);
      int num3 = end.X - start.X > 0 ? 1 : -1;
      int num4 = end.Y - start.Y > 0 ? 1 : -1;
      int num5 = 0;
      int num6 = 0;
      while (num5 < num1 || num6 < num2)
      {
        int num7 = ((1 + 2 * num5) * num2).CompareTo((1 + 2 * num6) * num1);
        if (num7 == 0)
        {
          if (WorldGen.SolidTile3(Framing.GetTileSafely(start.X + num3, start.Y)) || WorldGen.SolidTile3(Framing.GetTileSafely(start.X, start.Y + num4)))
            return false;
          start.X += num3;
          start.Y += num4;
          ++num5;
          ++num6;
        }
        else if (num7 < 0)
        {
          start.X += num3;
          ++num5;
        }
        else
        {
          start.Y += num4;
          ++num6;
        }
        if (WorldGen.SolidTile3(Framing.GetTileSafely(start)))
          return false;
      }
      return true;
    }

    public static string TenToRoman(byte number)
    {
      switch (number)
      {
        case 1:
          return "I";
        case 2:
          return "II";
        case 3:
          return "III";
        case 4:
          return "IV";
        case 5:
          return "V";
        case 6:
          return "VI";
        case 7:
          return "VII";
        case 8:
          return "VIII";
        case 9:
          return "IX";
        case 10:
          return "X";
        default:
          return "";
      }
    }
  }
}

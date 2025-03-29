using HarmonyLib;
using Microsoft.Xna.Framework.Graphics;
using SpinningWeaponAndToolMod;
using StardewModdingAPI;
using StardewValley;

[HarmonyPatch(typeof(TemporaryAnimatedSprite), "loadTexture")]
public static class Patch_TemporaryAnimatedSprite_loadTexture
{
    private static readonly Dictionary<string, Texture2D> _cachedTextures = new();

    public static bool Prefix(TemporaryAnimatedSprite __instance)
    {
        string textureName = __instance.textureName;

        if (!string.IsNullOrEmpty(textureName) && textureName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                string fullPath = Path.Combine(
                    ModEntry.Instance.Helper.DirectoryPath,
                    textureName.Replace('/', Path.DirectorySeparatorChar)
                );

                if (_cachedTextures.TryGetValue(fullPath, out var cachedTexture))
                {
                    __instance.texture = cachedTexture;
                    return false; // Skip original method
                }

                if (File.Exists(fullPath))
                {
                    using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                    var texture = Texture2D.FromStream(Game1.graphics.GraphicsDevice, stream);
                    _cachedTextures[fullPath] = texture;

                    __instance.texture = texture;
                    ModEntry.Instance.Monitor.Log($"Cached texture: {fullPath}", LogLevel.Trace);
                    return false;
                }
                else
                {
                    ModEntry.Instance.Monitor.Log($"PNG not found: {fullPath}", LogLevel.Warn);
                }
            }
            catch (Exception ex)
            {
                ModEntry.Instance.Monitor.Log($"Failed to load PNG texture: {ex}", LogLevel.Error);
            }
        }

        return true; // Use game's default XNB load if not a PNG
    }
}

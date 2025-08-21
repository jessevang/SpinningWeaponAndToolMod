using HarmonyLib;
using StardewValley;

//patching to prevent message from appear. Messasges that are about pickaxe and axe not strong enough.
namespace SpinningWeaponAndToolMod.Patches
{
    public static class DrawObjectDialoguePatch
    {
        private static readonly string[] KeysToBlock =
        {
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13945",
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13948",
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13952",
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13956",
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13962",
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13963",
            "Strings\\StringsFromCSFiles:ResourceClump.cs.13964",
        };

        private static HashSet<string> _blockedDialogues = new HashSet<string>(StringComparer.Ordinal);

        public static void RebuildBlockedDialogues()
        {
            var set = new HashSet<string>(StringComparer.Ordinal);
            foreach (var key in KeysToBlock)
            {
                try
                {
                    string s = Game1.content.LoadString(key);
                    if (!string.IsNullOrWhiteSpace(s))
                        set.Add(s.Trim());
                }
                catch {  }
            }
            _blockedDialogues = set;
        }

        private static bool ShouldBlock(string dialogue)
        {
            if (string.IsNullOrWhiteSpace(dialogue) || _blockedDialogues.Count == 0)
                return false;
            return _blockedDialogues.Contains(dialogue.Trim());
        }

        // Prefix method
        public static bool Prefix(string dialogue)
        {
            return !ShouldBlock(dialogue);  
        }
    }
}

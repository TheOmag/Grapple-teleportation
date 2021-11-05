using HarmonyLib;
using BepInEx;
using System.Reflection;

namespace patcher
{

    [BepInPlugin("org.Crafterbot.grapple.TeleportationGrappleMod", "Teleportation Grapple", "5.4.17.0")]
    public class MyPatcher : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony("com.Crafterbot.grapple.TeleportationGrappleMod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
using HarmonyLib;
using UnityEngine;

namespace teleport
{
    [HarmonyPatch(typeof(Wildflare.Player.CameraController))]
    [HarmonyPatch("Update", MethodType.Normal)]

    public class code
    {
        private static bool hitOneOff = false;
        private static void Postfix(Wildflare.Player.CameraController __instance)
        {
            if (Input.GetKey(KeyCode.T) && !hitOneOff)
            {
                Ray mainRay = new Ray(__instance.playerCam.transform.position + new Vector3(0f, 0f, 0f), __instance.playerCam.transform.forward);
                Physics.Raycast(mainRay, 10000);
                RaycastHit hit;                                                                                                                                                               
                if (Physics.Raycast(mainRay, out hit))
                {
                    Wildflare.Player.PlayerMovement.Instance.transform.position = hit.point + new Vector3(0f, 4.4f, 0f);
                }
                hitOneOff = true;
            }
            if (!Input.GetKey(KeyCode.T))
            {
                hitOneOff = false;
            }
        }
    }
}

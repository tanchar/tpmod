using HarmonyLib;
using System.Xml;
using DMT;
using System.Reflection;
using UnityEngine;

/**
 * Inspired from SphereII_DialogFromXML_Extensions
 * 
 * This class includes a Harmony patches to allow loading up extra custom dialog elements (teleport)
 * 
 * Usage:
 *   <action type="Teleport, Mods" target="trader_hugh"/>
  */
public class SphereII_DialogFromXML_Extensions
{
    [HarmonyPatch(typeof(DialogFromXml))]
    [HarmonyPatch("ParseAction")]
    public class SphereII__DialogFromXML_ParseAction
    {
        static void Postfix(BaseDialogAction __result, XmlElement e)
        {
            if (__result is DialogActionTeleport)
            {
                Debug.Log("Got one Teleport action !");
                (__result as DialogActionTeleport).target = e.GetAttribute("target");


            }

        }
    }


}
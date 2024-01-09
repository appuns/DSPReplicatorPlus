using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.IO;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using static UnityEngine.GUILayout;
using UnityEngine.Rendering;
using Steamworks;
using rail;
using xiaoye97;

namespace DSPReplicatorPlus
{
    [HarmonyPatch]
    internal class Patch
    {
        public static int SelectedRecipeIndexBk = -1;
        public static int currentTypeBk = 1;
        public static RecipeProto resipeBk;

        //ボタンのインタラクティブ判定の切り替え
        [HarmonyPostfix, HarmonyPatch(typeof(UIReplicatorWindow), "_OnUpdate")]
        public static void UIReplicatorWindow_OnUpdate_Postfix(UIReplicatorWindow __instance)
        {
            if (__instance.selectedRecipe != null && __instance.selectedRecipe.Handcraft)
            {
                int num = __instance.mechaForge.PredictTaskCount(__instance.selectedRecipe.ID, 999);
                int stackSize = LDB.items.Select(LDB.recipes.Select(__instance.selectedRecipe.ID).Results[0]).StackSize;

                UI.headMax.GetComponent<Button>().interactable = (num > 0) ? true : false;
                //UI.headStack.GetComponent<Button>().interactable = (num >= stackSize) ? true : false; ;
                UI.head500.GetComponent<Button>().interactable = (num >= 500) ? true : false; ;
                UI.head100.GetComponent<Button>().interactable = (num >= 100) ? true : false;
                UI.head50.GetComponent<Button>().interactable = (num >= 50) ? true : false;
                UI.head10.GetComponent<Button>().interactable = (num >= 10) ? true : false;
                UI.head5.GetComponent<Button>().interactable = (num >= 5) ? true : false;
                UI.head1.GetComponent<Button>().interactable = (num >= 1) ? true : false;

                UI.endMax.GetComponent<Button>().interactable = (num > 0) ? true : false;
                //UI.endStack.GetComponent<Button>().interactable = (num >= stackSize) ? true : false;
                UI.end500.GetComponent<Button>().interactable = (num >= 500) ? true : false;
                UI.end100.GetComponent<Button>().interactable = (num >= 100) ? true : false;
                UI.end50.GetComponent<Button>().interactable = (num >= 50) ? true : false;
                UI.end10.GetComponent<Button>().interactable = (num >= 10) ? true : false;
                UI.end5.GetComponent<Button>().interactable = (num >= 5) ? true : false;
                UI.end1.GetComponent<Button>().interactable = (num >= 1) ? true : false;

                //UI.headStack.transform.Find("text").GetComponent<Text>().text = stackSize.ToString();
                //UI.endStack.transform.Find("text").GetComponent<Text>().text = stackSize.ToString();

            }
        }

        //前回開いていたレシピを表示する
        [HarmonyPostfix, HarmonyPatch(typeof(UIReplicatorWindow), "OnRecipeMouseDown")]
        public static void UIReplicatorWindow_SetSelectedRecipeIndex_Postfix(UIReplicatorWindow __instance)
        { 
            //Main.LogManager.Logger.LogInfo("----------------------------------------------------__instance.mouseRecipeIndex : " + __instance.mouseRecipeIndex);
            //Main.LogManager.Logger.LogInfo("---------------------------------------------------------__instance.currentType : " + __instance.currentType);
            //Main.LogManager.Logger.LogInfo("------------------------------------------------------__instance.selectedRecipe : " + __instance.selectedRecipe.name);

            SelectedRecipeIndexBk = __instance.mouseRecipeIndex;
            currentTypeBk = __instance.currentType;
            resipeBk = __instance.selectedRecipe;
        }
        [HarmonyPostfix, HarmonyPatch(typeof(UIReplicatorWindow), "_OnOpen")]
        public static void UIReplicatorWindow_OnOpen_Postfix(UIReplicatorWindow __instance)
        {
            __instance.selectedRecipe = resipeBk;
            __instance.currentType = currentTypeBk;
            __instance.RefreshRecipeIcons();
            __instance.typeButton1.highlighted = (currentTypeBk == 1);
            __instance.typeButton2.highlighted = (currentTypeBk == 2);
            __instance.typeButton1.button.interactable = (currentTypeBk != 1);
            __instance.typeButton2.button.interactable = (currentTypeBk != 2);
            __instance.SetSelectedRecipeIndex(SelectedRecipeIndexBk, true);
            __instance.OnSelectedRecipeChange(true);

        }
    }

}

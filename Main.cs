using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Net;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

//アップデート予定？
//最大値の表示
//スタックサイズボタン
//レシピアイコンに現在の所持数を表示
//必要素材を表示し続け、数がそろったら自動でタスクに入れる

namespace DSPReplicatorPlus
{
    [BepInPlugin("Appun.DSP.plugin.DSPReplicatorPlus", "DSPReplicatorPlus", "0.0.2")]
    [HarmonyPatch]
    public class Main : BaseUnityPlugin
    {

        public static ConfigEntry<float> speedMultiplier;
        public static ConfigEntry<float> maximumSpeed;
        public static ConfigEntry<KeyCode> KeyConfig;



        public void Start()
        {
            LogManager.Logger = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            UI.Create();
        }

        public class LogManager
        {
            public static ManualLogSource Logger;
        }
    }
}
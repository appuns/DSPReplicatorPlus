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

    internal class UI : MonoBehaviour
    {
        public static GameObject headTitle = new GameObject();
        public static GameObject headMax = new GameObject();
        public static GameObject headStack = new GameObject();
        public static GameObject head500 = new GameObject();
        public static GameObject head100 = new GameObject();
        public static GameObject head50 = new GameObject();
        public static GameObject head10 = new GameObject();
        public static GameObject head5 = new GameObject();
        public static GameObject head1 = new GameObject();
        public static GameObject endTitle = new GameObject();
        public static GameObject endMax = new GameObject();
        public static GameObject endStack = new GameObject();
        public static GameObject end500 = new GameObject();
        public static GameObject end100 = new GameObject();
        public static GameObject end50 = new GameObject();
        public static GameObject end10 = new GameObject();
        public static GameObject end5 = new GameObject();
        public static GameObject end1 = new GameObject();

        public static float headX = -60;
        public static float headY = 160;
        public static float diffX = 120;
        public static float diffY = 22;

        public static void Create()

        {

            //ボタンの作成
            GameObject multiValueText = UIRoot.instance.uiGame.replicator.multiValueText.gameObject;
            headTitle = Instantiate(multiValueText, multiValueText.transform.parent);
            headTitle.transform.localPosition = new Vector3(headX, headY + diffY, 0);
            headTitle.GetComponent<Text>().text = "to head".Translate();

            GameObject minusButton = UIRoot.instance.uiGame.replicator.minusButton.gameObject;

            headMax = Instantiate(minusButton, minusButton.transform.parent);
            headMax.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 24);
            //headMax.transform.localScale = new Vector3(0.9f, 0.9f, 0);
            headMax.transform.localPosition = new Vector3(headX, headY, 0);
            headMax.transform.Find("text").GetComponent<Text>().text = "MAX".Translate();
            headMax.transform.Find("text").GetComponent<Text>().font = headTitle.GetComponent<Text>().font;
            headMax.transform.Find("text").GetComponent<Text>().fontSize = 16;

            //headStack = Instantiate(headMax, headMax.transform.parent);
            //headStack.transform.localPosition = new Vector3(headX, headY - diffY * 1, 0);
            //headStack.transform.Find("text").GetComponent<Text>().text = "1Stack";

            head500 = Instantiate(headMax, headMax.transform.parent);
            head500.transform.localPosition = new Vector3(headX, headY - diffY * 1, 0);
            head500.transform.Find("text").GetComponent<Text>().text = "500";

            head100 = Instantiate(headMax, headMax.transform.parent);
            head100.transform.localPosition = new Vector3(headX, headY - diffY * 2, 0);
            head100.transform.Find("text").GetComponent<Text>().text = "100";

            head50 = Instantiate(headMax, headMax.transform.parent);
            head50.transform.localPosition = new Vector3(headX, headY - diffY * 3, 0);
            head50.transform.Find("text").GetComponent<Text>().text = "50";

            head10 = Instantiate(headMax, headMax.transform.parent);
            head10.transform.localPosition = new Vector3(headX, headY - diffY * 4, 0);
            head10.transform.Find("text").GetComponent<Text>().text = "10";

            head5 = Instantiate(headMax, headMax.transform.parent);
            head5.transform.localPosition = new Vector3(headX, headY - diffY * 5, 0);
            head5.transform.Find("text").GetComponent<Text>().text = "5";

            head1 = Instantiate(headMax, headMax.transform.parent);
            head1.transform.localPosition = new Vector3(headX, headY - diffY * 6, 0);
            head1.transform.Find("text").GetComponent<Text>().text = "1";

            GameObject plusButton = UIRoot.instance.uiGame.replicator.plusButton.gameObject;

            endTitle = Instantiate(multiValueText, multiValueText.transform.parent);
            endTitle.transform.localPosition = new Vector3(headX + diffX, headY + diffY, 0);
            endTitle.GetComponent<Text>().text = "to end".Translate();

            endMax = Instantiate(plusButton, plusButton.transform.parent);
            endMax.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 24);
            endMax.transform.localPosition = new Vector3(headX + diffX, headY, 0);
            endMax.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            endMax.transform.Find("text").GetComponent<Text>().text = "MAX".Translate();
            endMax.transform.Find("text").GetComponent<Text>().font = headTitle.GetComponent<Text>().font;
            endMax.transform.Find("text").GetComponent<Text>().fontSize = 16;

            //endStack = Instantiate(endMax, endMax.transform.parent);
            //endStack.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 1, 0);
            //endStack.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            //endStack.transform.Find("text").GetComponent<Text>().text = "1Stack";

            end500 = Instantiate(endMax, endMax.transform.parent);
            end500.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 1, 0);
            end500.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            end500.transform.Find("text").GetComponent<Text>().text = "500";

            end100 = Instantiate(endMax, endMax.transform.parent);
            end100.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 2, 0);
            end100.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            end100.transform.Find("text").GetComponent<Text>().text = "100";

            end50 = Instantiate(endMax, endMax.transform.parent);
            end50.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 3, 0);
            end50.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            end50.transform.Find("text").GetComponent<Text>().text = "50";

            end10 = Instantiate(endMax, endMax.transform.parent);
            end10.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 4, 0);
            end10.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            end10.transform.Find("text").GetComponent<Text>().text = "10";

            end5 = Instantiate(endMax, endMax.transform.parent);
            end5.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 5, 0);
            end5.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            end5.transform.Find("text").GetComponent<Text>().text = "5";

            end1 = Instantiate(endMax, endMax.transform.parent);
            end1.transform.localPosition = new Vector3(headX + diffX, headY - diffY * 6, 0);
            end1.transform.Find("text").transform.localPosition = new Vector3(-1, 1, 0);
            end1.transform.Find("text").GetComponent<Text>().text = "1";

            //okボタンの改変
            GameObject okButton = UIRoot.instance.uiGame.replicator.transform.Find("recipe-tree/ok-btn").gameObject;
            okButton.transform.localPosition = new Vector3(349, 120, 0); //349 130 0
            //okButton.GetComponent<Image>().enabled = false;
            okButton.transform.Find("img").GetComponent<Image>().enabled = false;
            GameObject predCount = okButton.transform.Find("pred-count").gameObject;
            predCount.transform.localPosition = new Vector3(0, 71, 0); //38 44 0

            ////カウントの位置調整
            GameObject count = UIRoot.instance.uiGame.replicator.transform.Find("recipe-tree/count").gameObject;
            count.transform.localPosition = new Vector3(349, 30, 0);


            //イベント
            headMax.GetComponent<Button>().onClick.AddListener(onClickHeadMax);
            //headStack.GetComponent<Button>().onClick.AddListener(onClickheadStack);
            head500.GetComponent<Button>().onClick.AddListener(onClickHead500);
            head100.GetComponent<Button>().onClick.AddListener(onClickHead100);
            head50.GetComponent<Button>().onClick.AddListener(onClickHead50);
            head10.GetComponent<Button>().onClick.AddListener(onClickHead10);
            head5.GetComponent<Button>().onClick.AddListener(onClickHead5);
            head1.GetComponent<Button>().onClick.AddListener(onClickHead1);
            endMax.GetComponent<Button>().onClick.AddListener(onClickEndMax);
            //endStack.GetComponent<Button>().onClick.AddListener(onClickEndStack);
            end500.GetComponent<Button>().onClick.AddListener(onClickEnd500);
            end100.GetComponent<Button>().onClick.AddListener(onClickEnd100);
            end50.GetComponent<Button>().onClick.AddListener(onClickEnd50);
            end10.GetComponent<Button>().onClick.AddListener(onClickEnd10);
            end5.GetComponent<Button>().onClick.AddListener(onClickEnd5);
            end1.GetComponent<Button>().onClick.AddListener(onClickEnd1);
        }

        public static void onClickEndMax()
        {
            UIReplicatorWindow replicator = UIRoot.instance.uiGame.replicator;
            if (replicator.isInstantItem)
            {
                mechaForgeAddTask(1000);
            }
            else
            {
                mechaForgeAddTask(replicator.mechaForge.PredictTaskCount(replicator.selectedRecipe.ID, 999));
            }
        }

        //public static void onClickEndStack()
        //{
        //    UIReplicatorWindow replicator = UIRoot.instance.uiGame.replicator;
        //    mechaForgeAddTask(LDB.items.Select(LDB.recipes.Select(replicator.selectedRecipe.ID).Results[0]).StackSize);
        //}
        public static void onClickEnd500()
        {
            mechaForgeAddTask(500);
        }
        public static void onClickEnd100()
        {
            mechaForgeAddTask(100);
        }
        public static void onClickEnd50()
        {
            mechaForgeAddTask(50);
        }
        public static void onClickEnd10()
        {
            mechaForgeAddTask(10);
        }
        public static void onClickEnd5()
        {
            mechaForgeAddTask(5);
        }
        public static void onClickEnd1()
        {
            mechaForgeAddTask(1);
        }


        public static void onClickHeadMax()
        {
            UIReplicatorWindow replicator = UIRoot.instance.uiGame.replicator;
            if(replicator.isInstantItem)
            {
                mechaForgeAddTaskHead(1000);
            }
            else
            {
                mechaForgeAddTaskHead(replicator.mechaForge.PredictTaskCount(replicator.selectedRecipe.ID, 999));
            }
        }
        //public static void onClickheadStack()
        //{
        //    UIReplicatorWindow replicator = UIRoot.instance.uiGame.replicator;
        //    mechaForgeAddTaskHead(LDB.items.Select(LDB.recipes.Select(replicator.selectedRecipe.ID).Results[0]).StackSize);
        //}

        public static void onClickHead500()
        {
            mechaForgeAddTaskHead(500);
        }
        public static void onClickHead100()
        {
            mechaForgeAddTaskHead(100);
        }
        public static void onClickHead50()
        {
            mechaForgeAddTaskHead(50);
        }
        public static void onClickHead10()
        {
            mechaForgeAddTaskHead(10);
        }
        public static void onClickHead5()
        {
            mechaForgeAddTaskHead(5);
        }
        public static void onClickHead1()
        {
            mechaForgeAddTaskHead(1);
        }


        public static void mechaForgeAddTask(int count)
        {
            UIReplicatorWindow replicator = UIRoot.instance.uiGame.replicator;
            int id = replicator.selectedRecipe.ID;
            replicator.mechaForge.AddTask(id, count);
        }

        public static void mechaForgeAddTaskHead(int count)
        {
            UIReplicatorWindow replicator = UIRoot.instance.uiGame.replicator;
            int id = replicator.selectedRecipe.ID;
            int length = replicator.mechaForge.tasks.Count;
            if (length == 0)
            {
                replicator.mechaForge.AddTask(id, count);
            }
            else
            {
                List<ForgeTask> list = new List<ForgeTask>(replicator.mechaForge.tasks);
                replicator.mechaForge.tasks.Clear();


                replicator.mechaForge.AddTask(id, count);
                int incr = replicator.mechaForge.tasks.Count;
                //Main.LogManager.Logger.LogInfo($"----------------------------------------------------{incr}");
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].parentTaskIndex >= 0)
                    {
                        list[i].parentTaskIndex += incr;
                    }
                    replicator.mechaForge.tasks.Add(list[i]);
                }
                //for (int i = 0; i < replicator.mechaForge.tasks.Count; i++)
                //{
                //    Main.LogManager.Logger.LogInfo($"{i} {replicator.mechaForge.tasks[i].count} {replicator.mechaForge.tasks[i].parentTaskIndex}");
                //}

            }
        }



    }
}
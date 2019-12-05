using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VikingCrewTools.UI
{
    public class TaskItem : MonoBehaviour
    {
        public string taskText;

        public Collider destination;

        public bool active;

        public bool Finished = false;

        public bool talkTofinish;

        public int ID;

        public event Action thisTaskStarted;

        public event Action thisTaskFinished;

        public UI_Maneger UI = UI_Maneger.instance;

        private int x;

        private void Awake()
        {
            x = GetComponent<ScriptedDialogueBehaviour>().scriptWhile.Length;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (active && destination == other)
            { if (UI == null)
                    Debug.Log("fuck");
                UI.MarkTask(ID);
                active = false;
                Debug.Log(taskText);
                OnThisTaskFinish();
            }
        }

        public void Intercacted()
        {
            if (active && talkTofinish)
            {
                x--;
                if (x <= 0)
                {
                    UI.MarkTask(ID);
                    active = false;
                    Debug.Log(taskText);
                    OnThisTaskFinish();
                }

            }
        }


        private void OnThisTaskFinish()
        {
            if (thisTaskFinished != null)
            {
                Finished = true;
                thisTaskFinished();
            }
        }
        public void OnThisTaskStarted()
        {
            if (thisTaskStarted != null)
            {
                thisTaskStarted();
            }
        }

    }
}
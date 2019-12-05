using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    public string taskText;

    public Collider destination;

    public bool active;

    public bool Finished = false;

    bool talkTofinish;

    public int ID;

    public event Action thisTaskStarted;

    public event Action thisTaskFinished;

    public UI_Maneger UI = UI_Maneger.instance;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active && destination == other)
        {if (UI == null)
                Debug.Log("fuck");
            UI.MarkTask(ID);
            active = false;
            Debug.Log(taskText);
            OnThisTaskFinish();
        }
    }

    public void Intercacted()
    {
        if (active)
        {
            UI.MarkTask(ID);
            active = false;
            Debug.Log(taskText);
            OnThisTaskFinish();
            
        }
    }


    private void OnThisTaskFinish()
    {
        if (thisTaskFinished !=null)
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

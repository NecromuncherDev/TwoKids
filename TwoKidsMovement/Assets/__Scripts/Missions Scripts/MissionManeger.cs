using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManeger : MonoBehaviour
{
    public string missionText;
    public TaskItem[] tasks;
    int tasksDone;
    int ActiveMission;
    public static event Action MissionDone;

    public void active()
    {
        tasksDone = 0; 
      
        foreach (TaskItem task in tasks)
        {
            task.active = true;
            task.thisTaskFinished += TaskInMissionDone;
            task.OnThisTaskStarted();
        }
    }

    public void TaskInMissionDone ()
    {
        tasksDone++;
        if(tasksDone >= tasks.Length)
        {
            Debug.Log(missionText);
            tasksDone = 0;
            
            if (MissionDone!=null)
            {
                MissionDone();
            }
        }
    }


}

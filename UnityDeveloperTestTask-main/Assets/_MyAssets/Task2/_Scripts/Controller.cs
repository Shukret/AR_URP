using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Element
{
    public void OnNotification(string p_event_path,Object p_target,params object[] p_data)
    {
        if(Notifications.PlusPoints==p_event_path)
        {
            app.model.points+=5;
        }
        for (int i =0; i < Notifications.Levels.Length; i++)
        {
             if (Notifications.Levels[i]==p_event_path)
            {
                app.model.levels[i]+=1;
                app.view.SetLevelsText();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    public Model model;
    public View view;
    public Controller[] controller_list;

    public void Notify(string p_event_path, Object p_target, params object[] p_data)
   {
      //Controller[] controller_list = GetAllControllers();
      foreach(Controller c in controller_list)
      {
         c.OnNotification(p_event_path,p_target,p_data);
      }
   }

   // Fetches all scene Controllers.
  // public Controller[] GetAllControllers() { /* ... */ }
}

public class Element: MonoBehaviour
{
    public Application app { get { return GameObject.FindObjectOfType<Application>(); }}
}

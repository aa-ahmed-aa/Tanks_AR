using UnityEngine;
using System.Collections;

public class ionsui_funct : MonoBehaviour {

    //reset button
    public void reset_scene()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}

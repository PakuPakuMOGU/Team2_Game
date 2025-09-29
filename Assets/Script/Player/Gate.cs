using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Portal_Controller portal;

    public void TagCheck(string tag)
    {
        if (tag == "Gate")
        {
            GameObject obj = GameObject.FindWithTag(tag);
            if (obj != null)
            {
                Portal_Controller gate = obj.GetComponent<Portal_Controller>();
                if (gate != null)
                {
                    gate.TogglePortal(true);
                }
                else Debug.Log("Portal_ControllerÇ™å©Ç¬Ç©ÇËÇ‹ÇπÇÒ");
            }
            else Debug.Log("É^ÉO ÅF" + tag + "Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒ");
        }
    } 
}

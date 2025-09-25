using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Portal_Controller portal;

    // Start is called before the first frame update
    void Start()
    {
        portal.TogglePortal(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

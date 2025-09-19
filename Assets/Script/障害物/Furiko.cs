using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furiko : MonoBehaviour
{
    [System.Serializable]
    public class RunXYZ
    {
        public bool YesX = true;
        public float Xspeed = 0.8f;
        public bool YesY = true;
        public float Yspeed = 0.8f;
        public bool YesZ = true;
        public float Zspeed = 0.8f;
    }
    [Header("U‚èŽq‚Å“®‚©‚µ‚½‚¢•ûŒü‚ÍH")]
    [SerializeField] private RunXYZ runXYZ;

    [Header("ˆê‰•œ‚Ì•b”")]
    [SerializeField] private int time = 5;

    [Header("•`‰æƒtƒŒ[ƒ€‚Ì•p“x")]
    [SerializeField] private int time2 = 10;
    
    private float y;
    private float saveY;
    private int count;
    private int count2;
    private bool plus = true;

    void Start()
    {
        y = transform.position.y;
        saveY = y;
        count = 0;
        count2 = 0;
        time *= 30;
    }

    void Update()
    { 
        // “®‚­•ûŒü‚ðˆê’èŽžŠÔ‚Å”½“].
        if (count >= time)
        {
            y = saveY;      // ‚‚³‚ð‰ŠúÝ’è‚Ü‚Å–ß‚·.
            plus = !plus;
            count = 0;
            count2 = 0;
        }
        
        // •`‰æ.
        if (count2 > time2)
        {
            if (count >= time / 2)  y = y / runXYZ.Yspeed;
            else                    y = y * runXYZ.Yspeed;
            
            if (runXYZ.YesX) XYZ('x', plus, 0);
            if (runXYZ.YesY) XYZ('y', plus, y);
            if (runXYZ.YesZ) XYZ('z', plus, 0);            
            
            count2 = 0;
        }

        count++;
        count2++;
    }

    private void XYZ(char xyz, bool plus ,float num)
    {
        Vector3 pos = transform.position;

        switch (xyz)
        {
            case 'x':
                pos.x += plus ? runXYZ.Xspeed : -runXYZ.Xspeed;
                break;
            case 'y': 
                pos.y = num;
                break;
            case 'z':
                pos.z += plus ? runXYZ.Zspeed : -runXYZ.Zspeed;
                break;
        }

        transform.position = pos;
    }
}

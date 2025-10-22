using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareVariable : MonoBehaviour
{
    public static class Share
    {
        public static bool clear = false;
        public static bool replay = false;
        public static bool stop = false;
    }
}

/* --- 全体共有する変数用のスクリプトです --- */

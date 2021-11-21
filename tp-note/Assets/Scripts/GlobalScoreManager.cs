using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScoreManager : MonoBehaviour
{
    static private int globalStrikes = 0;

    public static void addGlobalStrikes()
    {
        globalStrikes += 1;
    }

    public static int getGlobalStrikes()
    {
        return globalStrikes;
    }
}

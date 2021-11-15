using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HealthLeft
{
    static int Health;

    public static void setHealth(int Health, int num)
    {
        Health -= num;
    }
}

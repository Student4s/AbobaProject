using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crutch : MonoBehaviour
{
    public delegate void ChangeTurn();
    public static event ChangeTurn Change;

    public void Test1()
    {
        Change();
    }
}

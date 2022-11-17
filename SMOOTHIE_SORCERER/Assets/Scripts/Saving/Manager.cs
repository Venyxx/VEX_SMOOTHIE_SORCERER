using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
public static Manager Instance {get; set;}

private void Awake ()
{
    Instance = this;
    DontDestroyOnLoad(gameObject);
}
public int currentLevel = 0;
public int menuFocus = 0;



}

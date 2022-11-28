using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
public static Manager Instance {set; get;}

public Material wallMaterial;
public GameObject[] roomThemeGameObjects = new GameObject[8];
public Material[] roomWallPapers = new Material[8];

private void Awake ()
{
    DontDestroyOnLoad(gameObject);
    Instance = this;
    
}
public int currentLevel = 0;
public int menuFocus = 0;



}

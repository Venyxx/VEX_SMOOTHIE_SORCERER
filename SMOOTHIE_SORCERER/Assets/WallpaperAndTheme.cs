using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallpaperAndTheme : MonoBehaviour
{
    private GameObject RoomPrefab;
    private Material roomMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        RoomPrefab = GameObject.Find("Smoothie_Room");
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveManager.Instance.state.activePaper == 0)
            ChangingMaterial("W_Chismas");
        else if (SaveManager.Instance.state.activePaper == 1)
            ChangingMaterial("W_Tropical");
        else if (SaveManager.Instance.state.activePaper == 2)
            ChangingMaterial("s1");//TEMP  
        else if (SaveManager.Instance.state.activePaper == 3)
            ChangingMaterial("W_Scurry");
        else if (SaveManager.Instance.state.activePaper == 4)
            ChangingMaterial("W_Tails_Of_Yarn");
        else if (SaveManager.Instance.state.activePaper == 5)
            ChangingMaterial("W_MelodyKnight");
        else if (SaveManager.Instance.state.activePaper == 6)
            ChangingMaterial("s2"); // temp
        else if (SaveManager.Instance.state.activePaper == 7)
            ChangingMaterial("s3");
    }

    private void ChangingMaterial( string MaterialName )
    {
        if (!GameObject.Find("Smoothie_Room_Improved"))
        return;

        var room = GameObject.Find("Smoothie_Room_Improved");
        roomMaterial = Resources.Load<Material>(MaterialName);
        MeshRenderer mat = room.GetComponent<MeshRenderer>();      
        mat.material = roomMaterial;
    }
}

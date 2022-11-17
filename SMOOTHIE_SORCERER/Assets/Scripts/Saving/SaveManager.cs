using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get;}
    public SaveState state;

        private void Awake ()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));
    }

    //save whole state
    public void Save ()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    //Load last state
    public void Load ()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        } else
        {
            state = new SaveState();
            Save();
            Debug.Log("no prev save, making file");
        }
    }

    //Check if item is owned
    public bool IsColorOwned(int index)
    {
        //check if bit is set, if yes its owned
        return (state.colorOwned & (1 << index)) != 0;
    }

    //unlock a color way
    public void UnlockColor (int index)
    {
        state.colorOwned |= 1 << index;
    }

    //reset the save
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}



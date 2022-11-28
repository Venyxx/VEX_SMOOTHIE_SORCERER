using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get;}
    public SaveState state;

        private void Awake ()
    {
        //ResetSave();
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        
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

    //Check if item wallpaper color is owned
    public bool IsPaperOwned(int index)
    {
        //check if bit is set, if yes its owned
        return (state.paperOwned & (1 << index)) != 0;
    }

    //Check if item wallpaper color is owned
    public bool IsThemeOwned(int index)
    {
        //check if bit is set, if yes its owned
        return (state.themeOwned & (1 << index)) != 0;
    }

    //try to buy color paper
    public bool BuyPaper( int index, int cost)
    {
        if (state.Money >= cost)
        {
            //enough cash
            state.Money  -= cost;
            UnlockPaper(index);

            //save
            Save();
            return true;
        }
        else 
        {
            //broke 
            return false;
        }
    }

    //try to buy theme
    public bool BuyTheme( int index, int cost)
    {
        if (state.Money >= cost)
        {
            //enough cash
            state.Money  -= cost;
            UnlockTheme(index);

            //save
            Save();
            return true;
        }
        else 
        {
            //broke 
            return false;
        }
    }


    //unlock a color way
    public void UnlockPaper (int index)
    {
        state.paperOwned |= 1 << index;
    }

     //unlock a theme way
    public void UnlockTheme (int index)
    {
        state.themeOwned |= 1 << index;
    }

    //complete level
    public void CompleteLevel (int index)
    {
        Debug.Log("tried to run complete level");
        //if current lvl 
        if (state.completedLevel == index)
        {
            state.completedLevel++;
            Debug.Log("level completed max is: " + state.completedLevel);
            Save();
        }
    }

    //reset the save
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconControl : MonoBehaviour
{
    public int CupType;
    //This finds the image
    Image m_Image;
    //This creates the array
    Sprite[] Icons = new Sprite[3];
    //These are the three public sprites that we will use
    public Sprite Coconut;
    public Sprite Boot;
    public Sprite Barber;
    

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Icons[0] = Coconut;
        Icons[1] = Boot;
        Icons[2] = Barber;


        m_Image.sprite = Icons[CupType];

        
    }
}

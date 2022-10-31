using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomerOrder : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] public bool wantStrawberry;
    [SerializeField] public bool wantBlueberry;
    [SerializeField] public bool wantBanana;

     [Header("Potion")]
    [SerializeField] public bool wantInvis;
    [SerializeField] public bool wantPolymorph;
    [SerializeField] public bool wantSpeed;

    [Header("Sprites Red")]
    public GameObject coconutSpriteRed;
    public GameObject barberCupSpriteRed;
    public GameObject shoeSpriteRed;

    [Header("Sprites Blue")]
    public GameObject coconutSpriteBlue;
    public GameObject barberCupSpriteBlue;
    public GameObject shoeSpriteBlue;

    [Header("Sprites Yellow")]
    public GameObject coconutSpriteYellow;
    public GameObject barberCupSpriteYellow;
    public GameObject shoeSpriteYellow;


    private bool choseOrder;
    private bool chosePotion;
    public RailWaypointNav charREF;

    int xPotion;
    int xOrder;
    
    // Start is called before the first frame update
    void Start()
    {
         xOrder = UnityEngine.Random.Range(1, 3);
         xPotion = UnityEngine.Random.Range(1, 3);
        choseOrder = false;
        chosePotion = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!choseOrder && charREF.clickedStartingOrder)
        {
            chooseTheOrder();
        }


    }

    void chooseTheOrder ()
    {
        if (xPotion == 1 && xOrder == 1)
        {
            Debug.Log("customer wants invis // straw banana // yellow glass");
            wantStrawberry = true;
            wantBanana = true;
            wantInvis = true;
            barberCupSpriteYellow.SetActive(true);

        } else if  (xPotion == 2 && xOrder == 1)
        {
            Debug.Log("customer wants polymorph // straw banana // yellow coconut");
            wantStrawberry = true;
            wantBanana = true;
            wantPolymorph = true;
            coconutSpriteYellow.SetActive(true);
        }
        else if  (xPotion == 3 && xOrder == 1)
        {
            Debug.Log("customer wants speed// straw banana // yellow shoe");
            wantStrawberry = true;
            wantBanana = true;
            wantSpeed = true;
            shoeSpriteYellow.SetActive(true);
        }
       
          else if (xPotion == 1 && xOrder == 2)
        {
            Debug.Log("customer wants invis // blueberry banan // blue glass");
            wantBlueberry = true;
            wantBanana = true;
            wantInvis = true;
            barberCupSpriteBlue.SetActive(true);
        }
         else if (xPotion == 2 && xOrder == 2)
        {
            Debug.Log("customer wants polymorph // blueberry banan // blue coconut");
            wantBlueberry = true;
            wantBanana = true;
            wantPolymorph = true;
            coconutSpriteBlue.SetActive(true);
        }
          else if (xPotion == 3 && xOrder == 2)
        {
            Debug.Log("customer wants speed // blueberry banan // blue shoe");
            wantBlueberry = true;
            wantBanana = true;
            wantSpeed = true;
            shoeSpriteBlue.SetActive(true);
        }
          else if (xPotion == 1 && xOrder == 3)
        {
            Debug.Log("customer wants invis // blueberry straw // red glass");
            wantBlueberry = true;
            wantStrawberry = true;
            wantInvis = true;
            barberCupSpriteRed.SetActive(true);
        }
             else if (xPotion == 2 && xOrder == 3)
        {
            Debug.Log("customer wants polymorph // blueberry straw // red coconut");
            wantBlueberry = true;
            wantStrawberry = true;
            wantPolymorph = true;
            coconutSpriteRed.SetActive(true);
        }
             else if (xPotion == 3 && xOrder == 3)
        {
            Debug.Log("customer wants speed // blueberry straw // red shoe");
            wantBlueberry = true;
            wantStrawberry = true;
            wantSpeed = true;
            shoeSpriteRed.SetActive(true);
        }
       

        choseOrder = true;
    }
    void chooseOrder()
    {
        if (xOrder == 1)
        {
            Debug.Log("customer wants strawberry banana");
            wantStrawberry = true;
            wantBanana = true;
            wantBlueberry = false;

        } else if  (xOrder == 2)
        {
            Debug.Log("customer wants strawberry blueberry");
            wantStrawberry = true;
            wantBanana = false;
            wantBlueberry = true;
        }
        else if  (xOrder == 3)
        {
            Debug.Log("customer wants banana blueberry");
            wantStrawberry = false;
            wantBanana = true;
            wantBlueberry = true;
        }

        choseOrder = true;
    }
}

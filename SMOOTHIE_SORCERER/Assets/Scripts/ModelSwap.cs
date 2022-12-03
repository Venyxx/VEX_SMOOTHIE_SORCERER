using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwap : MonoBehaviour
{
    [SerializeField] public GameObject Human, Trans;
    // Start is called before the first frame update
    void Start()
    {
        Trans.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CatSwap()
    {
        Trans.SetActive(true);
        Human.SetActive(false);
    }

    
}

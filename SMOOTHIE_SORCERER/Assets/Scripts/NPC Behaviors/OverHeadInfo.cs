using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OverHeadInfo : MonoBehaviour
{
    public GameObject spritePrefab;
    protected Image Order;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Order = Instantiate(spritePrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Order.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);

    }
}

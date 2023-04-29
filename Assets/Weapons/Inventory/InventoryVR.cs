// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        // Check if the thumbstick is pulled up
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > 0.8f)
        {
            if (!UIActive)
            {
                UIActive = true;
                Inventory.SetActive(UIActive);
            }
        }
        else if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < 0.2f)
        {
            if (UIActive)
            {
                UIActive = false;
                Inventory.SetActive(UIActive);
            }
        }

        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}

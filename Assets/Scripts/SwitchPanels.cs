using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanels : MonoBehaviour
{
    // All the following will be disabled
    public GameObject disable1;
    public GameObject disable2;
    public GameObject disable3;
    public GameObject disable4;
    public GameObject disable5;
    public GameObject disable6;
    public GameObject disable7;
    public GameObject disable8;
    public GameObject disable9;

    // This will be enabled
    public GameObject enable1;

    public void Switch()
    {
        disable1.SetActive(false);
        disable2.SetActive(false);
        disable3.SetActive(false);
        disable4.SetActive(false);
        disable5.SetActive(false);
        disable6.SetActive(false);
        disable7.SetActive(false);
        disable8.SetActive(false);
        disable9.SetActive(false);

        enable1.SetActive(true);
    }

    public void Back()
    {
        disable1.SetActive(true);
        disable2.SetActive(true);
        disable3.SetActive(true);
        disable4.SetActive(true);
        disable5.SetActive(true);
        disable6.SetActive(true);
        disable7.SetActive(true);
        disable8.SetActive(true);
        disable9.SetActive(true);

        enable1.SetActive(false);
    }
}

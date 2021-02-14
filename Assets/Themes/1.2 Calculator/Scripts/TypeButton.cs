using UnityEngine;

public class TypeButton : MonoBehaviour
{
    private bool isStandart  = true;
    private bool isScientific = false;

    private string standartType = "Standart";
    private string scientificType = "Scientific";

    private GameObject[] scientificPanels;
    private GameObject[] stantartPanels;

    private void Awake()
    {
        scientificPanels = GameObject.FindGameObjectsWithTag(scientificType);
        stantartPanels = GameObject.FindGameObjectsWithTag(standartType);
    }

    private void Update()
    {
        Switch();
    }

    public void PressStandart()
    {
        isStandart = true;
        isScientific = false;        
    }

    public void PressScientific()
    {
        isScientific = true;
        isStandart = false;
    }

    private void Switch()
    {
        if (isStandart)
        {
            SwitchPanels(stantartPanels, true);
            SwitchPanels(scientificPanels, false);

        }
        else if (isScientific)
        {
            SwitchPanels(stantartPanels, false);
            SwitchPanels(scientificPanels, true);
        }
    }

    private void SwitchPanels(GameObject[] panels, bool onOff)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(onOff);
        }
    }
}


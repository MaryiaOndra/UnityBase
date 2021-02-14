using UnityEngine;
using TMPro;

namespace UnityBase.Calculator
{
    [RequireComponent(typeof(RectTransform))]
    public class CalculatorPanels : MonoBehaviour
    {
        [SerializeField] private TMP_Text typeName;
        [SerializeField] private GameObject converterPanel;
        [SerializeField] private GameObject extraConverterPanel;

        private string standartType = "Standart";
        private string scientificType = "Scientific";
        private string lenghtType = "Lenght";
        private string volumeType = "Volume";

        private GameObject[] scientificPanels;
        private GameObject[] stantartPanels;

        private RectTransform panelsRect;
        private Vector2 calculatorPanelMaxAnchors = new Vector2(1, 0.7f);
        private Vector2 converterPanelMaxAnchors = new Vector2(1, 0.4f);

        private void Awake()
        {
            scientificPanels = GameObject.FindGameObjectsWithTag(scientificType);
            stantartPanels = GameObject.FindGameObjectsWithTag(standartType);

            panelsRect = GetComponent<RectTransform>();

            ShowStandart(true);

            converterPanel.SetActive(false);
        }

        private void Update()
        {
            if (converterPanel.activeSelf)
            {
                panelsRect.anchorMax = converterPanelMaxAnchors;
                extraConverterPanel.SetActive(true);
            }
            else
            {
                panelsRect.anchorMax = calculatorPanelMaxAnchors;
                extraConverterPanel.SetActive(false);
            }
        }

        public void ShowStandart(bool empty)
        {
            typeName.text = standartType;

            SwitchPanels(stantartPanels, true);
            SwitchPanels(scientificPanels, false);

            converterPanel.SetActive(false);
        }

        public void ShowScientific(bool empty)
        {
            typeName.text = scientificType;

            SwitchPanels(scientificPanels, true);
            SwitchPanels(stantartPanels, false);

            converterPanel.SetActive(false);
        }

        public void ShowLenghtConverter(bool empty)
        {
            typeName.text = lenghtType;

            SwitchPanels(scientificPanels, false);
            SwitchPanels(stantartPanels, false);

            converterPanel.SetActive(true);
        }

        public void ShowVolumeConverter(bool empty)
        {
            typeName.text = volumeType;

            SwitchPanels(scientificPanels, false);
            SwitchPanels(stantartPanels, false);

            converterPanel.SetActive(true);
        }

        private void SwitchPanels(GameObject[] panels, bool onOff)
        {
            foreach (var panel in panels)
            {
                panel.SetActive(onOff);
            }
        }
    }
}

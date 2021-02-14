using TMPro;
using UnityEngine;

namespace UnityBase.Calculator
{
    public class VolumeConverter : DropdownConverter<ConverterEnums.VolumeTypes>
    {
        [SerializeField] private TMP_Text resultField;
        [SerializeField] private DropdownBottomVolume bottomVolume;

        private double convertedResult;
        private double resultInLiters;
        private double inputResult;

        private int topIndex = 0;
        private int bottomIndex = 0;

        private void Update()
        {
            inputResult = gameObject.GetComponentInParent<ConverterPanels>().InputResult;
            bottomIndex = bottomVolume.BottomIndex;

            ConvertToLiters(topIndex);
            ConvertVolume(bottomIndex);
            resultField.text = convertedResult.ToString();
        }

        public void AddTopIndex(int index)
        {
            topIndex = index;
        }

        private void ConvertToLiters(int index)
        {
            switch (index)
            {
                case (int)ConverterEnums.VolumeTypes.CubicCentimetres:
                    resultInLiters = inputResult / 1000;
                    break;
                case (int)ConverterEnums.VolumeTypes.CubicFoot:
                    resultInLiters = inputResult * 28.317f;
                    break;
                case (int)ConverterEnums.VolumeTypes.CubicInches:
                    resultInLiters = inputResult / 31.024f;
                    break;
                case (int)ConverterEnums.VolumeTypes.CubicMeter:
                    resultInLiters = inputResult * 1000;
                    break;
                case (int)ConverterEnums.VolumeTypes.Milliliters:
                    resultInLiters = inputResult / 1000;
                    break;
                case (int)ConverterEnums.VolumeTypes.CupsUS:
                    resultInLiters = inputResult / 4.161f;
                    break;
                case (int)ConverterEnums.VolumeTypes.PintsUS:
                    resultInLiters = inputResult / 2.113f;
                    break;
                case (int)ConverterEnums.VolumeTypes.Liters:
                    resultInLiters = inputResult;
                    break;
            }
        }

        private void ConvertVolume(int index)
        {
            switch (index)
            {
                case (int)ConverterEnums.VolumeTypes.CubicCentimetres:
                    convertedResult = resultInLiters * 1000;
                    break;
                case (int)ConverterEnums.VolumeTypes.CubicFoot:
                    convertedResult = resultInLiters / 28.317f;
                    break;
                case (int)ConverterEnums.VolumeTypes.CubicInches:
                    convertedResult = resultInLiters * 31.024f;
                    break;
                case (int)ConverterEnums.VolumeTypes.CubicMeter:
                    convertedResult = resultInLiters / 1000;
                    break;
                case (int)ConverterEnums.VolumeTypes.Milliliters:
                    convertedResult = resultInLiters * 1000;
                    break;
                case (int)ConverterEnums.VolumeTypes.CupsUS:
                    convertedResult = resultInLiters * 4.161f;
                    break;
                case (int)ConverterEnums.VolumeTypes.PintsUS:
                    convertedResult = resultInLiters * 2.113f;
                    break;
                case (int)ConverterEnums.VolumeTypes.Liters:
                    convertedResult = resultInLiters;
                    break;
            }
        }
    }
}


namespace UnityBase.Calculator
{
    public class DropdownBottomVolume : DropdownConverter<ConverterEnums.VolumeTypes>
    {
        public int BottomIndex { get; private set; }

        public void AddBottomIndex(int index)
        {
            BottomIndex = index;
        }
    }
}

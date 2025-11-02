using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Ui
{
    public class ManaStatusBar : MonoBehaviour
    {
        [SerializeField] private Slider _manaCapacitySlider;

        public void SetMaxValue(float maxValue) =>
            _manaCapacitySlider.maxValue = maxValue;

        public void SetValue(float value) =>
            _manaCapacitySlider.value = value;
    }
}
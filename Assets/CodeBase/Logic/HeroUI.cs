using CodeBase.Ui;
using UnityEngine;

namespace CodeBase.Logic
{
    public class HeroUI : MonoBehaviour
    {
        [SerializeField] private ManaStatusBar _statusBar;
        private IManaHolder _manaHolder;

        public void Construct(IManaHolder manaHolder, float maxManaValue)
        {
            _manaHolder = manaHolder;
            _statusBar.SetMaxValue(maxManaValue);
            _statusBar.SetValue(maxManaValue);
            manaHolder.OnManaCapacityChanged += ChangeStatusBar;
        }

        private void ChangeStatusBar()
        {
            _statusBar.SetValue(_manaHolder.ManaCapacity);
        }
    }
}
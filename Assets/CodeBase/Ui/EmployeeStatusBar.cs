using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Ui
{
    public class EmployeeStatusBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        
        public void SetValue(float current, float max)
        {
            _fill.fillAmount = current / max;
        }
    }
}
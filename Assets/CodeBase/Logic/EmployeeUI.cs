using CodeBase.Employee;
using CodeBase.Ui;
using UnityEngine;

namespace CodeBase.Logic
{
    public class EmployeeUI : MonoBehaviour
    {
        [SerializeField] private EmployeeStatusBar _statusBar;
        [SerializeField] private EmployeeRecruitment _recruitment;

        private void Start()
        {
            _recruitment.OnManaChanged += ManaChanged;
        }

        private void ManaChanged() =>
            _statusBar.SetValue(_recruitment.RecruitProgress,  _recruitment.ManaToRecruit);

        private void OnDestroy()
        {
            _recruitment.OnManaChanged -= ManaChanged;
        }
    }
}
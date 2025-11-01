using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase
{
    public class WriteLog
    {
        public static void StateLog(IExitableState state)
        {
            Debug.Log($"Entered state: {state.GetType()}");
        }
    }
}
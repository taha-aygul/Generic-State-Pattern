using System.Collections;
using UnityEngine;

namespace StateMachine
{
    public interface IState<T> where T : Component
    {
        void EnterState(T controller);
        void UpdateState(T controller);
        void ExitState(T controller);
    }



}


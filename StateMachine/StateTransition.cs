using System;
using UnityEngine;

namespace StateMachine
{
    public class StateTransition<T> where T : MonoBehaviour
    {
        public IState<T> From { get; }
        public IState<T> To { get; }
        public System.Func<bool> Condition { get; }

        public StateTransition(IState<T> from, IState<T> to, Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }









}


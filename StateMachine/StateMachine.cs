using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine<T> where T : MonoBehaviour
    {
        IState<T> _currentState;

        readonly List<StateTransition<T>> _stateTransitions;
        readonly List<StateTransition<T>> _anyStateTransitions;
        public void UpdateState(T controller)
        {
            IState<T> state = CheckStateTransition();

            if (state != null)
            {
                SetState(state, controller);
            }
            _currentState.UpdateState(controller);
        }
        private IState<T> CheckStateTransition()
        {
            foreach (var transition in _stateTransitions)
            {
                if (transition.Condition.Invoke())
                {
                    return transition.To;
                }

            }
            foreach (var transition in _anyStateTransitions)
            {
                if (transition.Condition.Invoke() && transition.From.Equals(_currentState))
                {
                    return transition.To;
                }
            }

            return null;
        }


        public void SetState(IState<T> state, T controller)
        {
            if (state.Equals(_currentState)) return;

            Debug.Log("State Transition From: " + state.ToString() + " To: " + _currentState.ToString());
            _currentState?.ExitState(controller);
            _currentState = state;
            _currentState.EnterState(controller);
        }

        public void SetNormalStateTransition(IState<T> from, IState<T> to, System.Func<bool> condition)
        {
            _stateTransitions.Add(new StateTransition<T>(from, to, condition));
        }
        public void SetAnyStateTransition(IState<T> to, System.Func<bool> condition)
        {
            _anyStateTransitions.Add(new StateTransition<T>(null, to, condition));
        }
    }

}


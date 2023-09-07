using System.Collections.Generic;
using UnityEngine;

namespace DEEPP.Model.Data.Events
{
    [CreateAssetMenu(fileName = "Game event", menuName = "Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _eventListeners = new();

        public void Raise()
        {
            foreach (var eventListener in _eventListeners)
                eventListener.OnEventRaised();
        }

        public void RegisterEventListener(GameEventListener eventListener)
        {
            if (!_eventListeners.Contains(eventListener))
                _eventListeners.Add(eventListener);
        }

        public void UnRegisterEventListener(GameEventListener eventListener)
        {
            if (_eventListeners.Contains(eventListener))
                _eventListeners.Remove(eventListener);
        }
    }
}
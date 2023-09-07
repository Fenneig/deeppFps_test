using UnityEngine;
using UnityEngine.Events;

namespace DEEPP.Model.Data.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _event;
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            _event.RegisterEventListener(this);
        }

        private void OnDisable()
        {
            _event.UnRegisterEventListener(this);
        }

        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}
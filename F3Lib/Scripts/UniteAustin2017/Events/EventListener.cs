using System.Collections.Generic;

using UnityEngine;

namespace F3Lib.Events
{
    public class EventListener : MonoBehaviour
    {
        public List<EventItemListener> events = new List<EventItemListener>();

        private void OnEnable()
        {
            foreach (EventItemListener item in events)
            {
                if (item.Event) item.Event.RegisterListener(item);
            }
        }

        private void OnDisable()
        {
            foreach (EventItemListener item in events)
            {
                if (events.Contains(item)) item.Event.UnregisterListener(item);
            }
        }
    }
}
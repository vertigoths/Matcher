using System;
using System.Collections.Generic;
using Matching.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Matching.Controller
{
    public class ClickController : MonoBehaviour
    {
        private int _uiLayer;
        private Matcher _matcher;

        private void Start()
        {
            _uiLayer = LayerMask.NameToLayer("UI");
            _matcher = FindObjectOfType<Matcher>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && IsPointerOverUIElement() != null)
            {
                String cellName = IsPointerOverUIElement();

                if (!cellName.Equals("Grid"))
                {
                    _matcher.OnClick(Map.cells, cellName[3] - '0', cellName[1] - '0');
                }
            }
        }

        ///Returns 'true' if we touched or hovering on Unity UI element.
        public String IsPointerOverUIElement()
        {
            return GetClickedCell(GetEventSystemRaycastResults());
        }
        
        //Gets all event system raycast results of current mouse or touch position.
        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            return raycastResults;
        }
        
        //Returns 'true' if we touched or hovering on Unity UI element.
        private String GetClickedCell(List<RaycastResult> eventSystemRaycastResults)
        {
            for (int index = 0; index < eventSystemRaycastResults.Count; index++)
            {
                RaycastResult curRaycastResult = eventSystemRaycastResults[index];
                
                if (curRaycastResult.gameObject.layer == _uiLayer)
                    return eventSystemRaycastResults[index].gameObject.name;
            }
            return null;
        }
    }
}

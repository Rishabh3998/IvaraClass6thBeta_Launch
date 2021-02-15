using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    public GameObject AR_object;
    public Camera AR_Camera;
    public ARRaycastManager raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(AR_object, pose.position, pose.rotation);
            }
        }
        
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;

// public class PlaceModel : MonoBehaviour
// {
//     // Start is called before the first frame update

//     [SerializeField]
//     private GameObject place_object;

//     [SerializeField]
//     private ARSessionOrigin ar_session_origin;

//     public List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();

//     private GameObject obj = null;


//     // Update is called once per frame
//     void Update()
//     {
//         // Check for the tap on screen
//         if(Input.GetMouseButton(0))
//         {
//             // Cast a ray from the touch position to the plane

//             bool collision = ar_session_origin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycast_hits, TrackableType.PlaneWithinPolygon);

//             if(collision && obj == null)
//             {
//                obj =Instantiate(place_object);
//             }
//             obj.transform.position = raycast_hits[0].pose.position;
//         }


//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;

// [RequireComponent(typeof(ARRaycastManager))]

// public class PlaceModel : MonoBehaviour
// {
    
//     public GameObject gameObjectToInstantiate;
//     private GameObject spawnedObject;
//     private ARRaycastManager _arRaycastManager;
//     private Vector2 touchPosition;

//     static List<ARRaycastHit> hits = new List<ARRaycastHit>();

//     private void Awake(){

//         _arRaycastManager = GetComponent<ARRaycastManager>();
//     }

//     bool TryGetTouchPosition(out Vector2 touchPosition){
//         if(Input.touchCount > 0){
//             touchPosition = Input.GetTouch(index: 0).position;
//             return true;
//         }
//         touchPosition = default;
//         return false;
//     }
    
//     void Update()
//     {
//         if(!TryGetTouchPosition(out Vector2 touchPosition))
//             return;

//         if(_arRaycastManager.Raycast(touchPosition , hits , TrackableType.PlaneWithinPolygon)){
//             var hitPose = hits[0].pose;

//             if(spawnedObject == null)
//             {

//                 spawnedObject = Instantiate(gameObjectToInstantiate , hitPose.position , hitPose.rotation);
            
//             }
//             else{
//                 spawnedObject.transform.position = hitPose.position;
//             }

//         }    
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWiggle : MonoBehaviour
{
     public GameObjectSet fishes;
     Vector3 averagePos;
     public static Vector3 midPoint = new Vector3(0.25f,10f,0.25f);

     //TODO: optimize so FindGameObject is only called on new Player
     // Update is called once per frame
     void Update(){
          if (fishes.Count > 0)
          {
               FollowPos();
          }
     }

     //TODO: no blackmagic
     public void FollowPos(){
          averagePos = GetAveragePos(fishes);
          averagePos = new Vector3((averagePos.x * midPoint.x), (midPoint.y),(averagePos.z * midPoint.z - 5));

          //assign
          Camera.main.transform.position = averagePos;
          // Debug.Log("Cam transform workin! - " + averagePos);
     }

     //gets average transforms of player instances
     public Vector3 GetAveragePos(GameObjectSet fishes){
          Vector3 averagePos = Vector3.zero;

          foreach (GameObject gameObject in fishes.items)
            averagePos += gameObject.transform.position;

          return ((averagePos + midPoint) / (fishes.Count +1)); //midPoint so cam wont fuck off into Nomansland
     }
}

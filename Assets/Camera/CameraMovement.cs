using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     public GameObjectSet fishes;
     public static Vector3 midPoint = new Vector3(0.25f,10f,0.25f);
     Vector3 averagePos;
     float moveSpeed = 0.25f;

     void FixedUpdate(){
          FollowPos();
     }

     private void FollowPos(){
          //get averagePos of fishes + midpoint
          averagePos = GetAveragePos(fishes);
          averagePos = new Vector3((averagePos.x * midPoint.x), (midPoint.y),(averagePos.z * midPoint.z - 5));

          //assign to cam
          float step = moveSpeed * Time.fixedDeltaTime; //how fast cam moves towards target(averagePos)
          Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, averagePos, step);
     }

     //gets average transforms of fish instances
     public Vector3 GetAveragePos(GameObjectSet fishes){
          foreach (GameObject gameObject in fishes.items)
          averagePos += gameObject.transform.position;

          return ((averagePos + midPoint) / (fishes.Count +1)); //midPoint so cam wont fuck off into Nomansland
     }
     
}

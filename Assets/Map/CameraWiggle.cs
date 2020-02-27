using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWiggle : MonoBehaviour
{
     public ScreenManager screenManager;
     public GameObject[] players;
     Vector3 averagePos;
     Vector3 mainCamPos;

     public static Vector3 midPoint = new Vector3(0.25f,10f,0.25f);

     // Start is called before the first frame update
     void Start(){
     }

     //TODO: optimize so FindGameObject is only called on new Player
     // Update is called once per frame
     void Update(){
          players = GameObject.FindGameObjectsWithTag("Fish");
          if (players.Length > 0)
          {
               FollowPos();
          }
     }

     //TODO: no blackmagic
     public void FollowPos(){
          averagePos = GetAveragePos(players);
          averagePos = new Vector3((averagePos.x * midPoint.x), (midPoint.y),(averagePos.z * midPoint.z - 5));

          //assign
          Camera.main.transform.position = averagePos;
          // Debug.Log("Cam transform workin! - " + averagePos);
     }

     //gets average transforms of player instances
     public Vector3 GetAveragePos(GameObject[] players){
          Vector3 averagePos = Vector3.zero;
          Vector3[] positions = new Vector3[players.Length];
               for (int i = 0; i < players.Length; i++){
                   positions[i] = players[i].transform.position;
                   averagePos += positions[i];
               }
               return ((averagePos + midPoint) / (players.Length +1)); //midPoint so cam wont fuck off into Nomansland
     }
}

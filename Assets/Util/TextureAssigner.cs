using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PG
 * This script assigns a random material out of a Material array to the player character upon spawn.
 * it should never assign two players the same material, as long as the amount of materials is bigger or equal to the amount of players.
 * !!!!!!!!!!!!!!!!!!!!!!TODO!!!!!!!!!!!!!!!!!!!!!!! Test with multiple players as i cannot test it with only one gamepad
 */

public class TextureAssigner : MonoBehaviour
{
    public Material[] m_Mats = new Material[6]; //PG Materials assigned in Unity to the array
    public static List<Material> used_Mats = new List<Material>(); //PG List of used Materials; important to prevent reuse
    System.Random r = new System.Random();
    int maxPlayerCount=6; //PG the highest amount of players allowed; important to avoid endless loop
    

    private void Awake()
    {
        int curr_Rand;
        if (maxPlayerCount > m_Mats.Length) //PG if the amount of players is higher than amount of mats the code in else would loop endlessly
        {
            curr_Rand = r.Next(0, m_Mats.Length);
            gameObject.GetComponent<MeshRenderer>().material = m_Mats[curr_Rand];
        }
        else
        {
            do //PG assign a new material until you find one that hasn't been used yet; NOT OPTIMISED YET!!!!! TODO: Optimise used_Mat<Material> list to used_Mat<int> and ennumberate the materials
            {
                curr_Rand = r.Next(0, m_Mats.Length);
                Debug.Log(curr_Rand);
                gameObject.GetComponent<MeshRenderer>().material = m_Mats[curr_Rand];
            } while (used_Mats.Contains(m_Mats[curr_Rand]));
            used_Mats.Add(m_Mats[curr_Rand]);
        }
    }
}

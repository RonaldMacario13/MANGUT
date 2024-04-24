using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
   public string _tagTargetDetection = "Player";

   public List<Collider2D> detectedObjs = new();

   private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.CompareTag(_tagTargetDetection))
    {
        detectedObjs.Add(collision);
    }
   }

   private void OnTriggerExit2D(Collider2D collision) {
      if (collision.gameObject.CompareTag(_tagTargetDetection)) 
      {
         detectedObjs.Remove(collision);
      }
   }
}

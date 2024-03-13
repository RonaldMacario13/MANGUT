using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyFood() {
        Destroy(gameObject);
    }
}

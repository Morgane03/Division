using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToutch : MonoBehaviour
{
    private void Start()
    {
            Physics.IgnoreLayerCollision(6, 6);
    }
}

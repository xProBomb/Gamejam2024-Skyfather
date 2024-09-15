using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{

    public LayerMask targetMask;

    public bool gameOver = false;
    void Update()
    {
        // raycast to check if there is an enemy within a certain distance sphere radius
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero, 0f, targetMask);
        if (hit.Length > 0)
        {
            gameOver = true;
            // You can add additional logic here, such as displaying a game over screen
            Debug.Log("Game Over!");
        }
    }

}

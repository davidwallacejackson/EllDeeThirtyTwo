using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour, IInput {

    Vector2 currentMove;

	// Update is called once per frame
	void Update () {
        currentMove = Vector3.zero;

        currentMove.x = Input.GetAxis("Horizontal");
        currentMove.y = Input.GetAxis("Vertical");
	}

    public Vector2 GetMoveAxis()
    {
        return currentMove;
    }
}

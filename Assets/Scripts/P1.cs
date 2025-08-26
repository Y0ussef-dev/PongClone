using UnityEngine;
using UnityEngine.InputSystem;

public class P1 : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        bool isPressingUp= Input.GetKey(KeyCode.W);
        bool isPressingDown = Input.GetKey(KeyCode.S);

        if (isPressingUp)
        { 
            transform.Translate(Vector2.up * Time.deltaTime *moveSpeed); 
        }

        if (isPressingDown) { 
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed); 
        }
    }
}
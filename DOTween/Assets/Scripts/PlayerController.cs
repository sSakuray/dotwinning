using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 2f;   
    [SerializeField] private float jumpDuration = 0.5f; 
    [SerializeField] private float jumpDistance = 2f;   
    [SerializeField] private float rotationDuration = 0.3f;
    
    private bool canMove = true; 
    
    private void Update()
    {
        if (!canMove) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateCharacter(-90f);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            RotateCharacter(90f);
        }
    }
    private void Jump()
    {
        if (!canMove) return;
        canMove = false;
        Vector3 jumpTarget = transform.position + transform.forward * jumpDistance + Vector3.up * jumpHeight;
        transform.DOJump(jumpTarget, jumpHeight, 1, jumpDuration).OnComplete(() => canMove = true);
    }
    private void RotateCharacter(float angle)
    {
        canMove = false;
        transform.DORotate(transform.eulerAngles + Vector3.up * angle, rotationDuration)
            .OnComplete(() => canMove = true);
    }
}

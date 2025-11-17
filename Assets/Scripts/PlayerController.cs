using FishNet.Object;
using UnityEngine;

// Inherit from NetworkBehaviour instead of MonoBehaviour
public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    void Update()
    {
        // Only run this code on the object the local client owns.
        // This prevents us from moving other players' objects.
        if (!IsOwner)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, vertical);
        if (moveDirection.magnitude > 1f)
            moveDirection.Normalize();

        transform.position += moveSpeed * Time.deltaTime * moveDirection;
        Animator anim = GetComponent<Animator>();
        if (moveDirection.magnitude != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if(horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
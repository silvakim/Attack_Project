using UnityEngine;

public class Move : Photon.Pun.MonoBehaviourPun {

    public float speed = 15;

   // [HideInInspector]
    //public UIControl _uiControl;

    Vector2 velocity;
    Rigidbody2D rb;
    Animator animator;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (photonView.IsMine){ //&& !_uiControl.IsChatWindowActive) {
            velocity.x = Input.GetAxisRaw("Horizontal");
            velocity.y = Input.GetAxisRaw("Vertical");

            //animator.SetBool("IsWalk", velocity.x != 0 || velocity.y != 0);
        }
    }

    private void FixedUpdate() {
        if (photonView.IsMine) {
            rb.MovePosition(rb.position + velocity.normalized * speed * Time.fixedDeltaTime);
        }
    }
}
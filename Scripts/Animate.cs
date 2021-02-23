using UnityEngine;
public class Animate : MonoBehaviour {
    [SerializeField] Animator _animator;
    void Update() {
        if(Input.GetAxis("Horizontal") != 0) {
            _animator.SetBool("isWalking", true);
        } else {
            _animator.SetBool("isWalking", false);
        }
        if(Input.GetButtonUp("Jump")) {
            _animator.SetBool("isGrounded", false);
            _animator.SetTrigger("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            _animator.SetBool("isGrounded", true);
        }
    }
}
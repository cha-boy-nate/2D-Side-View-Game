using UnityEngine;
public class Move : MonoBehaviour {
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _walkSpeed;
    [SerializeField] float _airSpeed;
    [SerializeField] float _jumpThrust;
    bool _isGrounded = false;
    private void Update() {
        if(Input.GetButtonUp("Jump") && _isGrounded) {
            jump();
        }
    }
    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        if(_isGrounded) {
            move(h, _walkSpeed);
        } else {
            move(h, _airSpeed);
        }
    }
    void move(float horizontalMovement, float speed) {
        _rigidbody2D.velocity = new Vector3(horizontalMovement * speed, _rigidbody2D.velocity.y, 0);
    }
    void jump() {
        _isGrounded = false;
        _rigidbody2D.velocity = new Vector2(0, _jumpThrust);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            _isGrounded = true;
        }
    }
}
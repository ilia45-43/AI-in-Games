using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float smooth;

    [SerializeField]
    private float gravity;

    [SerializeField]
    private float speedOfRotation;

    private float vertical;
    private float horizontal;
    private CharacterController player;
    private float fastRun;
    private Vector3 movement;
    private Vector3 smoothMovement;
    private float height;
    private float smoothHeight;

    private Animator _animator;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Animations();
        Move();
    }

    private void Animations()
    {
        if (Input.GetKey(KeyCode.W))
            _animator.SetBool("running", true);
        else
            _animator.SetBool("running", false);
        if (Input.GetKey(KeyCode.LeftShift))
            _animator.SetBool("runfast", true);
        else
            _animator.SetBool("runfast", false);

        if (Input.GetKey(KeyCode.S))
            _animator.SetBool("runback", true);
        else
            _animator.SetBool("runback", false);
    }

    private void Move()
    {
        vertical = Input.GetAxis("Vertical");
        //horizontal = Input.GetAxis("Horizontal");

        Vector3 forward = transform.forward * vertical;
        //Vector3 direction = transform.right * horizontal;
        //movement = (forward + direction) * speed;
        movement = (forward) * speed;

        if (Input.GetKey(KeyCode.LeftShift))
            fastRun = 2f;
        else
            fastRun = 0;

        if (Input.GetKey(KeyCode.D))
        {
            var rat = transform.eulerAngles;
            rat.y += speedOfRotation;

            transform.eulerAngles = rat;
        }
        if (Input.GetKey(KeyCode.A))
        {
            var rat = transform.eulerAngles;
            rat.y -= speedOfRotation;

            transform.eulerAngles = rat;
        }

        if (!player.isGrounded)
        {
            height -= gravity * Time.deltaTime;
        }

        smoothMovement = Vector3.Lerp(smoothMovement, movement, smooth * Time.deltaTime);

        smoothHeight = Mathf.Lerp(smoothHeight, height, smooth * Time.deltaTime);
        smoothMovement.y = smoothHeight;

        player.Move(smoothMovement * Time.deltaTime * (speed + fastRun));
    }
}

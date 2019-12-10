using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private Shooting shooting;
    private Weapon currentWeapon;

    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private Image fastSpeedImage;
    private float fastSpeedSec = 1f;

    private Camera cam;
    private Rigidbody2D rb;

    private Vector2 movement, mousePos;

    public void Initialize(float speed)
    {
        this.speed = speed;
    }
    void Start()
    {
        player = Player.instance;
        cam = Camera.main;
        shooting = GetComponent<Shooting>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
            fastSpeedSec -= Time.deltaTime * 0.2f;
            if (fastSpeedSec < 0f)
            {
                speed = 8f;
                fastSpeedSec = 0f;
            }
        }
        else
        {
            speed = 8f;
            fastSpeedSec += Time.deltaTime * 0.1f;
            if(fastSpeedSec > 1f)
            {
                fastSpeedSec = 1f;
            }
        }
        fastSpeedImage.fillAmount = fastSpeedSec;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        currentWeapon = shooting.GetCurrentWeapon();
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (player.OnMainMenu)
            return;
        rb.MovePosition(rb.position + movement * speed * currentWeapon.Weight * Time.deltaTime);
    }
}

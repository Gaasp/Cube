using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public static GameObject rotate;
    public static PlayerMovement playerMovement2;
    public TMPro.TMP_Text scoreText;
    public static CameraMove cameraMove;
    public static rotatio rotatio;
    public Transform pivot;
    public Camera camera;
    public int step = 9;
    public float speed = 0.01f;
    public bool isRolling = false;
    [SerializeField] float moveSpeed = 0.25f;
    [SerializeField] float rayLength = 1.4f;
    [SerializeField] float rayOffsetX = 0.5f;
    [SerializeField] float rayOffsetY = 0.5f;
    [SerializeField] float rayOffsetZ = 0.5f;
    public bool movement_on_off;
    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;
    Vector3 xOffset;
    Vector3 yOffset;
    Vector3 zOffset;
    Vector3 zAxisOriginA;
    Vector3 zAxisOriginB;
    Vector3 xAxisOriginA;
    Vector3 xAxisOriginB;
    

    [SerializeField] LayerMask walkableMask = 0;

    [SerializeField] LayerMask collidableMask = 0;

    [SerializeField] public float maxFallCastDistance = 100f;
    [SerializeField] float fallSpeed = 30f;
    public bool falling;
    float targetFallHeight;
    bool courtineWork = false;
    public AudioSource source;
    public AudioClip clip;
    public int scoreValue = 0;
    public float cos = 0.1f;
    private void Start()
    {
        movement_on_off = true;
        scoreText = GameObject.Find("UI/Points").GetComponent<TextMeshProUGUI>();
        rotatio = GameObject.Find("Player/Pivot/PlayerModel/Rotation").GetComponent<rotatio>();
        
    }
    void Update()
    {
       
        scoreText.text = "Score: " + scoreValue;
        // Set the ray positions every frame

        yOffset = transform.position + Vector3.up * rayOffsetY;
        zOffset = Vector3.forward * rayOffsetZ;
        xOffset = Vector3.right * rayOffsetX;

        zAxisOriginA = yOffset + xOffset;
        zAxisOriginB = yOffset - xOffset;

        xAxisOriginA = yOffset + zOffset;
        xAxisOriginB = yOffset - zOffset;

        // Draw Debug Rays
        Debug.DrawLine(zAxisOriginA,Vector3.forward, Color.green, Time.deltaTime);
        Debug.DrawLine(
                zAxisOriginA,
                zAxisOriginA + Vector3.forward * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                zAxisOriginB,
                zAxisOriginB + Vector3.forward * rayLength,
                Color.red,
                Time.deltaTime);

        Debug.DrawLine(
                zAxisOriginA,
                zAxisOriginA + Vector3.back * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                zAxisOriginB,
                zAxisOriginB + Vector3.back * rayLength,
                Color.red,
                Time.deltaTime);

        Debug.DrawLine(
                xAxisOriginA,
                xAxisOriginA + Vector3.left * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                xAxisOriginB,
                xAxisOriginB + Vector3.left * rayLength,
                Color.red,
                Time.deltaTime);

        Debug.DrawLine(
                xAxisOriginA,
                xAxisOriginA + Vector3.right * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                xAxisOriginB,
                xAxisOriginB + Vector3.right * rayLength,
                Color.red,
                Time.deltaTime);

       if (courtineWork == false)
        {
            if (falling)
            {
                if (transform.position.y <= targetFallHeight)
                {
                    float x = Mathf.Round(transform.position.x);
                    float y = Mathf.Round(targetFallHeight);
                    float z = Mathf.Round(transform.position.z);

                    transform.position = new Vector3(x, y, z);

                    falling = false;

                    return;
                }

                transform.position += Vector3.down * fallSpeed * Time.deltaTime;
                return;
            }
            else if (moving)
            {
                if (Vector3.Distance(startPosition, transform.position) > 1f)
                {
                    float x = Mathf.Round(targetPosition.x);
                    float y = Mathf.Round(targetPosition.y);
                    float z = Mathf.Round(targetPosition.z);

                   transform.position = new Vector3(x, y, z);

                    moving = false;

                    return;
                }

                transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
                return;
            }
            else
            {
                RaycastHit[] hits = Physics.RaycastAll(
                        transform.position + Vector3.up * 0.5f,
                        Vector3.down,
                        maxFallCastDistance,
                        walkableMask
                );

                if (hits.Length > 0)
                {
                    int topCollider = 0;
                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (hits[topCollider].collider.bounds.max.y < hits[i].collider.bounds.max.y)
                            topCollider = i;
                    }
                    if (hits[topCollider].distance > 1f)
                    {
                        targetFallHeight = transform.position.y - hits[topCollider].distance + 0.9f;
            
                        falling = true;
                    }
                }
                else
                {
                    targetFallHeight = -Mathf.Infinity;
                    falling = true;
                }
            }

        }
        if (movement_on_off == true)
        {
            move();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            movement_on_off = false;
        }

    }

    //private Vector3 prosto;
    //private Vector3 tyl;
    //private Vector3 lewo;
    //private Vector3 prawo;
    public void move()
    {
        if (rotatio.rotationLocal == 0)
        {
            if (Input.GetKey(KeyCode.W) && !isRolling && !falling)
            {
                //if (camera.transform.rotation.y <= -45)
                //{
                //    prosto = Vector3.forward;
                //}

                if (CanMove(Vector3.forward)) //daj dam back
                {
                    StartCoroutine(MoveForward());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.forward))
                {
                    StartCoroutine(MoveUpForward());
                    StartCoroutine(soundUp());
                }

            }
            else if (Input.GetKey(KeyCode.S) && !isRolling && !falling)
            {
                if (CanMove(Vector3.back))
                {
                    StartCoroutine(MoveBackward());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.back))
                {
                    StartCoroutine(MoveUpBackward());
                    StartCoroutine(soundUp());
                }

            }
            else if (Input.GetKey(KeyCode.D) && !isRolling && !falling)
            {
                if (CanMove(Vector3.right))
                {
                    StartCoroutine(MoveLeft());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.right))
                {
                    StartCoroutine(MoveUpLeft());
                    StartCoroutine(soundUp());
                }

            }
            else if (Input.GetKey(KeyCode.A) && !isRolling && !falling)
            {
                if (CanMove(Vector3.left))
                {
                    StartCoroutine(MoveRight());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.left))
                {
                    StartCoroutine(MoveUpRight());
                    StartCoroutine(soundUp());
                }

            }
        }
        if (rotatio.rotationLocal == 90)
        {
            if (Input.GetKey(KeyCode.W) && !isRolling && !falling)
            {
                if (CanMove(Vector3.left)) //daj dam back
                {
                    StartCoroutine(MoveLeft());
                    source.PlayOneShot(clip);

                }
                else if (CanMoveUp(Vector3.left))
                {
                    StartCoroutine(MoveUpLeft());
                    StartCoroutine(soundUp());
                }
            }
            if (Input.GetKey(KeyCode.S) && !isRolling && !falling)
            {
                if (CanMove(Vector3.right)) //daj dam back
                {
                    StartCoroutine(MoveRight());
                    source.PlayOneShot(clip);

                }
                else if (CanMoveUp(Vector3.right))
                {
                    StartCoroutine(MoveUpRight());
                    StartCoroutine(soundUp());
                }
            }
            if (Input.GetKey(KeyCode.A) && !isRolling && !falling)
            {
                if (CanMove(Vector3.forward)) //daj dam back
                {
                    StartCoroutine(MoveForward());
                    source.PlayOneShot(clip);

                }
                else if (CanMoveUp(Vector3.forward))
                {
                    StartCoroutine(MoveUpForward());
                    StartCoroutine(soundUp());
                }
            }
            if (Input.GetKey(KeyCode.D) && !isRolling && !falling)
            {
                if (CanMove(Vector3.back)) //daj dam back
                {
                    StartCoroutine(MoveBackward());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.back))
                {
                    StartCoroutine(MoveUpBackward());
                    StartCoroutine(soundUp());
                }
            }
        }
        if (rotatio.rotationLocal == 180)
        {
            if (Input.GetKey(KeyCode.W) && !isRolling && !falling)
            {
                

                if (CanMove(Vector3.back)) //daj dam back
                {
                    StartCoroutine(MoveBackward());
                    source.PlayOneShot(clip);

                }
                else if (CanMoveUp(Vector3.back))
                {
                    StartCoroutine(MoveUpBackward());
                    StartCoroutine(soundUp());
                }

            }
            else if (Input.GetKey(KeyCode.S) && !isRolling && !falling)
            {
                if (CanMove(Vector3.forward))
                {
                    StartCoroutine(MoveForward());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.forward))
                {
                    StartCoroutine(MoveUpForward());
                    StartCoroutine(soundUp()); ;
                }

            }
            else if (Input.GetKey(KeyCode.D) && !isRolling && !falling)
            {
                if (CanMove(Vector3.right))
                {
                    StartCoroutine(MoveRight());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.right))
                {
                    StartCoroutine(MoveUpRight());
                    StartCoroutine(soundUp());
                }

            }
            else if (Input.GetKey(KeyCode.A) && !isRolling && !falling)
            {
                if (CanMove(Vector3.left))
                {
                    StartCoroutine(MoveLeft());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.left))
                {
                    StartCoroutine(MoveUpLeft());
                    StartCoroutine(soundUp());
                }

            }
        }
        if (rotatio.rotationLocal == 270)
        {
            if (Input.GetKey(KeyCode.W) && !isRolling && !falling)
            {
                if (CanMove(Vector3.right)) //daj dam back
                {
                    StartCoroutine(MoveRight());
                    source.PlayOneShot(clip);

                }
                else if (CanMoveUp(Vector3.right))
                {
                    StartCoroutine(MoveUpRight());
                    StartCoroutine(soundUp());
                }
            }
            if (Input.GetKey(KeyCode.S) && !isRolling && !falling)
            {
                if (CanMove(Vector3.left)) //daj dam back
                {
                    StartCoroutine(MoveLeft());
                    source.PlayOneShot(clip);

                }
                else if (CanMoveUp(Vector3.left))
                {
                    StartCoroutine(MoveUpLeft());
                    StartCoroutine(soundUp());
                }
            }
            if (Input.GetKey(KeyCode.A) && !isRolling && !falling)
            {
                if (CanMove(Vector3.back)) //daj dam back
                {
                    StartCoroutine(MoveBackward());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.back))
                {
                    StartCoroutine(MoveUpBackward());
                    StartCoroutine(soundUp());
                }
            }
            if (Input.GetKey(KeyCode.D) && !isRolling && !falling)
            {
                if (CanMove(Vector3.forward)) //daj dam back
                {
                    StartCoroutine(MoveForward());
                    source.PlayOneShot(clip);
                }
                else if (CanMoveUp(Vector3.back))
                {
                    StartCoroutine(MoveUpForward());
                    StartCoroutine(soundUp());
                }
            }
        }
    }
    // Check if the player can move
    bool CanMove(Vector3 direction)
        {
            if (direction.z != 0)
            {
                if (Physics.Raycast(zAxisOriginA, direction, rayLength)) return false;
                if (Physics.Raycast(zAxisOriginB, direction, rayLength)) return false;
            }
            else if (direction.x != 0)
            {
                if (Physics.Raycast(xAxisOriginA, direction, rayLength)) return false;
                if (Physics.Raycast(xAxisOriginB, direction, rayLength)) return false;
            }
            return true;
        }

        // Check if the player can step-up

        bool CanMoveUp(Vector3 direction)
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.up, 1f, collidableMask))
                return false;
            if (Physics.Raycast(transform.position + Vector3.up * 1.5f, direction, 1f, collidableMask))
                return false;
            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, direction, 1f, walkableMask))
                return true;
            return false;
        }


        IEnumerator MoveUpRight()
        {
        courtineWork = true;
        yield return MoveInDirection(Quaternion.Euler(0, 0, -90));
            yield return MoveInDirection(Quaternion.Euler(0, 0, 0));
       
        courtineWork = false;
        }
        IEnumerator MoveUpLeft()
        { 
        courtineWork = true;
        yield return MoveInDirection(Quaternion.Euler(0, 180, -90));
        yield return MoveInDirection(Quaternion.Euler(0, 180, 0));
      courtineWork = false;
        }
        IEnumerator MoveUpForward()
        {
        courtineWork = true;
        yield return MoveInDirection(Quaternion.Euler(0, 90, -90));
        yield return MoveInDirection(Quaternion.Euler(0, 90, 0));
 courtineWork = false;
        }
    IEnumerator MoveUpBackward()
    {
        courtineWork = true;
        yield return MoveInDirection(Quaternion.Euler(0, -90, -90));
        yield return MoveInDirection(Quaternion.Euler(0, -90, 0));
    courtineWork = false;
    }
    IEnumerator MoveInDirection(Quaternion rotation)
        {
        
            transform.rotation = rotation;
            yield return MoveRight();
       
        transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        IEnumerator MoveLeft()
        {
            yield return MoveInDirection(Quaternion.Euler(0, 180, 0));
    }

        IEnumerator MoveForward()
        {
        yield return MoveInDirection(Quaternion.Euler(0, 90, 0)); //jak dam -90 to dziala tak jak chce
        }

        IEnumerator MoveBackward()
        {
            yield return MoveInDirection(Quaternion.Euler(0, -90, 0));
        }

        IEnumerator MoveRight()
        {

        yield return RotatePivotFrom0To90();
        transform.position -= transform.right;
        pivot.localRotation = Quaternion.Euler(0, 0, 0);
        

    }

        IEnumerator RotatePivotFrom0To90()
        {
            while (pivot.localRotation.eulerAngles.z < 90)
            {
                var newRotation = pivot.localRotation.eulerAngles.z + Time.deltaTime * 90 * 3f;
                newRotation = Mathf.Clamp(newRotation, 0, 90);
                pivot.localRotation = Quaternion.Euler(0, 0, newRotation);
            isRolling = true;
           
            yield return null;
            
        }
       
        //FindObjectOfType<Audio_Manager>().Play("Audio_Cube");
        isRolling = false;
    }

        IEnumerator FallDown1()
        {
            while (pivot.localPosition.y > -3f)
            {
                var newHeight = pivot.localPosition.y - Time.deltaTime * 10;
                newHeight = Mathf.Clamp(newHeight, -1.5f, 0);
                pivot.localPosition = new Vector3(-0.5f, newHeight, 0);
                yield return null;
            }
            transform.position += Vector3.down;
            pivot.localPosition = new Vector3(-0.5f, -0.5f, 0);
        }
    
    void OnCollisionEnter(Collision other)
    {  
        if (falling && (1 << other.gameObject.layer & walkableMask) == 0)
        {
            // Find a nearby vacant square to push us on to
            Vector3 direction = Vector3.zero;
            Vector3[] directions = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };
            for (int i = 0; i < 4; i++)
            {
                if (Physics.OverlapSphere(transform.position + directions[i], 0.1f).Length == 0)
                {
                    direction = directions[i];
                    break;
                }
            }
            transform.position += direction;
            
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Point")
        {
            other.gameObject.SetActive(false);
            scoreValue = scoreValue + 1;
           
            
        }
    }
    IEnumerator soundUp()
    {
        yield return new WaitForSeconds(cos);
        source.PlayOneShot(clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlayerMovement : MonoBehaviour
{
    public Transform pivot;
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

    [SerializeField] float maxFallCastDistance = 100f;
    [SerializeField] float fallSpeed = 30f;
    bool falling;
    float targetFallHeight;
    bool courtineWork = false;
   
    private void Start()
    {
        movement_on_off = true;

    }
    void Update()
    {
       
        // Set the ray positions every frame

        yOffset = transform.position + Vector3.up * rayOffsetY;
        zOffset = Vector3.forward * rayOffsetZ;
        xOffset = Vector3.right * rayOffsetX;

        zAxisOriginA = yOffset + xOffset;
        zAxisOriginB = yOffset - xOffset;

        xAxisOriginA = yOffset + zOffset;
        xAxisOriginB = yOffset - zOffset;

        // Draw Debug Rays

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
                        //if(Input.GetKeyDown(KeyCode.W))
                        //{
                        //    falling = false;
                        //}
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
    public void move()
    {
            
            if (Input.GetKey(KeyCode.W)&& !isRolling && !falling)
            {

                if (CanMove(Vector3.forward))
                {
                    StartCoroutine(MoveForward());

                }
                else if (CanMoveUp(Vector3.forward))
                {
                    StartCoroutine(MoveUpForward());
                }

            }
            else if (Input.GetKey(KeyCode.S) && !isRolling && !falling)
            {
                if (CanMove(Vector3.back))
                {
                    StartCoroutine(MoveBackward());
                }
                else if (CanMoveUp(Vector3.back))
                {
                    StartCoroutine(MoveUpBackward());
                }

            }
            else if (Input.GetKey(KeyCode.D) && !isRolling && !falling)
            {
                if (CanMove(Vector3.right))
                {
                    StartCoroutine(MoveLeft());
                }
                else if (CanMoveUp(Vector3.right))
                {
                    StartCoroutine(MoveUpLeft());
                }

            }
            else if (Input.GetKey(KeyCode.A) && !isRolling && !falling)
            {
                if (CanMove(Vector3.left))
                {
                    StartCoroutine(MoveRight());
                }
                else if (CanMoveUp(Vector3.left))
                {
                    StartCoroutine(MoveUpRight());
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
        yield return MoveInDirection(Quaternion.Euler(0, 90, 0));
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
        FindObjectOfType<Audio_Manager>().Play("Audio_Cube");
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
   
}

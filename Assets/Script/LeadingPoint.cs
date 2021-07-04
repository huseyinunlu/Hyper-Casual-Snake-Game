using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;
public class LeadingPoint : MonoBehaviour
{

    [SerializeField] public float maxSpeed = 1f;
    public float speed = 0f;
    [SerializeField] GameObject lastTail;
    [SerializeField] GameObject secondLastTail;
    [SerializeField] GameObject tailP;
    [SerializeField] StartandPause SnP;
    public bool isFinished = false;
    public bool onClick = false;
    private float zPos;
    public bool IsPointerOverGameObject()
    {
        // Check mouse
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        // Check touches
        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return true;
                }
            }
        }

        return false;
    }

    void FixedUpdate()
    {

        LeftRightMovement();
    }



    private void LeftRightMovement()
    {
        if (Input.touchCount<0 && !IsPointerOverGameObject())
        {

            zPos = (Input.GetTouch(0).position.x - Screen.width / 2) / (Screen.width / 2);

            transform.position = new Vector3(transform.position.x, transform.position.y, -zPos);
            

        }
        if (Input.GetMouseButton(0) && !IsPointerOverGameObject())
        {
            print(zPos);
            zPos = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
            transform.position = new Vector3(transform.position.x,transform.position.y,-zPos);
            
                
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Apple")
        {
            
            Destroy(other.gameObject);
            FindObjectOfType<GoldSystem>().eatedAppleCount++;
            AddTail();
        }
        if(other.transform.tag == "Door")
        {
            Destroy(other.gameObject);
            DestroyATail();
        }
        if(other.transform.name == "Finish")
        {
            isFinished = true;
            
            SnP.isFinished = true;
        }
    }
    
    private void DestroyATail()
    {
        int snakeLen = int.Parse(lastTail.name);
        Destroy(GameObject.Find((snakeLen - 2).ToString()));
        secondLastTail.name = (snakeLen - 2).ToString();
        lastTail.name = (snakeLen - 1).ToString();
    }

    private void AddTail()
    {
        GameObject newTail = Instantiate(tailP, secondLastTail.transform.position,transform.rotation,transform.parent);
        newTail.name = secondLastTail.name;
        secondLastTail.name = lastTail.name;
        lastTail.name = (int.Parse(lastTail.name) + 1).ToString();
    }
}

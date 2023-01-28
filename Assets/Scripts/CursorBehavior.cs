using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    Vector2 cursorPosition;
    private bool oneIsSelected = false;
    private bool twoIsSelected = false;
    private bool threeIsSelected = false;
    private bool canPlace = false;
    private bool inBoxOne = false;
    private bool inBoxTwo = false;
    private bool inBoxThree = false;
    [SerializeField] GameObject turretOneIcon;
    [SerializeField] GameObject turretTwoIcon;
    [SerializeField] GameObject turretThreeIcon;
    [SerializeField] GameObject turretOne;
    [SerializeField] GameObject turretTwo;
    [SerializeField] GameObject turretThree;
    private GameObject tempIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        if(tempIcon != null)
        {
            tempIcon.transform.position = cursorPosition;
        }
        

        if (oneIsSelected || twoIsSelected || threeIsSelected)
        {
            if (canPlace)
            {
                PlaceTurrent();
            }
            
            
        }
        if(!canPlace)
        {
            SelectTurret();
        }
        //print(inBoxTwo);
        
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(oneIsSelected || twoIsSelected || threeIsSelected)
        {
            canPlace = true;
        }
        inBoxOne = false;
        inBoxTwo = false;
        inBoxThree = false;
        

    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        canPlace = false;
        
        
        if(collider.gameObject.tag == "TurretOne")
        {
            inBoxOne = true;
        }
        if (collider.gameObject.tag == "TurretTwo")
        {
            inBoxTwo = true;
            
        }
        if (collider.gameObject.tag == "TurretThree")
        {
            inBoxThree = true;

        }

    }

    void SelectTurret()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if(!oneIsSelected && inBoxOne)
            {
                Destroy(tempIcon);
                tempIcon = (GameObject)Instantiate(turretOneIcon,cursorPosition, Quaternion.identity);
                oneIsSelected = true;
                twoIsSelected = false;
                threeIsSelected = false;
            }
            if (!twoIsSelected && inBoxTwo)
            {
                Destroy(tempIcon);
                tempIcon = (GameObject)Instantiate(turretTwoIcon, cursorPosition, Quaternion.identity);
                twoIsSelected = true;
                oneIsSelected = false;
                threeIsSelected = false;
            }
            if (!threeIsSelected && inBoxThree)
            {
                Destroy(tempIcon);
                tempIcon = (GameObject)Instantiate(turretThreeIcon, cursorPosition, Quaternion.identity);
                threeIsSelected = true;
                oneIsSelected = false;
                twoIsSelected = false;
            }

        }
        //print("hit");
    }

    void PlaceTurrent()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (oneIsSelected && canPlace && !inBoxOne && !inBoxTwo && !inBoxThree)
            {
                Instantiate(turretOne, cursorPosition, Quaternion.identity);
                Destroy(tempIcon);
                
                oneIsSelected = false;
                canPlace = false;
            }
            if (twoIsSelected && canPlace && !inBoxOne && !inBoxTwo && !inBoxThree)
            {
                Instantiate(turretTwo, cursorPosition, Quaternion.identity);
                Destroy(tempIcon);

                twoIsSelected = false;
                canPlace = false;
            }
            if (threeIsSelected && canPlace && !inBoxOne && !inBoxTwo && !inBoxThree)
            {
                Instantiate(turretThree, cursorPosition, Quaternion.identity);
                Destroy(tempIcon);

                threeIsSelected = false;
                canPlace = false;
            }
        }
        
    }
}

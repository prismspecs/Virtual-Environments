using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on this forum discussion:
// https://forum.unity.com/threads/how-to-properly-handle-rts-styled-unit-selection.229784/

public class SelectUnits : MonoBehaviour
{
    // create a reference to the camera
    Camera cam;

    // mouse selection stuff
    private Vector3 StartPos;   // where mouse selection begins
    private Vector3 EndPos;     // and ends

    public GameObject SelectionBox;  // reference to the selection box prefab
    private GameObject MouseBox;     // store a temporary instance of selection box

    // we want to be able to tell the raycast to ignore certain layers
    // like UI or certain terrain, perhaps
    public LayerMask MyLayerMask;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        // the moment left mouse button goes down
        if (Input.GetMouseButtonDown(0))
        {
            // deactivate all units since we are starting a new selection
            Unit[] units = FindObjectsOfType(typeof(Unit)) as Unit[];
            //Debug.Log("Found " + units.Length + " units");
            foreach (Unit u in units)
            {
                u.Deactivate();
            }

            //Debug.Log("left mouse button went down");

            // create a ray from the 2d camera surface into the
            // 3d world
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // if it hits something...
            if (Physics.Raycast(ray, out hit, 100, MyLayerMask))
            {
                //Debug.Log(hit.transform.gameObject.layer);
                StartPos = hit.point;
                MouseBox = Instantiate(SelectionBox, StartPos, Quaternion.identity);
                MouseBox.transform.localScale = new Vector3(0, 0, 0);   // start it as size 0
            }

            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }

        if (Input.GetMouseButton(0))
        {
            // left mouse button is currently being held down

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, MyLayerMask))
            {
                Vector3 CurrentPos = hit.point; 
                Vector3 MouseBoxScale = CurrentPos - StartPos;

                // we should offset it on the Y axis a bit so that it has some height
                MouseBoxScale += new Vector3(0, 2, 0);

                MouseBox.transform.localScale = MouseBoxScale;
                // since boxes are positioned from their centers, we need
                // to do a little math to offset it
                MouseBox.transform.position = CurrentPos - MouseBoxScale/2;

                // we also need to move the mouse selection box position upwards
                MouseBox.transform.position += new Vector3(0, 2, 0);
                
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("left mouse button went up");

            // now look for any units inside the MouseSelectionBox
            List<Collider> InsideUnits = MouseBox.GetComponent<SelectionBox>().GetColliders();

            // iterate thru every collider in the array
            foreach(Collider c in InsideUnits)
            {
                // for now lets just focus on the Unit class
                c.GetComponent<Unit>().Activate();
            }

            // destroy the box
            Destroy(MouseBox);
        }

        // right click
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, MyLayerMask))
            {
                // find every Unit type in scene
                Unit[] units = FindObjectsOfType(typeof(Unit)) as Unit[];
                foreach (Unit u in units)
                {
                    if(u.Selected)
                    {
                        u.SetDestination(hit.point);
                    }
                }
            }
        }
    }
}

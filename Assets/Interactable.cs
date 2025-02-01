using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    DataBase data;
    Vector3 leftLimitL = new Vector3(5.54199982f, 3.79854393f, 0.0829999968f);
    Vector3 rightLimitL = new Vector3(4.38999987f, 3.79854393f, -0.582000017f);
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        data = transform.parent.GetComponent<DataBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(string tag)
    {
        if (tag == "tumblerLeft")
        {
            if (data.tumblerLeft)
            {
                data.tumblerLeft = false;
                transform.parent.Find("Тумблер").transform.rotation = new Quaternion(-0.527202964f, -1.52736888e-07f, -0.304380655f, 0.793353319f);
            }
            else
            {
                transform.parent.Find("Тумблер").transform.rotation = new Quaternion(-0.608761549f, -0.396676511f, -1.04308128e-07f, 0.687064171f);
                data.tumblerLeft = true;
            }


        }
        if (tag == "polzunokLeft")
        {
            Camera camera = GameObject.FindWithTag("Player").GetComponent<Player>().playerCamera;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Vector3 direction = (rightLimitL - leftLimitL).normalized;
            Plane plane = new Plane(direction, leftLimitL);
            float enter;

            if (plane.Raycast(ray, out enter))
            {
                Vector3 mousePosition = ray.GetPoint(enter);

             //   float clampedX = Mathf.Clamp(mousePosition.x, rightLimitL.x, leftLimitL.x);
             //   float clampedZ = Mathf.Clamp(mousePosition.z, rightLimitL.z, leftLimitL.z);

               // transform.parent.Find("Ползунок(гл. ч.)").transform.position = new Vector3(clampedX, transform.parent.Find("Ползунок(гл. ч.)").transform.position.y, clampedZ);

                Vector3 projectedPoint = leftLimitL + Vector3.Project(mousePosition - leftLimitL, direction);

                float t = Mathf.Clamp01(Vector3.Dot(projectedPoint - leftLimitL, direction) / Vector3.Dot(rightLimitL - leftLimitL, direction));


                transform.parent.Find("Ползунок(гл. ч.)").transform.position = Vector3.Lerp(leftLimitL, rightLimitL, t);

            }
        }
    }
}

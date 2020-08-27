using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject aim;
    public GameObject bulletInst;
    public float throwForce;
    public float throwYDir;
    public float throwXDir;
    private LineRenderer lineRenderer;

	public Camera cam;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimPos = cam.WorldToScreenPoint(aim.transform.position);
        throwXDir = (aimPos.x - Input.mousePosition.x) / 1000;
        throwYDir = (aimPos.y - Input.mousePosition.y) / 1000;

        if (Input.GetMouseButtonDown(0))
        {
            bulletInst = Instantiate(projectile, aim.transform.position + (Vector3.forward * 2), transform.rotation);
            bulletInst.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.positionCount = 0;
            bulletInst.GetComponent<Rigidbody>().isKinematic = false;
            bulletInst.GetComponent<Rigidbody>().AddForce(new Vector3(throwXDir, throwYDir, 1) * throwForce, ForceMode.VelocityChange);

        }

        if (Input.GetButton("Fire1"))
        {
            PlotTrajectory(aim.transform.position + (Vector3.forward * 2), new Vector3(throwXDir, throwYDir, 1) * throwForce, 0.02f, 5f);
        }

    }

    public void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime)
    {

        int index = 0;

        Vector3 prev = start;
        for (int i = 1; ; i++)
        {
            float t = timestep * i;
            if (t > maxTime) break;
            Vector3 pos = PlotTrajectoryAtTime(start, startVelocity, t);
            lineRenderer.positionCount = ((int)(maxTime / timestep));

            if (Physics.Linecast(prev, pos))
            {
                lineRenderer.positionCount = index;
                break;
            }
            else
            {
                lineRenderer.SetPosition(index, pos);
                Debug.DrawLine(prev, pos, Color.red);
                prev = pos;
                index++;
            }
        }
    }

    public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
    {
        return start + startVelocity * time + Physics.gravity * time * time * 0.5f;
    }


    public void SetProjectile(GameObject _projectile)
    {
        projectile = _projectile;
    }

}

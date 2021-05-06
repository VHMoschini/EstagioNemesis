using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCube : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 startingPos;

	public float timerToDie;
	public GameObject debris;
	public GameObject feedback;

	
	private void Start()
    {
        startingPos = transform.position;
		debris = Resources.Load<GameObject>("Debris");
		feedback = Resources.Load<GameObject>("Feedback Negativo");
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Distance(startingPos, transform.position) > 1 && collision.collider.CompareTag("Ground"))
        {
            GetComponentInParent<BarsManager>().hittedAllyCubes++;
			Instantiate(feedback, transform.position, transform.rotation, null);
			isGrounded = true;
			StartCoroutine(TurnToRubble(collision.GetContact(0).point.y));
		}

    }

	private IEnumerator TurnToRubble(float hitPos)
	{
		yield return new WaitForSeconds(timerToDie);
		if (isGrounded)
		{
			GetComponentInParent<BarsManager>().hittedEnemieCubes++;
			Instantiate(debris, new Vector3(transform.position.x, hitPos, transform.position.z), Quaternion.identity, null);
			Destroy(gameObject);
		}
	}
}

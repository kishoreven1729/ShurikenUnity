using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour 
{
	public void FlipBird()
	{
		transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    /// <summary>
	/// Õ“Ë‚µ‚½
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
    {
        // Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (collision.gameObject.tag == "Shell")
        {
            // 0.2•bŒã‚ÉÁ‚¦‚é
            Destroy(gameObject);
        }
    }
}

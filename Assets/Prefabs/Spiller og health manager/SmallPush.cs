using UnityEngine;

public class SmallPush : MonoBehaviour
{
      private Rigidbody2D p_Rigidbody;

    // Update is called once per frame
    void Update()
    {
        p_Rigidbody = GetComponent<Rigidbody2D>();
    }

      void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Collision detected with: " + collision.gameObject.name); // Log the colliding object

    if (collision.gameObject.CompareTag("Virus"))
    {
        Debug.Log("The colliding object is tagged as 'Virus'."); // Confirm tag check passed

        Rigidbody2D pushedBody = collision.collider.GetComponent<Rigidbody2D>();
        if (pushedBody != null)
        {
            // Calculate direction from your object to the colliding object
            var direction = pushedBody.transform.position - transform.position;

            Debug.Log("Direction vector: " + direction); // Log the calculated direction vector

            // Visualize the direction vector
            Debug.DrawLine(transform.position, pushedBody.transform.position, Color.red, 1f);

            // Apply an impulse force to push the object away
            pushedBody.AddForce(direction.normalized * 500, ForceMode2D.Impulse);

            Debug.Log("Force applied to the colliding object."); // Confirm force application
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found on the colliding object."); // Warn if Rigidbody2D is missing
        }
    }
    else
    {
        Debug.Log("The colliding object is not tagged as 'Virus'."); // Log if the tag doesn't match
    }
}
}

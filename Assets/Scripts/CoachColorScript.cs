using UnityEngine;

public class CoachColorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject coachMesh;

    //public Renderer renderer;

    public Color newColor;

    public float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
       if(score >= .9)
        {
            newColor = Color.green;
            coachMesh.GetComponent<Renderer>().material.color = newColor;
        }
       else if (score <= .7)
        {
            newColor = Color.yellow;
            coachMesh.GetComponent<Renderer>().material.color = newColor;
        }
       else if (score <= .5)
        {
            newColor = Color.orange;
            coachMesh.GetComponent<Renderer>().material.color = newColor;
        }
        else
        {
            newColor = Color.red;
            coachMesh.GetComponent<Renderer>().material.color = newColor;
        }
    }
}

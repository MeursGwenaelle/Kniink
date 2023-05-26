using UnityEngine;

public class plateformeMobile : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private bool pingPongMode;
    [SerializeField] private Transform[] listeDestinations;
    private int sens = 1;
    private int indexDestination;
    private float horizontalMove;
    

    void Start()
    {
        transform.position = listeDestinations[0].position;
        
    }

    void Update()
    {
        horizontalMove = sens;

        var destination = listeDestinations[indexDestination];
        transform.position = Vector2.MoveTowards(transform.position, destination.position, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position,destination.position) < 0.01f)
        {
            indexDestination += sens;
            if (indexDestination >= listeDestinations.Length || indexDestination < 0)
            {
                if (pingPongMode)
                {
                    sens = -sens;
                    indexDestination += sens;
                }
                else
                {
                    indexDestination = 0;
                }
            }
        }
        if (horizontalMove > 0)
        {

            transform.localScale = new Vector3(-0.47851f, 0.47851f, 0.47851f);

        } 
        else if (horizontalMove < 0)
        {

            transform.localScale = new Vector3(0.47851f, 0.47851f, 0.47851f);


        }


    }
}

using UnityEngine;

public class checkPointCode : MonoBehaviour
{
    // Start is called before the first frame update
    public int checkPointNum;
    public cubeMover playerCode;
    void Start()
    {
        playerCode = GameObject.FindGameObjectWithTag("Player").GetComponent<cubeMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkPointNum == playerCode.currentCheckPoint + 1)
        {
            playerCode.currentCheckPoint += 1;
            if (playerCode.currentCheckPoint == playerCode.totalCheckpoints)
            {
                playerCode.currentCheckPoint = 0;
                playerCode.currentLap += 1;
            }
        }
    }
}

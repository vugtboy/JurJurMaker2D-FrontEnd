using UnityEngine;

public class CanonConnection : MonoBehaviour
{ 
    //rotatie aanpassen als een point van het konan een grondobject detecteerd
    public void UpdateConnection(int checkerNumber)
    {
        switch (checkerNumber)
        {
            case 1:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 3:
                transform.eulerAngles = new Vector3(0, 0, 180);
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case 4:
                transform.eulerAngles = new Vector3(0, 0, 270);
                break;
        }
    }
}

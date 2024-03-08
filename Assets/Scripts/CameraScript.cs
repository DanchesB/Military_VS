using UnityEngine;

public class CameraScript : MonoBehaviour
{   [SerializeField] private Vector3 _сameraDistantseSettings;
    [SerializeField] private float _сameraMovingSpeed;

    private void FixedUpdate()
    {
        CameraMove();
    }
    
    private void CameraMove()
    {
        if(PlayerController.Instance == null)
            return;

        var CamPosition = new Vector3(_сameraDistantseSettings.x + PlayerController.Instance.transform.position.x, _сameraDistantseSettings.y + PlayerController.Instance.transform.position.y, _сameraDistantseSettings.z + PlayerController.Instance.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, CamPosition, _сameraMovingSpeed * Time.deltaTime);
    }
}

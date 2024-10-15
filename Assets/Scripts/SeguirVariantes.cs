using Cinemachine;
using UnityEngine;

public class SeguirVariantes : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject[] playerVariants;

    private void Update()
    {
        foreach (GameObject player in playerVariants)
        {
            if (player.activeInHierarchy)
            {
                virtualCamera.Follow = player.transform;
            }
        }
    }
}
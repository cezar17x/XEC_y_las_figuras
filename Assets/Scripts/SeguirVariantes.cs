using Cinemachine;
using UnityEngine;

public class SeguirVariantes : GameManager
{
    public override void SeguirVariantes1()
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
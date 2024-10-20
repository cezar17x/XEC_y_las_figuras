using Cinemachine;
using UnityEngine;

public class SeguirVariantes : GameManager
{
    public override void _SeguirVariantes()
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
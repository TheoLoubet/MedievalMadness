using UnityEngine;
using UnityEngine.UI;

public class CoolDowns : MonoBehaviour
{
    public PlayerController pc;
    public Image fireBallImage;
    public Image meleeImage;
    public Image slowZoneImage;
    public Image laserImage;

    private void Update()
    {
        if(pc.isFireBallUp())
        {
            if(pc.laser.gameObject.activeSelf == false)
            {
                fireBallImage.color = new Color(255f, 255f, 255f, 255f);
            }
            else
            {
                fireBallImage.color = new Color(255f, 0f, 0f, 255f);
            }
        }
        else if (!pc.isFireBallUp())
        {
            fireBallImage.color = new Color(0f, 0f, 0f, 255f);
        }

        if (pc.isMeleeUp())
        {
            if (pc.laser.gameObject.activeSelf == false)
            {
                meleeImage.color = new Color(255f, 255f, 255f, 255f);
            }
            else
            {
                meleeImage.color = new Color(255f, 0f, 0f, 255f);
            }
        }
        else if (!pc.isMeleeUp())
        {
            meleeImage.color = new Color(0f, 0f, 0f, 255f);
        }

        if (pc.isSlowZoneUp())
        {
            if (pc.laser.gameObject.activeSelf == false)
            {
                slowZoneImage.color = new Color(255f, 255f, 255f, 255f);
            }
            else
            {
                slowZoneImage.color = new Color(255f, 0f, 0f, 255f);
            }
        }
        else if (!pc.isSlowZoneUp())
        {
            slowZoneImage.color = new Color(0f, 0f, 0f, 255f);
        }

        if (pc.isLaserUp())
        {
            laserImage.color = new Color(255f, 255f, 255f, 255f);
        }
        else if (!pc.isLaserUp())
        {
            laserImage.color = new Color(0f, 0f, 0f, 255f);
        }

    }
}

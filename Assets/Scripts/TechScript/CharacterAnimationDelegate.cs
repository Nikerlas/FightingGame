using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;

    void leftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void leftArmAttackOff()
    {
        if(leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);    
        }
    }

    void rightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void rightArmAttackOff()
    {
        if(rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);    
        }
    }

    void leftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }

    void leftLegAttackOff()
    {
        if(leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);    
        }
    }

    void rightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void rightLegAttackOff()
    {
        if(rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);    
        }
    }
}

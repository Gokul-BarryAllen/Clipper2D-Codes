using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CoolDown 
{
    [SerializeField]private float cooldowntime;
    private float nextfiretime;

    public bool isCoolingDown => Time.time < nextfiretime;
    public void StartCooldown() => nextfiretime = Time.time + cooldowntime;
}

using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogActionTeleport : BaseDialogAction
{
    public override BaseDialogAction.ActionTypes ActionType
    {
        get
        {
            return BaseDialogAction.ActionTypes.AddBuff;
        }
    }

    public override void PerformAction(EntityPlayer player)
    {
        Debug.Log($" target is {this.target}");
                
        Debug.Log(" GetPOIPrefabs : ------");
        List<PrefabInstance> poiPrefabs = GameManager.Instance.GetDynamicPrefabDecorator().GetPOIPrefabs();

        Boolean done = false;
        poiPrefabs.ForEach(delegate (PrefabInstance inst)
        {
            if (inst.name.StartsWith(this.target) && !done)
            {
                Debug.Log("TP-ing ! ");
                // 2 meters couldn't hurt I guess? Otherwise, we get fall though the ground
                Vector3 vector = new Vector3(inst.boundingBoxPosition.x, inst.boundingBoxPosition.y + 2, inst.boundingBoxPosition.z);
                player.SetPosition(vector, true);
                done = true;
            }
        });

        return;
    }
    public string target;
    private readonly string name = string.Empty;
}
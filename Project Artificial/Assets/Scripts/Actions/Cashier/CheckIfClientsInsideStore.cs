using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class CheckIfClientsInsideStore : ActionTask
{
    protected override void OnExecute()
    {

        EndAction(References.data.clients_container.transform.childCount > 0);
    }
}

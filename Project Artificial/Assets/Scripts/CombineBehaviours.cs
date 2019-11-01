using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static public class CombineBehaviour
{
    public const int num_priorities = 5;
}
abstract public class CombineBehaviours : MonoBehaviour
{
    [Range(0, CombineBehaviour.num_priorities)]
    public int priority = 0;
}


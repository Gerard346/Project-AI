using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class DependentManager : MonoBehaviour
{
    public GameObject container_dependent;
    public List<Transform> spawn_list;
    public List<Transform> observer_list;

    private GameObject dependent;
    private List<DependentController> dependents = new List<DependentController>();

    // Start is called before the first frame update
    void Start()
    {
        dependent = Resources.Load<GameObject>("Dependent/dependent");

        AddDependent();
    }

    public DependentController AddDependent()
    {
        GameObject new_dependent = Instantiate(dependent);
        new_dependent.transform.parent = container_dependent.transform;

        DependentController new_dependent_controller = new_dependent.GetComponent<DependentController>();
        new_dependent.transform.position = spawn_list[dependents.Count].position;

        new_dependent.GetComponent<Blackboard>().SetValue("SpawnPos", new_dependent.transform.position);
        new_dependent.GetComponent<Blackboard>().SetValue("ObserverPoint", observer_list[dependents.Count]);
        
        new_dependent.SetActive(true);
        dependents.Add(new_dependent_controller);

        return new_dependent_controller;
    }

    public int DependentsCount()
    {
        return dependents.Count;
    }
}

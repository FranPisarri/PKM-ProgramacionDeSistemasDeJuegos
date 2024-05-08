using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Queue : MonoBehaviour
{
    public static Event_Queue Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }
    private List<ICommand> currentCommands = new();

    public void QueueCommand ( ICommand command)
    {
        currentCommands.Add(command);
    }

    private void LateUpdate()
    {
        for (int i = 0; i < currentCommands.Count; i++)
        {
            currentCommands[i].Execute();
            currentCommands.RemoveAt(i);
        }
    }

}

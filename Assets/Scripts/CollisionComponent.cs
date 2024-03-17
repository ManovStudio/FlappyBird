using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionComponent : MonoBehaviour
{
    public UnityEvent onCollisionEnterEvent;
    public UnityEvent onCollisionStayEvent;
    public UnityEvent onCollisionExitEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisionEnterEvent.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onCollisionStayEvent.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onCollisionExitEvent.Invoke();
    }
}

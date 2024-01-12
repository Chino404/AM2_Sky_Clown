using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservableImpulse
{
    void Subscribe(IObserverBoost obs);

    void Unsubscribe(IObserverBoost obs);
}

using UnityEngine;

public interface IInteractables // interface used here so player is decoupled from concrete interaction logic
{
    void Interact();
}

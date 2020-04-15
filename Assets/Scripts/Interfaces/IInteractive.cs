/// <summary>
/// Interface for elements the playeyer can interact with by pressing the Interact button.
/// </summary>
public interface IInteractive 
{
    string DisplayText { get; }
    void InteractWith();
}

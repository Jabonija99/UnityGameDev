public abstract class AnimalBaseState 
{
    public AnimalController animalController;
    public AnimalStateMachine animalStateMachine;


    public abstract void Enter();
    public abstract void Perform();
    public abstract void FixedPerform();
    public abstract void Exit();
}

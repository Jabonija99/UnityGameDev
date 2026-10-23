public abstract class BaseState
{
    public NpcController npc;
    public StateMachine statemachine;

    public abstract void Enter();

    public abstract void Perform();

    public abstract void Exit();
}
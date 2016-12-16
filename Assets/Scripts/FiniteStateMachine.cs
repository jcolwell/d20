using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//============================================================
// Class FiniteStateMachine
//============================================================
public class FiniteStateMachine<StateType>
{
    List<State> mStates;
    State mCurrentState;

    public FiniteStateMachine(int size, State state)
    {
        mStates = new List<State>(size);
        mStates.Add(state);
        mCurrentState = mStates[0];
    }

    ~FiniteStateMachine()
    {
        mStates.Clear();
    }

    public void AddState(State newState)
    {
        mStates.Add(newState);
    }

    public void Clear()
    {
        mStates.Clear();
    }

    public void ChangeState(int index)
    {
        Debug.Assert(index < mStates.Count);

        mCurrentState.Exit();
        mCurrentState = mStates[index];
        mCurrentState.Enter();
    }

    public string GetCurrentStateTag()
    {
        return mCurrentState.GetTag();
    }
}
//============================================================

//============================================================
// Class State
//============================================================
public abstract class State
{
    string mTag;

    public State( string tag )
    {
        mTag = tag;
    }

    public string GetTag() { return mTag; }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update( float deltaTime ) { }
}
//============================================================

//============================================================
// Class StateNone
//============================================================
public class StateNone : State
{
    public StateNone() : base("No Active State")
    {
    }
}
//============================================================
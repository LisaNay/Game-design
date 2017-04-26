using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FSM {

	private Stack<FSMState> _stateStack = new Stack<FSMState>();

	public delegate void FSMState( FSM fsm, GameObject obj );

	public void Update( GameObject obj ) {
		if ( _stateStack.Peek() != null ) {
			_stateStack.Peek().Invoke ( this, obj );
		}
	}

	public void pushState( FSMState state ) {
		_stateStack.Push( state );
	}

	public void popState() {
		_stateStack.Pop ();
	}
}

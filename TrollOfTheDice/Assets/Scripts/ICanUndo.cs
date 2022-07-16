using System.Collections;
using System.Collections.Generic;

public interface ICanUndo {
    void addMoveState();
    void undoLastMove();
}

using strange.extensions.context.impl;

public class TetrisPuzzleRoot : ContextView
{

    private void Awake()
    {
        context = new TetrisPuzzleContext(this);
    }
}

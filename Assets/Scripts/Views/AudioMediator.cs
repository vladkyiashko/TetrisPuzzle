using strange.extensions.mediation.impl;

public class AudioMediator : Mediator
{
    [Inject]
    public AudioView View { get; set; }

    [Inject]
    public DragEndSignal DragEndSignal { get; set; }

    [Inject]
    public ClickSignal ClickSignal { get; set; }

    public override void OnRegister()
    {
        DragEndSignal.AddListener(OnDragEnd);
        ClickSignal.AddListener(OnClick);
    }

    public override void OnRemove()
    {
        DragEndSignal.RemoveListener(OnDragEnd);
        ClickSignal.RemoveListener(OnClick);
    }

    private void OnDragEnd(DragEndArgs dragEndArgs)
    {
        View.PlayDropAudio();
    }

    private void OnClick()
    {
        View.PlayClickAudio();
    }
}

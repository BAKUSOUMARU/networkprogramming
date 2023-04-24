using Fusion;
public class Ball : NetworkBehaviour {
    [Networked] private TickTimer life { get; set; }
    public void Init()
    {
        life = TickTimer.CreateFromSeconds(Runner, 2.0f);
    }
    public override void FixedUpdateNetwork()
    {
        if (life.Expired(Runner))
            Runner.Despawn(Object);
        else
            transform.position += 5 * transform.up * Runner.DeltaTime;
    }
}
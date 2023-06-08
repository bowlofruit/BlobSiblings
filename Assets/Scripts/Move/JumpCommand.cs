using UnityEngine;

public class JumpCommand : ICommand
{
    private readonly Rigidbody2D _player;
    private readonly float _jumpForse;
    private float _iceAcceleration;

    public JumpCommand(Rigidbody2D player, float jumpForse)
    {
        _player = player;
        _jumpForse = jumpForse;
        _iceAcceleration = 1f;
    }

    public void SetIceAcceleration(float acceleration)
    {
        _iceAcceleration = acceleration;
    }

    public void Execute()
    {
        _player.velocity = new Vector2(_player.velocity.x, _jumpForse * _iceAcceleration);
    }
}
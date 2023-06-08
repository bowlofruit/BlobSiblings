using UnityEngine;

public class MoveCommand : ICommand
{
    private readonly Rigidbody2D _player;
    private readonly float _speed;
    private float _direction;
    private float _iceAcceleration;

    public MoveCommand(Rigidbody2D player, float speed)
    {
        _player = player;
        _speed = speed;
        _iceAcceleration = 1f;
    }

    public void SetDirection(int direction)
    {
        _direction = direction;
    }

    public void SetIceAcceleration(float acceleration) 
    {
        _iceAcceleration = acceleration;
    }

    public void Execute()
    {
        _player.velocity = new Vector2(_direction * _speed * _iceAcceleration, _player.velocity.y);
    }
}
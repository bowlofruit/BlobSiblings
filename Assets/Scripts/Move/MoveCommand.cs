using UnityEngine;

public class MoveCommand : ICommand
{
    private readonly Rigidbody2D _player;
    private readonly float _speed;
    private float _direction;

    public MoveCommand(Rigidbody2D player, float speed)
    {
        _player = player;
        _speed = speed;
    }

    public void SetDirection(int direction)
    {
        _direction = direction;
    }

    public void Execute()
    {
        _player.velocity = new Vector2(_direction * _speed, _player.velocity.y);
    }
}
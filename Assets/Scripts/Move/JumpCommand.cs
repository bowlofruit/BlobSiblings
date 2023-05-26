using UnityEngine;

public class JumpCommand : ICommand
{
    private readonly Rigidbody2D _player;
    private readonly float _jumpForse;

    public JumpCommand(Rigidbody2D player, float jumpForse)
    {
        _player = player;
        _jumpForse = jumpForse;
    }

    public void Execute()
    {
        _player.velocity = new Vector2(_player.velocity.x, _jumpForse);
    }
}
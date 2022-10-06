using UnityEngine;

[CreateAssetMenu(fileName = "Option Values", menuName = "Add Options Values", order = 0)]
public class OptionsValues : ScriptableObject
{
    [SerializeField] float _gameSessionTime;
    public float GameSessionTime{ get { return _gameSessionTime;}set { _gameSessionTime = value; } }

    [SerializeField] float _enemySpawnTime;
    public float EnemySpawnTime { get { return _enemySpawnTime; } set { _enemySpawnTime = value; } }

    [SerializeField] int _highScore;
    public int HighScore { get { return _highScore; } set { _highScore = value; } }
}

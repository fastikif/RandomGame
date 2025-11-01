using System.ComponentModel;

namespace Random_game;

public class ModelStats : INotifyPropertyChanged
{
    private int _health;
    private int _damage;
    private int _health1;
    private int _damage1;
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            OnPropertyChanged(nameof(Health));
        }
    }
    public int Damage
    {
        get => _damage;
        set
        {
            _damage = value;
            OnPropertyChanged(nameof(Damage));
        }
    }
    
    public int Health1
    {
        get => _health1;
        set
        {
            _health1 = value;
            OnPropertyChanged(nameof(Health1));
        }
    }
    public int Damage1
    {
        get => _damage1;
        set
        {
            _damage1 = value;
            OnPropertyChanged(nameof(Damage1));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
using System.ComponentModel;
using System.Windows.Input;

namespace Random_game;

public class ViewModel : INotifyPropertyChanged
{
    private Random _random = new Random();
    public ICommand RerollCommand { get;}
    public ICommand FightCommand {get;}
    public ModelStats _modelStats;
    private string _statsResult;
    private string _enemyStatsResult;
    private string _winnerResult;

    private void ShowStats()
    {
        StatsResult = $"damage:{_modelStats.Damage} health:{_modelStats.Health}";

        EnemyStatsResult = $"damage:{_modelStats.Damage1} health:{_modelStats.Health1}";
    }

    public string WinnerResult
    {
        get => _winnerResult;
        set
        {
            _winnerResult = value;
            OnPropertyChanged(nameof(WinnerResult));
        }
    }
    public string StatsResult
    {
        get => _statsResult;
        set
        {
            _statsResult = value;
            OnPropertyChanged(nameof(StatsResult));
        }
    }
    
    public string EnemyStatsResult
    {
        get => _enemyStatsResult;
        set
        {
            _enemyStatsResult = value;
            OnPropertyChanged(nameof(EnemyStatsResult));
        }
    }

    public int Randoming(int min, int max)
    {
        int number = _random.Next(min, max);
        return number;
    }

    public void RandomReroll()
    {
         _modelStats.Health1 = Randoming(200, 500);
         _modelStats.Health = Randoming(200, 500);
         _modelStats.Damage = Randoming(50, 100);
         _modelStats.Damage1 = Randoming(50, 100);
         ShowStats();
    }

    public void Fight()
    {
        
        while (_modelStats.Health1 >= 0 && _modelStats.Health >= 0)
        {
            _modelStats.Health1 = _modelStats.Health1 - _modelStats.Damage;
            ShowStats();
            break;
        }

        while (_modelStats.Health1 >= 0 && _modelStats.Health >= 0)
        {
            _modelStats.Health = _modelStats.Health - _modelStats.Damage1;
            ShowStats();
            return;
        }
        
        if (_modelStats.Health <= 0)
            WinnerResult =  "Winner: You!";
        else if (_modelStats.Health1 <= 0)
            WinnerResult = "Winner: Enemy!";
        
    }

    public ViewModel()
    {
        _modelStats = new ModelStats();
        RerollCommand = new RelayCommand(execute: _ => RandomReroll(), canExecute: _=> true);
        FightCommand = new RelayCommand(execute: _ => Fight(), canExecute: _=> true);
    }
   
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
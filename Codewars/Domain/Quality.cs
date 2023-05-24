namespace Codewars.Domain;

public class Quality
{
    private int value;
    private readonly int _lowerBound;
    private readonly int _upperBound;

    public int Degradation { get; set; } = 1;

    public int Value
    {
        get => this.value;

        set
        {
            if (value < _lowerBound || value > _upperBound)
            {
                return;
            }
            
            this.value = value;
        }
    }

    public Quality(int value, int lowerBound, int upperBound)
    {
        _lowerBound = lowerBound;
        _upperBound = upperBound;

        if (value < _lowerBound || value > _upperBound)
            throw new ArgumentException($"qualityValue should not be less the {_lowerBound} and more than {_upperBound}");

        Value = value;
    }
    
    public void Update()
    {
        int qualityValue = Value - this.Degradation;
        if (qualityValue < 0)
        {
            qualityValue = 0;
        }

        this.Value = qualityValue;
    }

    public override bool Equals(object? obj)
    {
        var item = obj as Quality;
        if (item == null)
        {
            return false;
        }

        return this.Equals(item);
    }

    public bool Equals(Quality obj)
    {
        return this.Value == obj.Value;
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }
}
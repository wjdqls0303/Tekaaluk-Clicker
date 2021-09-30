[System.Serializable]

public class Ability
{
    public int abilityNumber;
    public string abilityName;
    public int Amount;
    public long Fps;
    public long Price;

    public Ability(string name, int number, int amount, long fps, long price)
    {
        abilityName = name;
        abilityNumber = number;
        Amount = amount;
        Fps = fps;
        Price = price;
    }


}

using System;
using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string userName;
    public long fish;
    public long fpc = 1;
    public List<Ability> abilityList = new List<Ability>();
}

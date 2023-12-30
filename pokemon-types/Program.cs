// See https://aka.ms/new-console-template for more information


using System.Linq.Expressions;

//TODO: Examine dual type defenses via multiplication?

/**
 * Type indices:
 *  0 = normal
 *  1 = fire
 *  2 = water
 *  3 = electric
 *  4 = grass
 *  5 = ice
 *  6 = fighting
 *  7 = poison
 *  8 = ground
 *  9 = flying
 *  10 = psychic
 *  11 = bug
 *  12 = rock
 *  13 = ghost
 *  14 = dragon
 *  15 = dark
 *  16 = steel
 *  17 = fairy
 */
double[,] strengths = new double[18, 18]{
    //DEFENSE:
    //{nor, fir, wtr, ele, gra, ice, fit, poi, grd, fly, psy, bug, rck, ght, dra, drk, ste, fry },//OFFENSE:
    {   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1, 0.5,   0,   1,   1, 0.5,   1 },//normal
    {   1, 0.5, 0.5,   1,   2,   2,   1,   1,   1,   1,   1,   2, 0.5,   1, 0.5,   1,   2,   1 },//fire
    {   1,   2, 0.5,   1, 0.5,   1,   1,   1,   2,   1,   1,   1,   2,   1, 0.5,   1,   1,   1 },//water
    {   1,   1,   2, 0.5, 0.5,   1,   1,   1,   0,   2,   1,   1,   1,   1, 0.5,   1,   1,   1 },//electric
    {   1, 0.5,   2,   1, 0.5,   1,   1, 0.5,   2, 0.5,   1, 0.5,   2,   1, 0.5,   1, 0.5,   1 },//grass
    {   1, 0.5, 0.5,   1,   2, 0.5,   1,   1,   2,   2,   1,   1,   1,   1,   2,   1, 0.5,   1 },//ice
    {   2,   1,   1,   1,   1,   2,   1, 0.5,   1, 0.5, 0.5, 0.5,   2,   0,   1,   2,   2, 0.5 },//fighting
    {   1,   1,   1,   1,   2,   1,   1, 0.5, 0.5,   1,   1,   1, 0.5, 0.5,   1,   1,   0,   2 },//poison
    {   1,   2,   1,   2, 0.5,   1,   1,   2,   1,   0,   1, 0.5,   2,   1,   1,   1,   2,   1 },//ground
    {   1,   1,   1, 0.5,   2,   1,   2,   1,   1,   1,   1,   2, 0.5,   1,   1,   1, 0.5,   1 },//flying
    {   1,   1,   1,   1,   1,   1,   2,   2,   1,   1, 0.5,   1,   1,   1,   1,   0, 0.5,   1 },//psychic
    {   1, 0.5,   1,   1,   2,   1, 0.5, 0.5,   1, 0.5,   2,   1,   1, 0.5,   1,   2, 0.5, 0.5 },//bug
    {   1,   2,   1,   1,   1,   2, 0.5,   1, 0.5,   2,   1,   2,   1,   1,   1,   1, 0.5,   1 },//rock
    {   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   2,   1,   1,   2,   1, 0.5,   1,   1 },//ghost
    {   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   2,   1, 0.5,   0 },//dragon
    {   1,   1,   1,   1,   1,   1, 0.5,   1,   1,   1,   2,   1,   1,   2,   1, 0.5,   1, 0.5 },//dark
    {   1, 0.5, 0.5, 0.5,   1,   2,   1,   1,   1,   1,   1,   1,   2,   1,   1,   1, 0.5,   2 },//steel
    {   1, 0.5,   1,   1,   1,   1,   2, 0.5,   1,   1,   1,   1,   1,   1,   2,   2, 0.5,   1 },//fairy
};

string indexToType(int index)
{
    string pkmnType;
    switch (index)
    {
        case 0:
            pkmnType = "normal";
            break;
        case 1:
            pkmnType = "fire";
            break;
        case 2:
            pkmnType = "water";
            break;
        case 3:
            pkmnType = "electric";
            break;
        case 4:
            pkmnType = "grass";
            break;
        case 5:
            pkmnType = "ice";
            break;
        case 6:
            pkmnType = "fighting";
            break;
        case 7:
            pkmnType = "poison";
            break;
        case 8:
            pkmnType = "ground";
            break;
        case 9:
            pkmnType = "flying";
            break;
        case 10:
            pkmnType = "psychic";
            break;
        case 11:
            pkmnType = "bug";
            break;
        case 12:
            pkmnType = "rock";
            break;
        case 13:
            pkmnType = "ghost";
            break;
        case 14:
            pkmnType = "dragon";
            break;
        case 15:
            pkmnType = "dark";
            break;
        case 16:
            pkmnType = "steel";
            break;
        case 17:
            pkmnType = "fairy";
            break;
        default:
            pkmnType = "unknown";
            break;
    }
    return pkmnType;
}


//Row evaluations:
List<double> offenses = new List<double>();
for (int i = 0; i < strengths.GetLength(0); i++)
{
    double offStrength = 0;
    for (int j = 0; j < strengths.GetLength(1); j++)
    {
        offStrength += strengths[i, j];
    }
    offenses.Add(offStrength);
}


//Column evaluations:
List<double> defenses = new List<double>();
for (int j = 0; j < strengths.GetLength(1); j++)
{
    double defStrength = 0;
    for (int i = 0; i < strengths.GetLength(0); i++)
    {
        defStrength += strengths[i, j];
    }
    defenses.Add(1 / defStrength * 100);
}

//Try to find Paper Rock Scissors relationships:
Console.WriteLine("Defensive RPS Loops:\n");
List<string> found = new List<string>();
for (int i = 0; i < strengths.GetLength(0); i++)
{
    for (int j = 0; j < strengths.GetLength(1); j++)
    {
        //For each of the resisted type matchups, which are not the same offsense as defense,
        if (i != j && strengths[i, j] < 1)
        {
            //traverse the row which matches the column we found
            for (int k = 0; k < 18; k++)
            {
                if (j != k && strengths[j, k] < 1)
                {
                    //traverse once more to see if we complete the loop
                    if (strengths[k, i] < 1)
                    {
                        if(!found.Any(str => str.Contains(i.ToString()) && str.Contains(j.ToString()) && str.Contains(k.ToString())))
                        {
                            found.Add(i.ToString() + j.ToString() + k.ToString());
                            Console.WriteLine(indexToType(i) + " " + indexToType(j) + " " + indexToType(k));
                            double offTotal = offenses[i] + offenses[j] + offenses[k];
                            double defTotal = defenses[i] + defenses[j] + defenses[k];
                            Console.WriteLine("Defensive Strength: " + defTotal);
                            Console.WriteLine("Offensive Strength: " + offTotal);
                            Console.WriteLine("\n");
                        }
                    }
                }
            }
        }
    }
}



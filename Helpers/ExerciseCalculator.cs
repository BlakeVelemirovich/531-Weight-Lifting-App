using _531WorkoutApi.DTO;

namespace _531WorkoutApi.Helpers;

public class ExerciseCalculator
{
    public SetDto CalculateByCurrentWeek(int week, double maxWeight)
    {
        SetDto exerciseSet = new SetDto();
        
        switch (week)
        {
            case 1:
                exerciseSet.Weight.Add(maxWeight * 0.65);
                exerciseSet.NumOfReps.Add(5);
                
                exerciseSet.Weight.Add(maxWeight * 0.75);
                exerciseSet.NumOfReps.Add(5);
                
                exerciseSet.Weight.Add(maxWeight * 0.85);
                exerciseSet.NumOfReps.Add(5);

                return exerciseSet;
            case 2:
                exerciseSet.Weight.Add(maxWeight * 0.70);
                exerciseSet.NumOfReps.Add(3);
                
                exerciseSet.Weight.Add(maxWeight * 0.80);
                exerciseSet.NumOfReps.Add(3);
                
                exerciseSet.Weight.Add(maxWeight * 0.90);
                exerciseSet.NumOfReps.Add(3);
                
                return exerciseSet;
            case 3:
                exerciseSet.Weight.Add(maxWeight * 0.75);
                exerciseSet.NumOfReps.Add(5);
                
                exerciseSet.Weight.Add(maxWeight * 0.85);
                exerciseSet.NumOfReps.Add(3);
                
                exerciseSet.Weight.Add(maxWeight * 0.95);
                exerciseSet.NumOfReps.Add(1);

                return exerciseSet;
        }

        return exerciseSet;
    }
}
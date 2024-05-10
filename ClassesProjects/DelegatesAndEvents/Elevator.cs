namespace DelegatesAndEvents
{
    public class Elevator
    {
        public event NotifyAction NotifyAction;
        public int CurrentFloor { get; private set; }
        public int MinFloor => 0;
        public int MaxFloor => 5;
        public int MiliSecondsBetweenFloors => 1000;

        public void Move(int floor)
        {
            if (floor < MinFloor || floor > MaxFloor) 
                throw new ArgumentOutOfRangeException(nameof(floor));

            Task.Run(async () =>
            {
                while (CurrentFloor != floor)
                {
                    await Task.Delay(MiliSecondsBetweenFloors);

                    CurrentFloor += CurrentFloor < floor ? 1 : -1;

                    //NotifyAction();   //Don't just do it without null check
                    NotifyAction?.Invoke(CurrentFloor); 
                }
            });
        }
    }
}

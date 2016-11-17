namespace Day14.ConsoleApplication
{
    public class Reindeer
    {
        public Reindeer(string name, int speed, int moveTime, int restTime)
        {
            this.Name = name;
            this.Speed = speed;
            this.MoveTime = moveTime;
            this.RestTime = restTime;
            this.Score = 0;
            this.Odometer = 0;
        }

        public string Name { get; private set; }
        public int Speed { get; private set; }
        public int MoveTime { get; private set; }
        public int RestTime { get; private set; }
        public int Score { get; private set; }
        public int Odometer { get; private set; }

        private bool isMoving = true;
        private int ticksInState = 0;
        public void Tick()
        {
            if(isMoving)
            {
                this.Odometer += Speed;
                ++ticksInState;

                if(ticksInState >= MoveTime)
                {
                    isMoving = false;
                    ticksInState = 0;
                }
            } else {
                ++ticksInState;

                if(ticksInState >= RestTime)
                {
                    isMoving = true;
                    ticksInState = 0;
                }
            }
        }

        public void IncrementScore()
        {
            ++Score;
        }
    }
}
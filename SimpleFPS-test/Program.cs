// See https://aka.ms/new-console-template for more information
using aiRobots;

System.Timers.Timer fps10_timer; // fps = 10
System.Timers.Timer fps30_timer; // fps = 30
System.Timers.Timer fps60_timer; // fps = 60

SimpleFPS fps_tool_m1;
SimpleFPS fps_tool_m2;
SimpleFPS fps_tool_m3;

double sec2ms(double sec)
{
    return sec * 1000.0;
}

void initial()
{
    Console.WriteLine("initial timer with tick...");
    fps10_timer = new System.Timers.Timer(sec2ms(1.0 / 10));
    fps30_timer = new System.Timers.Timer(sec2ms(1.0 / 30));
    fps60_timer = new System.Timers.Timer(sec2ms(1.0 / 60));
    fps10_timer.Elapsed += fps10_tick;
    fps30_timer.Elapsed += fps30_tick;
    fps60_timer.Elapsed += fps60_tick;
    fps10_timer.AutoReset = true;
    fps30_timer.AutoReset = true;
    fps60_timer.AutoReset = true;
    fps10_timer.Enabled = true;
    fps30_timer.Enabled = true;
    fps60_timer.Enabled = true;

    // method 1
    fps_tool_m1 = new SimpleFPS();

    // method 2

}

void deinitial()
{
    fps10_timer.Enabled = false;
    fps30_timer.Enabled = false;
    fps60_timer.Enabled = false;
}

void press_enter()
{
    System.Console.WriteLine("press enter to close...");
    System.Console.ReadLine(); //block

}

string now()
{
    return System.DateTime.Now.ToString("HH:mm:ss.fff");
}

#region event
void fps10_tick(Object source, System.Timers.ElapsedEventArgs e)
{
    //System.Console.WriteLine($"{now()}[fps10_tick]");
}

void fps30_tick(Object source, System.Timers.ElapsedEventArgs e)
{
    //System.Console.WriteLine($"{now()}[fps30_tick]");
}

void fps60_tick(Object source, System.Timers.ElapsedEventArgs e)
{
    //System.Console.WriteLine($"{now()}[fps60_tick]");
}
#endregion

#region flow
initial();
press_enter();
deinitial();
#endregion

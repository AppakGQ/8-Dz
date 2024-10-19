using System;
using System.Collections.Generic;

interface ICommand
{
    void Execute();
    void Undo();
}

class Light
{
    public void On() => Console.WriteLine("Свет включен.");
    public void Off() => Console.WriteLine("Свет выключен.");
}

class Door
{
    public void Open() => Console.WriteLine("Дверь открыта.");
    public void Close() => Console.WriteLine("Дверь закрыта.");
}

class Thermostat
{
    private int _temperature;
    public void Increase() => Console.WriteLine("Температура увеличена.");
    public void Decrease() => Console.WriteLine("Температура уменьшена.");
}

class LightOnCommand : ICommand
{
    private Light _light;
    public LightOnCommand(Light light) => _light = light;
    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}

class LightOffCommand : ICommand
{
    private Light _light;
    public LightOffCommand(Light light) => _light = light;
    public void Execute() => _light.Off();
    public void Undo() => _light.On();
}

class DoorOpenCommand : ICommand
{
    private Door _door;
    public DoorOpenCommand(Door door) => _door = door;
    public void Execute() => _door.Open();
    public void Undo() => _door.Close();
}

class DoorCloseCommand : ICommand
{
    private Door _door;
    public DoorCloseCommand(Door door) => _door = door;
    public void Execute() => _door.Close();
    public void Undo() => _door.Open();
}

class ThermostatIncreaseCommand : ICommand
{
    private Thermostat _thermostat;
    public ThermostatIncreaseCommand(Thermostat thermostat) => _thermostat = thermostat;
    public void Execute() => _thermostat.Increase();
    public void Undo() => _thermostat.Decrease();
}

class ThermostatDecreaseCommand : ICommand
{
    private Thermostat _thermostat;
    public ThermostatDecreaseCommand(Thermostat thermostat) => _thermostat = thermostat;
    public void Execute() => _thermostat.Decrease();
    public void Undo() => _thermostat.Increase();
}

class Invoker
{
    private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var command = _commandHistory.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Нет команд для отмены.");
        }
    }
}

class Program
{
    static void Main()
    {
        var light = new Light();
        var door = new Door();
        var thermostat = new Thermostat();

        var invoker = new Invoker();

        invoker.ExecuteCommand(new LightOnCommand(light));
        invoker.ExecuteCommand(new DoorOpenCommand(door));
        invoker.ExecuteCommand(new ThermostatIncreaseCommand(thermostat));

        invoker.UndoCommand();
        invoker.UndoCommand();
    }
}

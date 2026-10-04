using CSC360DemoDesignPatterns.AbstractFactory;
using CSC360DemoDesignPatterns.Adapter;
using CSC360DemoDesignPatterns.Bridge;
using CSC360DemoDesignPatterns.Builder;
using CSC360DemoDesignPatterns.ChainOfResponsibility;
using CSC360DemoDesignPatterns.Command;
using CSC360DemoDesignPatterns.Command.UndoRedoDemo;
using CSC360DemoDesignPatterns.Composite;
using CSC360DemoDesignPatterns.Decorator;
using CSC360DemoDesignPatterns.Facade;
using CSC360DemoDesignPatterns.Factory;
using CSC360DemoDesignPatterns.FactoryMethod;
using CSC360DemoDesignPatterns.Flyweight;
using CSC360DemoDesignPatterns.Interpreter;
using CSC360DemoDesignPatterns.Iterator;
using CSC360DemoDesignPatterns.Mediator;
using CSC360DemoDesignPatterns.Memento;
using CSC360DemoDesignPatterns.Observer;
using CSC360DemoDesignPatterns.Prototype;
using CSC360DemoDesignPatterns.Proxy;
using CSC360DemoDesignPatterns.Singleton;
using CSC360DemoDesignPatterns.State;
using CSC360DemoDesignPatterns.Strategy;
using CSC360DemoDesignPatterns.TemplateMethod;
using CSC360DemoDesignPatterns.Visitor;
using BridgeCircle = CSC360DemoDesignPatterns.Bridge.Circle;
using VisitorCircle = CSC360DemoDesignPatterns.Visitor.Circle;

namespace CSC360Demo;

internal static class PatternDemoRunner
{
    public static void RunAll()
    {
        foreach (IDemoStrategy demo in DemoFactory.CreatePatternDemos())
        {
            demo.Run();
        }
    }
}

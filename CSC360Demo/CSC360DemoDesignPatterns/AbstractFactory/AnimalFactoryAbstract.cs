using CSC360DemoDesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class AnimalFactoryAbstract {
        public IReadOnlyList<string> FactoryTypes => DiscoverFactories().Keys.Order(StringComparer.OrdinalIgnoreCase).ToArray();

        public IAnimalFactory GetFactory(string factoryType) {
            ArgumentException.ThrowIfNullOrWhiteSpace(factoryType);
            if (!DiscoverFactories().TryGetValue(factoryType.Trim(), out Type? factoryClass)) {
                throw new ArgumentException($"Unknown animal family '{factoryType}'. Available families: {string.Join(", ", FactoryTypes)}.", nameof(factoryType));
            }

            return (IAnimalFactory)(Activator.CreateInstance(factoryClass)
                ?? throw new InvalidOperationException($"Could not create {factoryClass.Name}."));
        }

        private static Dictionary<string, Type> DiscoverFactories() {
            return typeof(IAnimalFactory).Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && typeof(IAnimalFactory).IsAssignableFrom(type))
                .Where(type => type.GetConstructor(Type.EmptyTypes) is not null)
                .Select(type => new { Name = type.Name.EndsWith("AnimalFactory", StringComparison.OrdinalIgnoreCase)
                    ? type.Name[..^"AnimalFactory".Length]
                    : type.Name, Type = type })
                .Where(item => item.Name.Length > 0)
                .ToDictionary(item => item.Name, item => item.Type, StringComparer.OrdinalIgnoreCase);
        }
    }
}

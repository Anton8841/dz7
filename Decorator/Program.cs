using System;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree tree = new ChristmasTree();
            OrnamentsDecorator ornamentsDecorator = new OrnamentsDecorator();
            GarlandDecorator garlandDecorator = new GarlandDecorator();

            // Link decorators
            ornamentsDecorator.SetComponent(tree);
            garlandDecorator.SetComponent(ornamentsDecorator);

            garlandDecorator.Operation();

            garlandDecorator.LightUp();

            Console.Read();
        }
    }

    abstract class Component
    {
        public abstract void Operation();

        public virtual void LightUp()
        {
        }
    }

    // "ConcreteComponent" – Ялинка
    class ChristmasTree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Це ялинка.");
        }
    }

    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }

        public override void LightUp()
        {
            if (component != null)
            {
                component.LightUp();
            }
        }
    }

    // "ConcreteDecoratorA" – Декоратор прикрас (кулі)
    class OrnamentsDecorator : Decorator
    {
        private string ornaments = "Кульки";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Додаємо прикраси: " + ornaments);
        }
    }

    // "ConcreteDecoratorB" – Декоратор гірлянди
    class GarlandDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Додаємо гірлянду.");
        }

        public override void LightUp()
        {
            // Викликаємо LightUp базового компонента (якщо він може щось робити)
            base.LightUp();
            Console.WriteLine("Гірлянда працює!");
        }
    }
}

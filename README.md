# Kinito.LinkedIn
Kinito LinkedIn Description

## Interview Questions

### Data Structures

1. Hash Table

Data structure that implements an associative array abstract data type, a structure that can map keys to values. A hash table uses a hash function to compute an index into an array of buckets or slots, from which the desired value can be found
Search: O(1)
Insert: O(1)
Algorithm: Average
Space: O(n)
Delete: O(1)

### Programming

1. Deadlock

A deadlock in C# is a situation where two or more threads are frozen in their execution because they are waiting for each other to finish

2. Composition is usually preferred to inheritance?

Inheritance exposes a subclass to details of its parent class implementation, that's why it's often said that inheritance breaks encapsulation (in a sense that you really need to focus on interfaces only not implementation, so reusing by sub classing is not always preferred).
You can use inheritance and abstraction in a base level, put a Factory Pattern on top and on top of it use composition.

### Principles

1. SOLID principle

SOLID is an acronym of the following.

* S: Single Responsibility Principle (SRP)
* O: Open closed Principle (OSP)
* L: Liskov substitution Principle (LSP)

The Liskov Substitution Principle (LSP) states that "you should be able to use any derived class instead of a parent class and have it behave in the same manner without modification". It ensures that a derived class does not affect the behavior of the parent class, in other words that a derived class must be substitutable for its base class.

* I: Interface Segregation Principle (ISP)

The Interface Segregation Principle states "that clients should not be forced to implement interfaces they don't use. Instead of one fat interface many small interfaces are preferred based on groups of methods, each one serving one sub module.".

* D: Dependency Inversion Principle (DIP)

The Dependency Inversion Principle (DIP) states that high-level modules/classes should not depend on low-level modules/classes. Both should depend upon abstractions. Secondly, abstractions should not depend upon details. Details should depend upon abstractions.
High-level modules/classes implement business rules or logic in a system (application). Low-level modules/classes deal with more detailed operations; in other words they may deal with writing information to databases or passing messages to the operating system or services.

2. ACID properties are atomicity, consistency, isolation, and durability

* Atomicity

It is one unit of work and is not subject to past and future exchanges. This exchange is either completely finished or not begun by any stretch of the imagination. Any updates in the framework amid exchange will finish completely. On the off chance that for any reason a blunder happens and the exchange can't finish the greater part of it, at that point the framework will come back to the state where the exchange began.

* Consistency

Information is either dedicated or moved back, not  an "in the middle of" situation where something has been refreshed and something hasn't and it will never leave your database until the exchange is wrapped up. On the off chance that the exchange finishes effectively, at that point all progressions to the framework will have been legitimately made, and the framework will be in a substantial state. In the event that any blunder happens in an exchange, at that point any progressions officially made will be consequently moved back. This will restore the framework to its state before the exchange was begun. Since the framework was in a reliable state when the exchange was begun, it will by and by be in a steady state.

* Isolation

No exchange sees the middle-of-the-road after effects of the present exchange. We have two exchanges, both are playing out a similar capacity and running in the meantime, and the segregation will guarantee that every exchange is isolated from every other until the point when both are done.
* Durability

When the exchange is finished  the progressions made to the framework will be perpetual regardless of the possibility that the framework crashes directly after. At whatever point the exchange begin s,each will comply with all the corrosive properties.

### Pattern Design

#### Creational Design Pattern

1. Factory Method 5/5

You can define certain methods and properties of object that will be common to all objects created using the Factory Method, but let the individual Factory Methods define what specific objects they will instantiate. Creating objects in a related family.

* The Product: defines the interfaces of objects that the factory method will create.
* The ConcreteProduct: objects implement the Product interface.
* The Creator: declares the factory method, which returns an object of type Product. The Creator can also define a default implementation of the factory method, though we will not see that in the below example.
* The ConcreteCreator: objects overrides the factory method to return an instance of a Concrete Product.

2. Abstract Factory 5/5

Creating objects in different related families without relying on concrete implementations.

* The AbstractFactory: declares an interface for operations which will create AbstractProduct objects.
* The ConcreteFactory: objects implement the operations defined by the AbstractFactory.
* The AbstractProduct: declares an interface for a type of product.
* The Products: define a product object that will be created by the corresponding ConcreteFactory.
* The Client: uses the AbstractFactory and AbstractProduct interfaces.

3. Builder
4. Prototype
5. Singleton https://csharpindepth.com/articles/singleton

* No thread-safe (I wouldn't use solution 1 because it's broken)
```c
public sealed class Singleton
{
	private static Singleton instance=null;

	private Singleton()
	{
	}

	public static Singleton Instance
	{
		get
		{
			if (instance==null)
			{
				instance = new Singleton();
			}
			return instance;
		}
	}
}
```
* Simple thread-safe (the slowest solution 5x is the locking one solution 2, worst case, I'd probably go for solution 2, which is still nice and easy to get right)
```c
public sealed class Singleton
{
	private static Singleton instance = null;
	private static readonly object padlock = new object();

	Singleton()
	{
	}

	public static Singleton Instance
	{
		get
		{
			lock (padlock)
			{
			if (instance == null)
			{
			instance = new Singleton();
			}
			return instance;
			}
		}
	}
}
```
* Double thread-safe (I wouldn't use solution 3 because it has no benefits over 5)
```c
public sealed class Singleton
{
	private static Singleton instance = null;
	private static readonly object padlock = new object();

	Singleton()
	{
	}

	public static Singleton Instance
	{
		get
		{
			if (instance == null)
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new Singleton();
					}
				}
			}
			return instance;
		}
	}
}
```
* No lock thread-safe (preference is for solution 4)
```c
public sealed class Singleton
{
	private static readonly Singleton instance = new Singleton();

	// Explicit static constructor to tell C# compiler
	// not to mark type as beforefieldinit
	static Singleton()
	{
	}

	private Singleton()
	{
	}

	public static Singleton Instance
	{
		get
		{
			return instance;
		}
	}
}
```
* Lazy with instantiation (elegant, but trickier than 2 or 4 the benefits it provides seem to only be rarely useful)
```c
public sealed class Singleton
{
	private Singleton()
	{
	}

	public static Singleton Instance { get { return Nested.instance; } }

	private class Nested
	{
		/* Explicit static constructor to tell C# compiler not to mark type as beforefieldinit*/
		static Nested()
		{
		}

		internal static readonly Singleton instance = new Singleton();
	}
}
```
* Lazy<T> (is a simpler way to achieve laziness)
```c
public sealed class Singleton
{
	private static readonly Lazy<Singleton> lazy = new Lazy<Singleton> (() => new Singleton());

	public static Singleton Instance { get { return lazy.Value; } }

	private Singleton()
	{
	}
}
```



#### Structural Design Patterns

1. Adapter
2. Bridge
3. Composite
4. Decorator
5. Façade
6. Flyweight
7. Proxy

#### Behavioral Design Patterns

1. Chain of Responsibility
2. Command
3. Interpreter
4. Iterator
5. Mediator
6. Memento
7. Observer
8. State
9. Strategy
10. Visitor
11. Template Method

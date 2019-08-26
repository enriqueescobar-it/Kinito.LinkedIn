# Kinito.LinkedIn
Kinito LinkedIn Description

## Interview Questions

### SQL Server

1. Indexes

SQL Indexes are used in relational databases to quickly retrieve data. They are similar to indexes at the end of the books whose purpose is to find a topic quickly. SQL provides Create Index, Alter Index, and Drop Index commands that are used to create a new index, update an existing index, and delete an index in SQL Server.
* Data is internally stored in a SQL Server database in “pages” where the size of each page is 8KB.
* A continuous 8 pages is called an “Extent”.
* When we create the table then one extent will be allocated for two tables and when that extent is computed it is filled with the data then another extent will be allocated and this extent may or may not be continuous to the first extent.

i. clustered A B-Tree (computed) clustered index is the index that will arrange the rows physically in the memory in sorted order.

Insert and Update with Clustered Index

- Since a clustered index arranges the rows physically in the memory in sorted order, insert and update will become slow because the row must be inserted or updated in sorted order.
- Finally, the page into which the row must be inserted or updated and if free space is not available in the page then creating the free space and then performing the insert, update and delete.
- To overcome this problem while creating a clustering index specify a fill factor and when you specify a fill factor as 70 then in every page of that table 70% will fill it with data and remaining 30% will be left free.
- Since free space is available on every page, the insert and update will fast.

ii. non clustered

* A non-clustered index is an index that will not arrange the rows physically in the memory in sorted order.
* An advantage of a non-clustered index is searching for the values that are in a range will be fast.
* You can create a maximum of 999 non-clustered indexes on a table, which is 254 up to SQL Server 2005.
* A non-clustered index is also maintained in a B-Tree data structure but leaf nodes of a B-Tree of non-clustered index contains the pointers to the pages that contain the table data and not the table data directly.

Retrieving data with non-clustered index

- When you write a select statement with a condition in a where clause then SQL Server will refer to “indid” columns of sysindexes table and when this columns contains the value in the range of 2 to 1000 then it indicates that the table has a non –clustered index and in this case it will refer to the columns root of sysindexes table to get two addresses.
Of the root node of a B-Tree of a non-clustered index and then search in the B-Tree to find the leaf node that contains the pointers to the rows that contains the value you are searching for and retrieve those rows.

Insert and Update with a Non-clustered Index

- There will be no effect of insert and update with a non-clustered index because it will not arrange the row physically in the memory in sorted order.
- With a non-clustered index, rows are inserted and updated at the end of the table.

### Data Structures

1. Hash Table

Data structure that implements an associative array abstract data type, a structure that can map keys to values. A hash table uses a hash function to compute an index into an array of buckets or slots, from which the desired value can be found
Search: O(1)
Insert: O(1)
Algorithm: Average
Space: O(n)
Delete: O(1)

### Managed code

1. Memory leaks

Object unused and .NET classes that allocate unmanaged memory
* detect with Diagnostic Too, Window If you go to Debug | Windows | Show Diagnostic Tools
* use Task Manager, Process Explorer or PerfMon
* use memory profiler dotMemory, SciTech Memory Profiler and ANTS Memory Profiler. There’s also a “free” profiler if you have Visual Studio Enterprise.
* Use "Make Object ID"
```c
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();
```
* common as Events in .NET | Static variables | Caching functionality | WPF Bindings | Captured members | Threads that never terminate
* use Dispose
* use Memory Telemetry
```c
Process currentProc = Process.GetCurrentProcess();
var bytesInUse = currentProc.PrivateMemorySize64;
PerformanceCounter ctr1 = new PerformanceCounter("Process", "Private Bytes", Process.GetCurrentProcess().ProcessName);
Debug.WriteLine("ctr1 = " + ctr1 .NextValue());
```
* test memory leaks
```c
[Test]
void MemoryLeakTest()
{
  var weakRef = new WeakReference(leakyObject)
  // Ryn an operation with leakyObject
  GC.Collect();
  GC.WaitForPendingFinalizers();
  GC.Collect();
  Assert.IsFalse(weakRef.IsAlive);
}
MemAssertion.NoInstances(typeof(MyLeakyClass));
MemAssertion.NoNewInstances(typeof(MyLeakyClass), lastSnapshot);
MemAssertion.MaxNewInstances(typeof(Bitmap), 10);
```

2. System without cache

System with cache on demand/ Set Cache Policy/ System.Web.Caching

3. TimeZone from client

Browser cache, cookies, client OS

### Threading

1. Deadlock

A deadlock in C# is a situation where two or more threads are frozen in their execution because they are waiting for each other to finish

### Programming

1. Composition is usually preferred to inheritance?

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

### Pattern Design https://www.exceptionnotfound.net/introducing-the-daily-design-pattern/

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

3. Builder 1.5/5

Creating objects which need several steps to happen in order, but the steps are different for different specific implementations.

* The Builder specifies an abstract interface for creating parts of a Product.
* The ConcreteBuilder constructs and assembles parts of the product by implementing the Builder interface. It must also define and track the representation it creates.
* The Product represents the object being constructed. It includes classes for defining the parts of the object, including any interfaces for assembling the parts into the final result.
* The Director constructs an object using the Builder interface. 

4. Prototype 3/5

Creating lots of similar objects. Like color spectrum.

* The Prototype declares an interface for cloning itself.
* The ConcretePrototype implements the cloning operation defined in the Prototype.
* The Client creates a new object by asking the Prototype to clone itself.

5. Singleton 2/5 https://csharpindepth.com/articles/singleton

Creating an object of which there can only ever be one. The Singleton is a class which defines exactly one instance of itself, and that instance is globally accessible.

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

1. Adapter 4/5

Adapting two interfaces together when one or more of those interfaces cannot be refactored.

* The Target defines the domain-specific interface in use by the Client.
* The Client collaborates with objects which conform to the Target.
* The Adapter adapts the Adaptee to the Target.
* The Adaptee is the interface that needs adapting (i.e. the one that cannot be refactored).

2. Bridge 3/5

Allowing lots of variation between implementations of interfaces.

* The Abstraction defines an interface and maintains a reference to an Implementor.
* The RefinedAbstraction extends the interface defined by the Abstraction.
* The Implementor defines the interface for the ConcreteImplementor objects. This interface does not need to correspond to the Abstraction's interface.
* The ConcreteImplementor objects implement the Implementor interface.

3. Composite 4/5

Treating different objects in a hierarchy as the same.

* The Component declares an interface for objects in the composition. It also implements behavior that is common to all objects in said composition. Finally, it must implement an interface for adding/removing it's own child components.
* The Leaves represent leaf behavior in the composition (a leaf is an object with no children). It also defines primitive behavior for said objects.
* The Composite defines behavior for components which have children (contrasting the Leaves). It also stores its child components and implements the add/remove children interface from the Component.
* The Client manipulates objects in the composition through the Component interface.

4. Decorator 3/5

Injecting new functionality into instances of objects at runtime rather than including that functionality in the class of objects.

* The Component defines the interface for objects which will have responsibilities or abilities added to them dynamically.
* The ConcreteComponent objects are objects to which said responsibilities are added.
* The Decorator maintains a reference to a Component and defines and interface that conforms to the Component interface.
* The ConcreteDecorator objects are the classes which actually add responsibilities to the ConcreteComponent classes.

5. Façade 5/5

Hiding complexity which cannot be refactored away.

* The Subsystems are any classes or objects which implement functionality but can be "wrapped" or "covered" by the Facade to simplify an interface.
* The Facade is the layer of abstraction above the Subsystems, and knows which Subsystem to delegate appropriate work to.

6. Flyweight 1/5

Creating lots of instances of the same set of objects and thereby improving performance.
The intrinsic state, which is stored within the Flyweight object itself, and
The extrinsic state, which is stored or calculated by other components.

* The Flyweight declares an interface through which flyweights can receive and act upon extrinsic state.
* The ConcreteFlyweight objects implement the Flyweight interface and may be sharable. Any state stored by these objects must be intrinsic to the object.
* The FlyweightFactory creates and manages flyweight objects, while also ensuring that they are shared properly. When the FlyweightFactory is asked to create an object, it either uses an existing instance of that object or creates a new one if no existing one exists.
* The Client maintains a reference to flyweights and computes or stores the extrinsic state of said flyweights.

7. Proxy 4/5

Controlling access to a particular object, testing scenarios.

* The Subject defines a common interface for the RealSubject and the Proxy such that the Proxy can be used anywhere the RealSubject is expected.
* The RealSubject defines the concrete object which the Proxy represents.
* The Proxy maintains a reference to the RealSubject and controls access to it. It must implement the same interface as the RealSubject so that the two can be used interchangeably.

#### Behavioral Design Patterns

1. Chain of Responsibility 2/5

Allowing multiple different objects to possibly process a request.

* The Handler defines an interface for handling requests.
* The ConcreteHandler objects can each handle a request, and can access their successor object.
* The Client initiates the request to a ConcreteHandler object.

2. Command 4/5

Encapsulating requests as objects so that they can be processed differently by different receivers.

* The Command declares an interface for executing an operation.
* The ConcreteCommand defines a binding between a Receiver and an action.
* The Client creates a ConcreteCommand object and sets its receiver.
* The Invoker asks the command to carry out its request.
* The Receiver knows how to perform the operations associated with carrying out the request.

3. Interpreter :(

4. Iterator 5/5

Extracting objects from a collection without exposing the collection itself.

* The Iterator defines an interface for accessing an Aggregate object and traversing elements within that Aggregate.
* The ConcreteIterator implements the Iterator interface and keeps track of its current position within the Aggregate.
* The Aggregate defines an interface for creating an Iterator object.
* The ConcreteAggregate implements the Iterator creation interface and returns a ConcreteIterator for that ConcreteAggregate.

5. Mediator 2/5

Defining how objects interact with each other.

* The Mediator defines an interface for communicating with Collegue objects.
* The Colleague classes each know what Mediator is responsible for them and communicates with said Mediator whenever it would have otherwise communicated directly with another Colleague.
* The ConcreteMediator classes implement behavior to coordinate Colleague objects. Each ConcreteMediator knows what its constituent Colleague classes are.

6. Memento 2/5

Restoring an object's state from a previous state by creating a memento of said previous state.

* The Memento stores internal state of the Originator object. The Memento has no limit on what it may or may not store (e.g. as much or as little of the Originator's state as needed).
* The Originator creates a Memento containing a "snapshot" of its internal state, and then later uses that memento to restore its internal state.
* The Caretaker is responsible for the Memento's safekeeping, but does not operate on or examine the contents of that Memento.

7. Observer 4/5

Notifying observer objects that a particular subject's state changed.

* The Subject knows its Observers and provides an interface for attaching or detaching any number of Observer objects.
* The ConcreteSubject objects store the states of interest to the Observers and are responsible for sending a notification when the ConcreteSubject's state changes.
* The Observer defines an updating interface for objects that should be notified of changes in a Subject.
* The ConcreteObserver objects maintain a reference to a ConcreteSubject and implement the Observer updating interface to keep its state consistent with that of the Subject's.

8. State 3/5

Allowing an object's behavior to change as its internal state does.

* The Context defines an interface of interest to the clients. It also maintains a reference to an instance of ConcreteState which represents the current state.
* The State defines an interface for encapsulating the behavior of the object associated with a particular state.
* The ConcreteState objects are subclasses which each implement a behavior (or set of behaviors) associated with a state of the Context.

9. Strategy 4/5

Encapsulating parts of an algorithm as objects and allowing them to be invoked independently.

* The Strategy declares an interface which is implemented by all supported algorithms.
* The ConcreteStrategy objects implement the algorithm defined by the Strategy.
* The Context maintains a reference to a Strategy object, and uses that reference to call the algorithm defined by a particular ConcreteStrategy.

10. Visitor 1/5

Operating on objects without changing their classes.

* The Visitor declares an operation for each of ConcreteElement in the object structure.
* The ConcreteVisitor implements each operation defined by the Visitor. Each operation implements a fragment of the algorithm needed for that object.
* The Element defines an Accept operation which takes a Visitor as an argument.
* The ConcreteElement implements the Accept operation defined by the Element.
* The ObjectStructure can enumerate its elements and may provide a high-level interface to allow the Visitor to visit its elements.

11. Template Method 4/5

Creating an outline of an algorithm but letting specific steps be implemented by other classes.

* The AbstractClass defines a set of abstract operations which can (optionally) be implemented by ConcreteClass objects. It also implements a template method which controls the order in which those abstract operations occur.
* The ConcreteClass objects implement the operations defined by the AbstractClass.

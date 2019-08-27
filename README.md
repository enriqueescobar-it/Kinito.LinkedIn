# Kinito.LinkedIn

Kinito LinkedIn Description

## Interview Questions

### TDD

1. Add a test
2. Run all tests and see if the new test fails
3. Write the code
4. Run tests
5. Refactor code

### Web Services

Defined as the mechanism or a medium of communication through which two applications or machines exchange information

* It is any piece of software that makes itself available over the internet and uses a standardized XML messaging system
* These are self-contained, modular, dynamic applications that can be described and published on the network to create products and supply chains.
* These applications can be local, distributed or web based.
* Generally use HTTP or HTTPS protocol over the application layer computer network, where applications sends requests and transfer data through XML or JSON.
* The functionality offered by the a web service uses a the Web Services Description Language, which is an XML-based language.
* A WSDL description of a web service provides a machine readable description of how the service can be called, what parameters it expects and what data structures it returns.
* Web services allow exchange of important data between various applications in a platform independent manner.
* Identified by an URI, a web service is a software system whose public interfaces and bindings are defined and described by the XML.

#### Advantages

1. Interoperability
2. Usability
3. Reusability
4. Deployability: deployed over standard internet technologies with SSL, standard protocol
5. Cost effective: SOAP over HTTP / FTP

##### Testing

SOAP UI, TestingWhiz, SOAP Sonar, vRest, SOAPTest
Steps:

1. The first step in Web Service Testing is to understand the WSDL file definition.
2. Determining the operations provided by the Web Services.
3. Finding the XML Request message format that needs to be delivered.
4. XML Response message format is determined.
5. Develop a test program or testing tool that could send XML message request and receive request as XML message response.

Types:

1. Functional Testing
2. Performance Testing
3. Security Testing
4. Regression Testing
5. Load Testing
6. Compliance Testing


REST | SOAP
---------|----------
 Representational State Transfer | Simple Object Access Protocol
 is a software architecture, which can be implemented with webservices | is just a technology (one of many) for providing services over "web" or HTTP.
 architectural principles by which data can be transmitted over a standardized interface | protocol specification for XML based message exchange.
 REST can use SOAP web services, since it is a concept that can use any protocol like HTTP, SOPA, etc | Uses different transport protocols, such as HTTP and SMTP
 RESTful Web Services | Web Service Description Language (WSDL) defines rules for the message, binding, operations, and location of the service by describing common set of rules
 RESTFUL web API does not have any official standard | It uses service interfaces to expose business logics
 expose the operations as a service of unique resources, which correspond to a specific URL | SOAP is defined by W3C standard for sending and receiving web service requests and responses
 REST web services are stateless, that is one can test this service by just restarting the server and verifying the condition of the interactions | SOAP approach the team does not have to write code into the application layer
 REST requires less bandwidth and resources | requirement of bandwidth and resources is more in SOAP web services
 It permits various data formats, such as XML, Plain Text, HTML, JSON, and more | SOAP web services permit XML data format only
 REST inherits security measures from the underlying transport | SOAP is well equipped in defining its own security
 REST implementation is simple and more preferred than SOAP | less preferred than REST, SOAP still offers various advantages to the user

#### Micro services (are the extension of web services)

CRUD as:

POST http://www.example.com/customers/12345/orders

GET http://www.example.com/buckets/sample

PUT http://www.example.com/buckets/secret_stuff

PATCH http://www.example.com/customers/12345

DELETE http://www.example.com/bucket/sample

* REST - Built around RESTful Resources. Communication can be HTTP or event based.
* Small Well Chosen Deployable Units - Bounded Contexts
* Cloud Enabled - Dynamic Scaling
* Service granularity
* Web services are typically vertical in nature(Provider-Consumer communication) whereas microservices are horizontal in nature
* Microservices are seen as architecture due to the following.
* Microservices have belonged to one specific application.
* Microservices are addressing specific concern so that can be said as lightweight.
* Changes are isolated in nature because the change in one microservice doesn't affect other (Ex.  Changes done in login microservice does not affect the payment microservice)
* Scaling individual microservices are easy.
* Microservice usually has its own database.

##### Advantages

* New Technology & Process Adaption becomes easier. You can try new technologies with the newer microservices that we create.
* Faster Release Cycles
* Scaling with Cloud

##### Challenges

* Quick Setup needed : You cannot spend a month setting up each microservice. You should be able to create microservices quickly.
* Automation : Because there are a number of smaller components instead of a monolith, you need to automate everything - Builds, Deployment, Monitoring etc.
* Visibility : You now have a number of smaller components to deploy and maintain. Maybe 100 or maybe 1000 components. You should be able to monitor and identify problems automatically. You need great visibility around all the components.
* Bounded Context : Deciding the boundaries of a microservice is not an easy task. Bounded Contexts from Domain Driven Design is a good starting point. Your understanding of the domain evolves over a period of time. You need to ensure that the microservice boundaries evolve.
* Configuration Management : You need to maintain configurations for hundreds of components across environments. You would need a Configuration Management solution
* Dynamic Scale Up and Scale Down : The advantages of microservices will only be realized if your applications can scaled up and down easily in the cloud.
* Pack of Cards : If a microservice at the bottom of the call chain fails, it can have knock on effects on all other microservices. Microservices should be fault tolerant by Design.
* Debugging : When there is a problem that needs investigation, you might need to look into multiple services across different components. Centralized Logging and Dashboards are essential to make it easy to debug problems.
* Consistency : You cannot have a wide range of tools solving the same problem. While it is important to foster innovation, it is also important to have some decentralized governance around the languages, platforms, technology and tools used for implementing/deploying/monitoring microservices.

### SQL Server

#### Indexes

SQL Indexes are used in relational databases to quickly retrieve data. They are similar to indexes at the end of the books whose purpose is to find a topic quickly. SQL provides Create Index, Alter Index, and Drop Index commands that are used to create a new index, update an existing index, and delete an index in SQL Server.
* Data is internally stored in a SQL Server database in "pages" where the size of each page is 8KB.
* A continuous 8 pages is called an "Extent".
* When we create the table then one extent will be allocated for two tables and when that extent is computed it is filled with the data then another extent will be allocated and this extent may or may not be continuous to the first extent.

##### Clustered Index

B-Tree (computed) clustered index is the index that will arrange the rows physically in the memory in sorted order.

Insert and Update with Clustered Index

- Since a clustered index arranges the rows physically in the memory in sorted order, insert and update will become slow because the row must be inserted or updated in sorted order.
- Finally, the page into which the row must be inserted or updated and if free space is not available in the page then creating the free space and then performing the insert, update and delete.
- To overcome this problem while creating a clustering index specify a fill factor and when you specify a fill factor as 70 then in every page of that table 70% will fill it with data and remaining 30% will be left free.
- Since free space is available on every page, the insert and update will fast.

##### Non Clustered Index

* A non-clustered index is an index that will not arrange the rows physically in the memory in sorted order.
* An advantage of a non-clustered index is searching for the values that are in a range will be fast.
* You can create a maximum of 999 non-clustered indexes on a table, which is 254 up to SQL Server 2005.
* A non-clustered index is also maintained in a B-Tree data structure but leaf nodes of a B-Tree of non-clustered index contains the pointers to the pages that contain the table data and not the table data directly.

1. Retrieving data with non-clustered index

    When you write a select statement with a condition in a where clause then SQL Server will refer to "indid" columns of sysindexes table and when this columns contains the value in the range of 2 to 1000 then it indicates that the table has a non–clustered index and in this case it will refer to the columns root of sysindexes table to get two addresses.
    Of the root node of a B-Tree of a non-clustered index and then search in the B-Tree to find the leaf node that contains the pointers to the rows that contains the value you are searching for and retrieve those rows.

2. Insert and Update with a Non-clustered Index

- There will be no effect of insert and update with a non-clustered index because it will not arrange the row physically in the memory in sorted order.
- With a non-clustered index, rows are inserted and updated at the end of the table.

Clustered Index | Non-Clustered Index
---------|----------
 This will arrange the rows physically in the memory in sorted order | This will not arrange the rows physically in the memory in sorted order.
 This will fast in searching for the range of values. | This will be fast in searching for the values that are not in the range.
 Index for table. | You can create a maximum of 999 non clustered indexes for table.
 Leaf node of 3 tier of clustered index contains, contains table data. | Leaf nodes of b-tree of non-clustered index contains pointers to get the contains pointers to get that contains two table data, and not the table data directly.

### Data Structures

#### Stack<T> LIFO [Array]

Stack allows null value and also duplicate values. It provides a Push() method to add a value and Pop() or Peek() methods to retrieve values.

#### Queue<T> FIFO [Array]

Queue collection allows multiple null and duplicate values. Use the Enqueue() method to add values and the Dequeue() method to retrieve the values from the Queue.

#### Hash Set<T> [Hash table with links to another array index for collision]

* The HashSet<T> class provides high-performance set operations. A set is a collection that contains no duplicate elements, and whose elements are in no particular order.
* The capacity of a HashSet<T> object is the number of elements that the object can hold.
* A HashSet<T> object’s capacity automatically increases as elements are added to the object.
* A HashSet<T> collection is not sorted and cannot contain duplicate elements.
* HashSet<T> provides many mathematical set operations, such as set addition (unions) and set subtraction.

Search: O(1)

#### List<T> [Array]

Unlike arrays that are fixed in size, lists can grow in size dynamically. That’s why they’re also called dynamic arrays or vectors.

Search: O(1)
Insert: O(1) add O(n) insert
Algorithm:
Space: O(n)
Delete: O(n)

#### Hash Table

Implements an associative array abstract data type, a structure that can map keys to values. A hash table uses a hash function to compute an index into an array of buckets or slots, from which the desired value can be found

Search: O(1)
Insert: O(1)
Algorithm: Average
Space: O(n)
Delete: O(1)

#### Set

there is an interface ISet<T> representing the ADT "set" and it has two standard implementation classes HashSet<T> (hash-table based) & SortedSet<T> (red-black tree based)

#### Tree

#### Map

#### Dictionary<TKey, TValue> [Hash table with links to another array index for collision]

Search: O(n)
Insert: O(1) add O(n) insert
Algorithm: Average
Space: O(n)
Delete: O(n)

### Managed code

#### Memory leaks

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

#### System without cache

System with cache on demand/ Set Cache Policy/ System.Web.Caching

#### TimeZone from client

Browser cache, cookies, client OS

### Threading

#### Deadlock

A deadlock in C# is a situation where two or more threads are frozen in their execution because they are waiting for each other to finish

#### .NET

System.Threading (ThreadPool.SetMaxThreads, Monitor.TryEnter, Thread.Abort, Thread.Suspend, Thread.Resume, Thread.CurrentThread as ThreadState)
System (Environment.ProcessorCount)

##### Blocking queue

```c
public class BlockingQueue<T>
{
    Queue<T> que = new Queue<T>();
    Semaphore sem = new Semaphore(0, Int32.MaxValue);

    public void Enqueue(T item)
    {
        lock (que)
        {
            que.Enqueue(item);
        }

        sem.Release();
    }

    public T Dequeue()
    {
        sem.WaitOne();

        lock (que)
        {
            return que.Dequeue();
        }
    }
}
```

### Programming

1. Composition is usually preferred to inheritance?

Inheritance exposes a subclass to details of its parent class implementation, that's why it's often said that inheritance breaks encapsulation (in a sense that you really need to focus on interfaces only not implementation, so reusing by sub classing is not always preferred).
You can use inheritance and abstraction in a base level, put a Factory Pattern on top and on top of it use composition.

### Principles

#### SOLID principle

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

#### ACID properties are atomicity, consistency, isolation, and durability

##### Atomicity

It is one unit of work and is not subject to past and future exchanges. This exchange is either completely finished or not begun by any stretch of the imagination. Any updates in the framework amid exchange will finish completely. On the off chance that for any reason a blunder happens and the exchange can't finish the greater part of it, at that point the framework will come back to the state where the exchange began.

##### Consistency

Information is either dedicated or moved back, not  an "in the middle of" situation where something has been refreshed and something hasn't and it will never leave your database until the exchange is wrapped up. On the off chance that the exchange finishes effectively, at that point all progressions to the framework will have been legitimately made, and the framework will be in a substantial state. In the event that any blunder happens in an exchange, at that point any progressions officially made will be consequently moved back. This will restore the framework to its state before the exchange was begun. Since the framework was in a reliable state when the exchange was begun, it will by and by be in a steady state.

##### Isolation

No exchange sees the middle-of-the-road after effects of the present exchange. We have two exchanges, both are playing out a similar capacity and running in the meantime, and the segregation will guarantee that every exchange is isolated from every other until the point when both are done.

##### Durability

When the exchange is finished  the progressions made to the framework will be perpetual regardless of the possibility that the framework crashes directly after. At whatever point the exchange begins, each will comply with all the corrosive properties.

### Pattern Design https://www.exceptionnotfound.net/introducing-the-daily-design-pattern/

#### Creational Design Pattern

##### Factory Method 5/5

You can define certain methods and properties of object that will be common to all objects created using the Factory Method, but let the individual Factory Methods define what specific objects they will instantiate. Creating objects in a related family.

* The Product: defines the interfaces of objects that the factory method will create.
* The ConcreteProduct: objects implement the Product interface.
* The Creator: declares the factory method, which returns an object of type Product. The Creator can also define a default implementation of the factory method, though we will not see that in the below example.
* The ConcreteCreator: objects overrides the factory method to return an instance of a Concrete Product.

##### Abstract Factory 5/5

Creating objects in different related families without relying on concrete implementations.

* The AbstractFactory: declares an interface for operations which will create AbstractProduct objects.
* The ConcreteFactory: objects implement the operations defined by the AbstractFactory.
* The AbstractProduct: declares an interface for a type of product.
* The Products: define a product object that will be created by the corresponding ConcreteFactory.
* The Client: uses the AbstractFactory and AbstractProduct interfaces.

##### Builder 1.5/5

Creating objects which need several steps to happen in order, but the steps are different for different specific implementations.

* The Builder specifies an abstract interface for creating parts of a Product.
* The ConcreteBuilder constructs and assembles parts of the product by implementing the Builder interface. It must also define and track the representation it creates.
* The Product represents the object being constructed. It includes classes for defining the parts of the object, including any interfaces for assembling the parts into the final result.
* The Director constructs an object using the Builder interface. 

##### Prototype 3/5

Creating lots of similar objects. Like color spectrum.

* The Prototype declares an interface for cloning itself.
* The ConcretePrototype implements the cloning operation defined in the Prototype.
* The Client creates a new object by asking the Prototype to clone itself.

##### Singleton 2/5 https://csharpindepth.com/articles/singleton

Creating an object of which there can only ever be one. The Singleton is a class which defines exactly one instance of itself, and that instance is globally accessible.

1. No thread-safe (I wouldn't use solution 1 because it's broken)
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
2. Simple thread-safe (the slowest solution 5x is the locking one solution 2, worst case, I'd probably go for solution 2, which is still nice and easy to get right)
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
3. Double thread-safe (I wouldn't use solution 3 because it has no benefits over 5)
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
4. No lock thread-safe (preference is for solution 4)
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
5. Lazy with instantiation (elegant, but trickier than 2 or 4 the benefits it provides seem to only be rarely useful)
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
6. Lazy<T> (is a simpler way to achieve laziness)
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

##### Adapter 4/5

Adapting two interfaces together when one or more of those interfaces cannot be refactored.

* The Target defines the domain-specific interface in use by the Client.
* The Client collaborates with objects which conform to the Target.
* The Adapter adapts the Adaptee to the Target.
* The Adaptee is the interface that needs adapting (i.e. the one that cannot be refactored).

##### Bridge 3/5

Allowing lots of variation between implementations of interfaces.

* The Abstraction defines an interface and maintains a reference to an Implementor.
* The RefinedAbstraction extends the interface defined by the Abstraction.
* The Implementor defines the interface for the ConcreteImplementor objects. This interface does not need to correspond to the Abstraction's interface.
* The ConcreteImplementor objects implement the Implementor interface.

##### Composite 4/5

Treating different objects in a hierarchy as the same.

* The Component declares an interface for objects in the composition. It also implements behavior that is common to all objects in said composition. Finally, it must implement an interface for adding/removing it's own child components.
* The Leaves represent leaf behavior in the composition (a leaf is an object with no children). It also defines primitive behavior for said objects.
* The Composite defines behavior for components which have children (contrasting the Leaves). It also stores its child components and implements the add/remove children interface from the Component.
* The Client manipulates objects in the composition through the Component interface.

##### Decorator 3/5

Injecting new functionality into instances of objects at runtime rather than including that functionality in the class of objects.

* The Component defines the interface for objects which will have responsibilities or abilities added to them dynamically.
* The ConcreteComponent objects are objects to which said responsibilities are added.
* The Decorator maintains a reference to a Component and defines and interface that conforms to the Component interface.
* The ConcreteDecorator objects are the classes which actually add responsibilities to the ConcreteComponent classes.

##### Façade 5/5

Hiding complexity which cannot be refactored away.

* The Subsystems are any classes or objects which implement functionality but can be "wrapped" or "covered" by the Facade to simplify an interface.
* The Facade is the layer of abstraction above the Subsystems, and knows which Subsystem to delegate appropriate work to.

##### Flyweight 1/5

Creating lots of instances of the same set of objects and thereby improving performance.
The intrinsic state, which is stored within the Flyweight object itself, and
The extrinsic state, which is stored or calculated by other components.

* The Flyweight declares an interface through which flyweights can receive and act upon extrinsic state.
* The ConcreteFlyweight objects implement the Flyweight interface and may be sharable. Any state stored by these objects must be intrinsic to the object.
* The FlyweightFactory creates and manages flyweight objects, while also ensuring that they are shared properly. When the FlyweightFactory is asked to create an object, it either uses an existing instance of that object or creates a new one if no existing one exists.
* The Client maintains a reference to flyweights and computes or stores the extrinsic state of said flyweights.

##### Proxy 4/5

Controlling access to a particular object, testing scenarios.

* The Subject defines a common interface for the RealSubject and the Proxy such that the Proxy can be used anywhere the RealSubject is expected.
* The RealSubject defines the concrete object which the Proxy represents.
* The Proxy maintains a reference to the RealSubject and controls access to it. It must implement the same interface as the RealSubject so that the two can be used interchangeably.

#### Behavioral Design Patterns

##### Chain of Responsibility 2/5

Allowing multiple different objects to possibly process a request.

* The Handler defines an interface for handling requests.
* The ConcreteHandler objects can each handle a request, and can access their successor object.
* The Client initiates the request to a ConcreteHandler object.

##### Command 4/5

Encapsulating requests as objects so that they can be processed differently by different receivers.

* The Command declares an interface for executing an operation.
* The ConcreteCommand defines a binding between a Receiver and an action.
* The Client creates a ConcreteCommand object and sets its receiver.
* The Invoker asks the command to carry out its request.
* The Receiver knows how to perform the operations associated with carrying out the request.

##### Interpreter 4/5

Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.
This pattern involves implementing an expression interface which tells to interpret a particular context. This pattern is used in the compilers or parsers or Macro expansions

* Client: This is the class that builds the abstract syntax tree for a set of instructions in the given grammar. This tree builds with the help of instances of NonTerminalExpression and TerminalExpression classes.
* Context: This is a class that contains information (input and output), which is used by the Interpreter.
* Expression: This is an interface that defines the Interpret operation, which must be implemented by each subclass.
* NonTerminal: This is a class that implements the Expression. This can have other instances of Expression.
* Terminal: This is a class that implements the Expression.

##### Iterator 5/5

Extracting objects from a collection without exposing the collection itself.

* The Iterator defines an interface for accessing an Aggregate object and traversing elements within that Aggregate.
* The ConcreteIterator implements the Iterator interface and keeps track of its current position within the Aggregate.
* The Aggregate defines an interface for creating an Iterator object.
* The ConcreteAggregate implements the Iterator creation interface and returns a ConcreteIterator for that ConcreteAggregate.

##### Mediator 2/5

Defining how objects interact with each other.

* The Mediator defines an interface for communicating with Collegue objects.
* The Colleague classes each know what Mediator is responsible for them and communicates with said Mediator whenever it would have otherwise communicated directly with another Colleague.
* The ConcreteMediator classes implement behavior to coordinate Colleague objects. Each ConcreteMediator knows what its constituent Colleague classes are.

##### Memento 2/5

Restoring an object's state from a previous state by creating a memento of said previous state.

* The Memento stores internal state of the Originator object. The Memento has no limit on what it may or may not store (e.g. as much or as little of the Originator's state as needed).
* The Originator creates a Memento containing a "snapshot" of its internal state, and then later uses that memento to restore its internal state.
* The Caretaker is responsible for the Memento's safekeeping, but does not operate on or examine the contents of that Memento.

##### Observer 4/5

Notifying observer objects that a particular subject's state changed.

* The Subject knows its Observers and provides an interface for attaching or detaching any number of Observer objects.
* The ConcreteSubject objects store the states of interest to the Observers and are responsible for sending a notification when the ConcreteSubject's state changes.
* The Observer defines an updating interface for objects that should be notified of changes in a Subject.
* The ConcreteObserver objects maintain a reference to a ConcreteSubject and implement the Observer updating interface to keep its state consistent with that of the Subject's.

##### State 3/5

Allowing an object's behavior to change as its internal state does.

* The Context defines an interface of interest to the clients. It also maintains a reference to an instance of ConcreteState which represents the current state.
* The State defines an interface for encapsulating the behavior of the object associated with a particular state.
* The ConcreteState objects are subclasses which each implement a behavior (or set of behaviors) associated with a state of the Context.

##### Strategy 4/5

Encapsulating parts of an algorithm as objects and allowing them to be invoked independently.

* The Strategy declares an interface which is implemented by all supported algorithms.
* The ConcreteStrategy objects implement the algorithm defined by the Strategy.
* The Context maintains a reference to a Strategy object, and uses that reference to call the algorithm defined by a particular ConcreteStrategy.

##### Visitor 1/5

Operating on objects without changing their classes.

* The Visitor declares an operation for each of ConcreteElement in the object structure.
* The ConcreteVisitor implements each operation defined by the Visitor. Each operation implements a fragment of the algorithm needed for that object.
* The Element defines an Accept operation which takes a Visitor as an argument.
* The ConcreteElement implements the Accept operation defined by the Element.
* The ObjectStructure can enumerate its elements and may provide a high-level interface to allow the Visitor to visit its elements.

##### Template Method 4/5

Creating an outline of an algorithm but letting specific steps be implemented by other classes.

* The AbstractClass defines a set of abstract operations which can (optionally) be implemented by ConcreteClass objects. It also implements a template method which controls the order in which those abstract operations occur.
* The ConcreteClass objects implement the operations defined by the AbstractClass.

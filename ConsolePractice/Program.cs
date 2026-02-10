// See https://aka.ms/new-console-template for more information
using ConsolePractice;
using ConsolePractice.Altimetrik.OpenIntervue;
using ConsolePractice.Codility;
using ConsolePractice.GeneralQuery;
using ConsolePractice.Indexers;
using ConsolePractice.InventoryManagementSystem;
using ConsolePractice.Polymorphism;
using ConsolePractice.SagaPattern.MessageBus;
using ConsolePractice.SagaPattern.Orchestrator;
using ConsolePractice.SagaPattern.Services;
using ConsolePractice.SpecialDataTypes;
using ConsolePractice.Test;
using static System.Runtime.InteropServices.JavaScript.JSType;
using InventoryService = ConsolePractice.SagaPattern.Services.InventoryService;


// Data Structures & Algorithms
// Sort and Count Duplicates
Console.WriteLine("Start of Sort and Count Duplicates");
int[] sortInput = { };
TechnicalAssessmentNetLead.SortAndCountDuplicates(sortInput);
var sortResult = TechnicalAssessmentNetLead.Process(sortInput);
TechnicalAssessmentNetLead.PrintResult(sortResult);
Console.WriteLine("End of Sort and Count Duplicates");

// Find Maximum Depth
// Construct tree from level order
Console.WriteLine("Start of Find Maximum Depth - Construct tree from level order");
var root = FindTreeNode.BuildTree(new int[] { 1, 2, 3, 4, -1, -1, 5 });

// Compute maximum depth
int depth = FindTreeNode.MaxDepth(root);

Console.WriteLine("Sample Output ==> " + depth);
Console.WriteLine("End of Find Maximum Depth - Construct tree from level order");

// Finds the length of the shortest path in a directed graph from a starting node to a target node using Breadth-First Search (BFS). The graph is represented as a list of edges, where each edge is a tuple containing the source node, destination node, and weight (which is ignored in this BFS implementation).
Console.WriteLine("Start of Finds the length of the shortest path in a directed graph");
var edges = new List<(int, int, int)>
{
    (1, 2, 5),
    (2, 3, 2),
    (1, 4, 1),
    (4, 5, 3),
    (5, 3, 1),
    (3, 6, 4)
};

Console.WriteLine("Test Case 1: " + ShortestPathBFS.FindShortestPathLength(edges, 1, 6)); // Expected: 3 (1->4->5->3->6 is 4 edges, but 1->2->3->6 is 3 edges
Console.WriteLine("Test Case 2: " + ShortestPathBFS.FindShortestPathLength(edges, 1, 3)); // Expected: 2 (1->2->3)
Console.WriteLine("Test Case 3: " + ShortestPathBFS.FindShortestPathLength(edges, 4, 6)); // Expected: 3 (4->5->3->6)
Console.WriteLine("Test Case 4: " + ShortestPathBFS.FindShortestPathLength(edges, 2, 5)); // Expected: -1 (no path from 2 to 5)
Console.WriteLine("Test Case 5: " + ShortestPathBFS.FindShortestPathLength(edges, 1, 1)); // Expected: 0 (start == target)
Console.WriteLine("End of Finds the length of the shortest path in a directed graph");

var edgesGraph = new List<(int, int, int)>
{
    (1, 2, 5),
    (2, 3, 2),
    (1, 4, 1),
    (4, 5, 3),
    (5, 3, 1),
    (3, 6, 4)
};

var graph = new GraphShortestPath(edgesGraph);

// BFS (edge count)
Console.WriteLine("BFS Path 1->6: " + graph.FindShortestPath(1, 6, PathMode.EdgeCount)); // Expected: 3
Console.WriteLine("BFS Path 1->3: " + graph.FindShortestPath(1, 3, PathMode.EdgeCount)); // Expected: 2
Console.WriteLine("BFS Path 2->5: " + graph.FindShortestPath(2, 5, PathMode.EdgeCount)); // Expected: -1

// Dijkstra (weighted)
Console.WriteLine("Dijkstra Path 1->6: " + graph.FindShortestPath(1, 6, PathMode.Weighted)); // Expected: 9
Console.WriteLine("Dijkstra Path 1->3: " + graph.FindShortestPath(1, 3, PathMode.Weighted)); // Expected: 5
Console.WriteLine("Dijkstra Path 4->6: " + graph.FindShortestPath(4, 6, PathMode.Weighted)); // Expected: 8


// Shortest Path in DAG using Dijkstra's algorithm
var edgesDAG = new List<Tuple<int, int, int>>
{
    // Test Case 1
    //Tuple.Create(0, 1, 10),
    //Tuple.Create(0, 2, 3),
    //Tuple.Create(1, 2, 1),
    //Tuple.Create(1, 3, 2),
    //Tuple.Create(2, 1, 4),
    //Tuple.Create(2, 3, 8)

    // Test Case 2
    //Tuple.Create(0,1,2), 
    //Tuple.Create(0,4,1), 
    //Tuple.Create(1,2,3), 
    //Tuple.Create(4,2,2), 
    //Tuple.Create(4,5,4), 
    //Tuple.Create(2,3,6), 
    //Tuple.Create(5,3,1)

    // Test Case 3
    // Tuple.Create(0,1,5)

    // Test Case 4
    Tuple.Create(0,1,2),
    Tuple.Create(1,2,3),
    Tuple.Create(0,2,6)
};

// Test Case 1
//var resultDAG = DijkstraDAG.ShortestPathInDAG(5, 6, edgesDAG, 0);
// Test Case 2
//var resultDAG = DijkstraDAG.ShortestPathInDAG(6, 7, edgesDAG, 0);
// Test Case 3
//var resultDAG = DijkstraDAG.ShortestPathInDAG(2, 1, edgesDAG, 0);
// Test Case 4
var resultDAG = DijkstraDAG.ShortestPathInDAG(3, 3, edgesDAG, 0);

foreach (var r in resultDAG)
{
    Console.WriteLine("Shortest Path in DAG using Dijkstra's ==>> " + r);
}


// Console.WriteLine("Hello, World! Welcome to Console App in Visula Studio Code");
// Logic question - Given an array of ints, write a C# method to total all the values that are even numbers.
var evenNumberSum = Logical.TotalAllEvenNumbers([1, 2, 3, 4, 5, 6, 7]);
Console.WriteLine("Sum of All Even Numbers ==>> " + evenNumberSum);
var oddNumberSum = Logical.TotalAllOddNumbers([1, 2, 3, 4, 5, 6, 7]);
Console.WriteLine("Sum of All Odd Numbers ==>> " + oddNumberSum);

// Anagram without Using Built-in Reverse Function
var createAnagram = Logical.CreateAnagram("kanak");
Console.WriteLine("Anagram without Using Built-in Reverse Function ==>> " + createAnagram);

// Multiply two numbers without using *
var multiply = Logical.MultiplyWithoutStar(7, 8);
Console.WriteLine("Multiply two numbers without using * ==>> " + multiply);

// finds and returns the first k non-repeating characters from a string
var nonRepeat = Logical.GetFirstKNonRepeatedChars("Hello world!", 3);
Console.WriteLine("finds and returns the first k non-repeating characters from a string ==>> " + nonRepeat);

// factorial using recursion in C#:
Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());
long resultFact = Logical.Factorial(number);
Console.WriteLine($"Factorial of {number} is {resultFact}");

// Generate Pan Card
for (int i = 0; i < 5; i++)
{
    Logical.GeneratePANCard();
    Logical.GenerateUniquePANCard();
}

// Two variables compare or two object of class compare
StringTest.CompareTwoVariables();

// Sorting Array
int[] arr = { 1, 0, 1, 0, 1, 1, 0, 0, 1 };

GeneralQueries.SortArray_UsingWhile(arr);
Console.WriteLine("Sorted Array Using While: " + string.Join(",", arr));

GeneralQueries.SortArray_UsingFor();

GeneralQueries.SortArray_UsingLinq();

// positive negative
Logical.PositiveNegativeValue();

// Word Count and occurance of word
Logical.GetOccuranceOfWordsFromSentence("This is a test string. This is a test string. This is a test string.");

//Console.WriteLine("Positive negative output == >>" + posiResult);

// Find distinct numbers in LINQ
var lstInput = new List<int>() { 1, 2, 3, 4, 5, 2, 3, 4, 4, 4, 5, 5, 5, 5, 5, 8, 9 };
LinqQueries.DistinctNumberFromList(lstInput);


// Filtering - Even numbers from given input
LinqQueries.FindOddOrEven(lstInput, true);

// Filtering - Odd Number from given input
LinqQueries.FindOddOrEven(lstInput, false);

// First, FirstOrDefault, Single and SingleOrDefault
LinqQueries.FirstSingleDefault("ramvinaykumar");

// Second highest salary
LinqQueries.SecondHighestSalary();

// Department and Salary
AltemetricTest.GetDepartWiseSpentMoney();
AltemetricTest.GetDepartWiseSpentMoney_LINQ();

// Generic questions
var areEqual = GenericQueries<int>.AreEqual(4, 0);
Console.WriteLine("Input are equal  : >>> " + areEqual);

// AbstractClass abstractClass = new ConcreteClass();
// 	abstractClass.ConcreteMethod();

// var primeData = Logical.ReturnPrimeNumbers(100);
// Console.WriteLine("Prime Number are :>>> " + primeData);

var reverseString = Logical.ReverseString("Vinay"); // yaniv
Console.WriteLine("Reversed string is :>>> " + reverseString);

// var reverseStringLINQ = Logical.ReverseStringLinq("Vinay"); // yaniv
// Console.WriteLine("LINQ Reversed string is :>>> " + reverseStringLINQ);

// var reverseStringLOOP = Logical.ReverseStringLoop("Vinay"); // yaniv
// Console.WriteLine("LOOP Reversed string is :>>> " + reverseStringLOOP);

var reverseTheNumber = Logical.ReverseNumber(123); // 654321
Console.WriteLine("Reversed Number is :>>> " + reverseTheNumber);

// Example array
int[] numbers = { 3, 5, 7, 2, 8, -1, 4, 10, 12 };

// Call the method to find the largest number
int largestNumber = Logical.FindLargestNumber(numbers);

// Print the largest number
Console.WriteLine("The largest number in the array is: " + largestNumber);

GeneralQueries.ExchangeInteger();

Console.WriteLine(GeneralQueries.SwapNeighbourChar("TAPAN"));


GeneralQueries.FibonacciSeries(10);

var factorial = GeneralQueries.FactorialOfNumber(5);
Console.WriteLine("Factorial Of 5 Is " + factorial.ToString());

var text = "like for example $  you don't have $  network $  access $ dfas $ dfgdfg";
GeneralQueries.PreserveFirstAndRemoveAll(text);

string input = "Ball";
string result = GeneralQueries.ReverseWithoutChangingVowels(input);
Console.WriteLine(result); // Output: lalb

// Special Data Types:
SpecialDataTypes.NullableExample();
SpecialDataTypes.AnonymousExample();
SpecialDataTypes.DynamicExample();
SpecialDataTypes.TupleExample();
SpecialDataTypes.SpanMemoryTExample();
SpecialDataTypes.RecordsExample();

// C# Indexer 
Indexer emp = new Indexer(101, "Pranaya", "SSE", 10000, "Mumbai", "IT", "Male");
//Access the Employee Object using Indexer i.e. using Integer Index Position
Console.WriteLine("EID = " + emp[0]);
Console.WriteLine("Name = " + emp[1]);
Console.WriteLine("Job = " + emp[2]);
Console.WriteLine("Salary = " + emp[3]);
Console.WriteLine("Location = " + emp[4]);
Console.WriteLine("Department = " + emp[5]);
Console.WriteLine("Gender = " + emp[6]);
//Set the Employee Object using Indexer i.e. using Integer Index Position
emp[1] = "Kumar";
emp[3] = 65000;
emp[5] = "BBSR";
Console.WriteLine("========After Modification========");
//Access the Employee Object using Indexer i.e. using Integer Index Position
Console.WriteLine("EID = " + emp[0]);
Console.WriteLine("Name = " + emp[1]);
Console.WriteLine("Job = " + emp[2]);
Console.WriteLine("Salary = " + emp[3]);
Console.WriteLine("Location = " + emp[4]);
Console.WriteLine("Department = " + emp[5]);
Console.WriteLine("Gender = " + emp[6]);


// Test query


var outputOfString = MyTest.KthLargestNumber();
Console.WriteLine("========KthLargestNumber========");
Console.WriteLine("The Output is ==>>" + outputOfString);

// Extracts the maximum numeric value from an alphanumeric string
Console.WriteLine("========Strat of Extracts the maximum numeric value from an alphanumeric string========");
//string alphanumericInput = "100klh564abc365bg";
string[] alphanumericInput = { "100klh564abc365bg", "1080klbvxh5684annbc3685bg", "12300klh54364abc334465bg", "1034320klhasdf5retrt64abc36rtwr5bg", "103430klh56534534abc3652345dfgfd5bg3454534hdffg7567758u76" };
foreach (var item in alphanumericInput)
{
    Console.WriteLine("========ExtractMaxNumericValue using Regex========");
    int maxValue = MyTest.ExtractMaxNumericValue(item);
    Console.WriteLine($"The maximum numeric value is: {maxValue}");

    Console.WriteLine("========ExtractMaxNumericValue using LINQ========");
    int maxValue_LINQ = MyTest.ExtractMaxNumericValue_LINQ(item);
    Console.WriteLine($"The maximum numeric value is using LINQ : {maxValue_LINQ}");

    Console.WriteLine("========ExtractMaxNumericValue using Span========");
    int maxValue_Span = MyTest.ExtractMaxNumericValue_Span(item);
    Console.WriteLine($"The maximum numeric value  is using SPAN : {maxValue_Span}");

    Console.WriteLine("========ExtractMaxNumericValue using Char========");
    int maxValue_Char = MyTest.ExtractMaxNumericValue_Char(item);
    Console.WriteLine($"The maximum numeric value is using char: {maxValue_Char}");
}
Console.WriteLine("========End of Extracts the maximum numeric value from an alphanumeric string========");

// Sorts a given string in descending lexicographical order
Console.WriteLine("========Sorts a given string in descending lexicographical order========");
string[] lexicographical = { "geeks", "cheers" };
foreach (var item in lexicographical)
{
    MyTest.SortStringInDescendingOrder(item);
    MyTest.SortStringInDescendingOrder_ArraySort(item);
    MyTest.SortStringInDescendingOrder_BubbleSort(item);
    MyTest.SortStringInDescendingOrder_ListSort(item);
    MyTest.SortStringInDescendingOrder_Span(item);
}
Console.WriteLine("========Sorts a given string in descending lexicographical order========");

// Lexicographical order
Console.WriteLine("========Lexicographical order========");
MyTest.LexicoGraphicalOrder();
Console.WriteLine("========Lexicographical order========");

// smallest positive integer
Console.WriteLine("========smallest positive integer========");
MyTest.SmallestPositiveInteger();
Console.WriteLine("========smallest positive integer========");

// minimum number of distinct letters of a string S, that can be constructed from P and Q
Console.WriteLine("========minimum number of distinct letters of a string S, that can be constructed from P and Q========");

Dictionary<string, string> minimumLetters = new Dictionary<string, string>();
minimumLetters.Add("abc", "bcd");
minimumLetters.Add("axxz", "yzwy");
minimumLetters.Add("bacad", "abada");
minimumLetters.Add("amz", "amz");
minimumLetters.Add("abcdef", "bcdefa");
foreach (var item in minimumLetters)
{
    MyTest.MinimumNumberOfDistinctLetters(item.Key, item.Value);
}
Console.WriteLine("========minimum number of distinct letters of a string S, that can be constructed from P and Q========");

// Inventory Management System
InventoryManagement inventory = new InventoryManagement();
//inventory.ShowInventory();

// 03-Feb-2025
//var operations = new[] { "WRITE Hello", "WRITE World", "UNDO" };
var operations = new[] { "WRITE Hello", "WRITE World", "UNDO", "WRITE Micro1", "WRITE Tiger", "UNDO" };
var documentVersioning = new DocumentVersioning();
documentVersioning.ProcessOperations(operations);

// Max Income Calculator
Console.WriteLine("Start of Max Income Calculator...");
//MaxIncomeCalculator.IncomeCalculator(new int[] { 4, 1, 2, 3 });
//MaxIncomeCalculator.IncomeCalculator(new int[] { 1, 2, 3, 3, 2, 1, 5 });
//MaxIncomeCalculator.IncomeCalculator(new int[] { 1000000000, 1, 2, 2, 1000000000, 1, 1000000000 });

MaxIncomeCalculator.MaxProfit(new int[] { 4, 1, 2, 3 });
MaxIncomeCalculator.MaxProfit(new int[] { 1, 2, 3, 3, 2, 1, 5 });
MaxIncomeCalculator.MaxProfit(new int[] { 1000000000, 1, 2, 2, 1000000000, 1, 1000000000 });

Console.WriteLine("End of Max Income Calculator...");

// Saga Pattern Sample
var messageBus = new InMemoryMessageBus();
var sagaOrchestrator = new OrderSagaOrchestrator(messageBus);
var orderService = new OrderService(sagaOrchestrator);
var paymentService = new PaymentService(messageBus);
var inventoryService = new InventoryService(messageBus);

// Subscribe services to message bus
messageBus.OnOrderCreated += paymentService.ProcessPayment;
messageBus.OnPaymentProcessed += sagaOrchestrator.HandlePaymentProcessedAsync;
messageBus.OnPaymentProcessed += inventoryService.UpdateInventory;
messageBus.OnInventoryUpdated += sagaOrchestrator.HandleInventoryUpdatedAsync;

// Start Saga
await orderService.CreateOrder(Guid.NewGuid(), 100.00m);







// Polymorphism
Animal myDog = new Dog();
Animal myCat = new Cat();

// Call the overridden methods
myDog.MakeSound(); // Output: The dog says: bark
myCat.MakeSound(); // Output: The cat says: meow


Animal animal = new Animal();
animal.MakeSound();
Dog dog = new Dog();
Cat cat = new Cat();

dog.MakeSound();
cat.MakeSound();

Console.ReadLine();

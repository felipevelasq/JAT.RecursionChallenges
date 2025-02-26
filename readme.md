# Recursion Challenges
The following are some specific recursion challenges and their solutions.

## Calculate average age

Given an array of `Person` objects, calculate the average age using recursion.

```
record Person(string Name, int Age)
```

## Print persons under average age (inclusive)

Given an array of `Person` objects, print all objects whose age is equal to or below the average age using recursion.

```
record Person(string Name, int Age, List<Person> Children)
```

## Print the selected node and all its descendants
Given an array of `Person` objects, print the selected person and all of his descendants.

```
record Person(string Name, int Age, List<Person> Children)
```

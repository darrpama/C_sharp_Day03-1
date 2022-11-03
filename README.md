# Day 03 – .NET Boot camp
### Harder, Better, Faster, YAML

# Contents
1. [Chapter I](#chapter-i) \
	[General Rules](#general-rules)
2. [Chapter II](#chapter-ii) \
	[Rules of the Day](#rules-of-the-day)
3. [Chapter III](#chapter-iii) \
	[Intro](#intro)
4. [Chapter IV](#chapter-iv) \
	[Exercise 00 – Configuration](#exercise-00-configuration)
5. [Chapter V](#chapter-v) \
	[Exercise 01 – JSON](#exercise-01-json)
6. [Chapter VI](#chapter-vi) \
	[Exercise 02 – YAML](#exercise-02-yaml)
7. [Chapter VII](#chapter-vii) \
	[Exercise 03 – Exceptions](#exercise-03-exceptions)
8. [Chapter VIII](#chapter-viii) \
	[Exercise 04 – Priorities](#exercise-04-priorities)
9. [Chapter IX](#chapter-ix) \
	[In addition](#in-addition)

# Chapter I 

## General Rules
- Make sure you have [the .NET 5 SDK](<https://dotnet.microsoft.com/download>) installed on your computer and use it.
- Remember, your code will be read! Pay special attention to the design of your code and the naming of variables. Adhere to commonly accepted [C# Coding Conventions](<https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions>).
- Choose your own IDE that is convenient for you.
- The program must be able to run from the dotnet command line.
- Each of the exercise contains examples of input and output. The solution should use them as the correct format.
- At the beginning of each task, there is a list of allowed language constructs.
- If you find the problem difficult to solve, ask questions to other piscine participants, the Internet, Google or go to StackOverflow.
- You may see the main features of C# language in [official specification](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/introduction>).
- Avoid hard coding and "magic numbers".
- You demonstrate the complete solution, the correct result of the program is just one of the ways to check its correct operation. Therefore, when it is necessary to obtain a certain output as a result of the work of your programs, it is forbidden to show a pre-calculated result.
- Pay special attention to the terms highlighted in **bold** font: their study will be useful to you both in performing the current task, and in your future career of a .NET developer.
- Have fun :)


# Chapter II
##  Rules of the Day

- You cannot use nuget packages.
- All projects must be in the same solution.
- Use **top-level-statements**  and **var**.
- The names of the solution and its project (and its separate catalog) should look like d{xx}, where xx is the digits of the current day
- To format the output data, use the en-GB **culture**: N2 for the output of monetary amounts, d for dates.
- Data files in exercises are considered correct and do not need validation.

## What's new

- YAML, JSON
- Hash tables
- Exceptions
- nuget

## Project structure:
```
d03/
	Program.cs
    Configuration/
        Configuration.cs
        Sources/
            IConfigurationSource.cs
            YamlSource.cs
            JsonSource.cs
```

# Chapter III
## Intro

Your apps are getting sleeker and bigger. You understand that the case comes to the distribution of your software, so it’s better to take sensitive data and settings depending on the environments - the database connection string, various flags, server address, constants out of the code and store them in a separate application configuration. Reading these parameters from **JSON** or **YAML** files is a great option.

So, you have two test files attached to the exercise: _config.json_ and _config.yml_. You need to make an application that will pull its settings out of these files. 

# Chapter IV
## Exercise 00 – Configuration

To process and store parameters implement the _Configuration_ class. It should contain the _Params_ collection - a set of parameters necessary for the application to work, a key-value dictionary. Keys must be unique, so **hash tables** are a good choice for this. 

Remember about **the single responsibility principle**: the _Configuration_ class should know nothing about the data source(s), whether it is JSON, YAML, or anything else. Therefore, let’s extract a common _IConfigurationSource_ interface to implement different sources. It will be responsible for loading data from the file and have a method that returns a collection of parameters.

Implement the constructor of the _Configuration_ class, so that it accepts the _IConfigurationSource_ collection of parameters and the _Params_ collection is filled with them.

This is how **the dependency inversion principle** will be kept: the _Configuration_ class will depend on the _IConfigurationSource_ abstraction, not on specific implementations of the given interface. Later, if you decide to add new sources, you won’t have to rewrite the configuration. 

# Chapter V
## Exercise 01 – JSON

Implement the _JsonSource_ class, the descendant of _IConfigurationSource_. The only constructor of  the class should be a constructor that accepts the path to the json file, where the configuration will be loaded from. To turn a JSON file into a **Hashtable**, use the built-in **System.Text.Json** tools. 

We assume the structure of the parameters in the files is flat, and there is no nested data here.

Create an instance of the _Configuration_ class using a _JsonSource_ filled in from the config.json file. Output the configuration to the console in the following format:
```
Configuration
{Key}: {Value}
{Key}: {Value}
...
{Key}: {Value}
```

### Input parameters

```
$ dotnet run “{filePath}”
```

|Argument|Type|Description|
|---|---|---|
| filePath |string | Path to a json file |

### Example of launching an application from the project folder

```
Configuration
Port: 1234
CheckForUpdates: True
Domain: http://localhost
Source: JSON
```

# Chapter VI
## Exercise 02 – YAML

Implement the _YamlSource_ class, the descendant of _IConfigurationSource_. The only constructor of the class should be a constructor that accepts the path to the yaml file, where the configuration will be loaded from. There are no built-in tools to get a Hashtable from a **YAML** file yet, but it’s not a big deal. The fact is that any development, one way or another, is a team work, and there is a **nuget** tool for sharing useful code. Connect and use the **YamlDotNet** package. 

We assume the structure of the parameters in the files is flat, and there is no nested data here.

Create an instance of the _Configuration_ class using the _YamlSource_ filled in from the config.yml file. Output the configuration to the console in the following format:
```
Configuration
{Key}: {Value}
{Key}: {Value}
...
{Key}: {Value}
```

### Input parameters

```
$ dotnet run “{filePath}”
```

|Argument|Type|Description|
|---|---|---|
| filePath |string | Path to a yaml file |

### Example of launching an application from the project folder

```
Configuration
CheckForUpdates: false
Port: 8080
Source: YAML
Application: ex03
```

# Chapter VII
## Exercise 03 – Exceptions

**Deserializing** files with wrong format can lead to **exceptions** in the application. This is normal if the exception is [handled](<https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions>). 

Append a call to the configuration processing classes to catch exceptions that occur during deserialization. In this case, you need to output an error about incorrect data:
```
Invalid data. Check your input and try again.
```

# Chapter VIII
## Exercise 04 – Priorities

The _Configuration_ class will be created by collecting data from different sources. However, the final collection of parameters, which will be relevant to the application, must be one. Therefore, you should be able to merge parameters of the same name from different sources of configurations. Which means each of the sources must have a _Priority_ parameter so that _Configuration_ can determine in what order it will load and merge data.

Add a property to the _IConfigurationSource_ interface that displays the priority of the configuration source. The property must be private for editing and fillable from the class constructor.

Append _Configuration_ so that the priority is taken into account when loading configurations from different sources.

Create an instance of the _Configuration_ class with a configuration from two sources: _YamlSource_ and _JsonSource_. Set the path to the files and their priority from the console when launching the application.

Output the configuration to the console in the following format:
```
Configuration
{Key}: {Value}
{Key}: {Value}
...
{Key}: {Value}
```

### Input parameters

```
$ dotnet run “{jsonPath}” {jsonPriority} “{yamlPath}” {yamlPriority}
```

|Argument|Type|Description|
|---|---|---|
| jsonPath |string | Path to a json file |
| jsonPriority |int | Priority of a json file |
| yamlPath |string | Path to a yaml file |
| yamlPriority |int | Priority of a yaml file |

### Example of launching an application from the project folder

```
$ dotnet run “pathToJson” 1 “pathToYaml” 2
Configuration
Source: YAML
Application: ex03
CheckForUpdates: false
Domain: http://localhost
Port: 8080
```

```
$ dotnet run “pathToJson” 1 “pathToYaml” 0
Configuration
CheckForUpdates: True
Application: ex03
Port: 1234
Source: JSON
Domain: http://localhost
```

# Chapter IX
## In addition
Sometimes, it is useful to take another step and remember [the methodology of the twelve-factor](<https://12factor.net/config>). Many applications allow you to read parameters not only from files, but also from environment variables. 

This is not required in the exercise, but keep it in mind for the future! Try adding a new EnvSource to the application and implementing reading parameters from it.

# veesay
An enhanced clone of cowsay written in C# aiming to implement more features, such as different speech bubble styles and backgrounds.

## Current state
A preliminary implementation has been completed. I have made an ASCII rendition of [Eevee](https://en.wikipedia.org/wiki/Eevee) as test data, which gave the project its initial namesake for being the test subject. The ASCII art used by the program is currently hard-coded, but will be moved in its entirety to the project wiki as example data. **As veesay is in pre-alpha state, code will change drastically as new features are implemented.**

## Installation
While veesay isn't ready for common use yet, it does function for what little it currently does. Ensure you have the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) installed and available in your system's `PATH`.

To make an exectutable for testing veesay early, type the following:
```
dotnet publish -c Release
```
Simply run the resulting executable `VeeSay` in `bin/Release/net5.0/publish/` relative to the project directory.
